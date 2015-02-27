﻿namespace DSmall.DynamicsCrm.Plugins.Core
{
    using System;
    using System.Linq;
    using DSmall.Core;
    using Microsoft.Xrm.Sdk;

    /// <summary>The entity validator.</summary>
    public class EntityValidator : IEntityValidator
    {
        /// <summary>The get valid crm target entity.</summary>
        /// <param name="pluginExecutionContext">The plugin execution context.</param>
        /// <param name="imageType">The image type.</param>
        /// <typeparam name="TEntityType">The entity type.</typeparam>
        /// <returns>The <see cref="TEntityType"/>.</returns>
        public TEntityType GetValidCrmTargetEntity<TEntityType>(IPluginExecutionContext pluginExecutionContext, EntityImageType imageType)
                where TEntityType : Entity
        {
            Guard.NotNull(() => pluginExecutionContext, pluginExecutionContext);

            return GetValidCrmEntity(pluginExecutionContext, imageType).ToEntity<TEntityType>();
        }

        private static Entity GetValidCrmEntity(IPluginExecutionContext pluginExecutionContext, EntityImageType imageType)
        {
            var imageTypeName = imageType.ToString();
            switch (imageType)
            {
                case EntityImageType.Target:
                    return GetTargetEntity(pluginExecutionContext, imageTypeName);
                case EntityImageType.PreImage:
                    return GetPreImageEntity(pluginExecutionContext, imageTypeName);
                case EntityImageType.PostImage:
                    return GetPostImageEntity(pluginExecutionContext, imageTypeName);
                default:
                    throw new InvalidOperationException("Please specify an Entity Image Type.");
            }
        }

        private static Entity GetTargetEntity(IExecutionContext pluginExecutionContext, string imageTypeName)
        {
            return pluginExecutionContext.InputParameters
                .Where(input => input.Key == imageTypeName)
                .Select(input => (Entity)input.Value)
                .Single();
        }

        private static Entity GetPreImageEntity(IExecutionContext pluginExecutionContext, string imageTypeName)
        {
            return GetEntityFromEntityCollection(pluginExecutionContext.PreEntityImages, imageTypeName);
        }

        private static Entity GetPostImageEntity(IExecutionContext pluginExecutionContext, string imageTypeName)
        {
            return GetEntityFromEntityCollection(pluginExecutionContext.PostEntityImages, imageTypeName);
        }

        private static Entity GetEntityFromEntityCollection(DataCollection<string, Entity> entityImageCollection, string imageTypeName)
        {
            if (entityImageCollection.Contains(imageTypeName) && entityImageCollection[imageTypeName] != null)
            {
                return entityImageCollection[imageTypeName];
            }

            var message = string.Format("Parameters collection does not contain {0} entity or it is not equal to type of (Entity)", imageTypeName);
            throw new InvalidPluginExecutionException(message);
        }
    }
}