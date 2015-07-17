namespace DSmall.DynamicsCrm.Plugins.Core
{
    using System;
    using DSmall.DynamicsCrm.Core;
    using Microsoft.Xrm.Sdk;

    /// <summary>The entity plugin </summary>
    /// <typeparam name="TEntityType">The entity type.</typeparam>
    public abstract class EntityPlugin<TEntityType> : Plugin
        where TEntityType : Entity
    {
        /// <summary>The execute.</summary>
        /// <param name="organizationService">The organization service.</param>
        /// <param name="pluginExecutionContext">The plugin execution context.</param>
        /// <param name="tracingService">The tracing service.</param>
        public override void Execute(IOrganizationService organizationService, IPluginExecutionContext pluginExecutionContext, ITracingService tracingService)
        {
            var targetEntity = EntityValidator.GetValidCrmTargetEntity<Entity>(pluginExecutionContext, EntityImageType.Target);

            var instance = Activator.CreateInstance<TEntityType>();

            if (targetEntity.LogicalName != instance.LogicalName)
            {
                throw new ArgumentException("aaa");
            }

            Execute(organizationService, pluginExecutionContext, tracingService, targetEntity.ToEntity<TEntityType>());
        }

        /// <summary>The execute.</summary>
        /// <param name="organizationService">The organization service.</param>
        /// <param name="pluginExecutionContext">The plugin execution context.</param>
        /// <param name="tracingService">The tracing service.</param>
        /// <param name="targetEntity">The target entity.</param>
        public abstract void Execute(IOrganizationService organizationService, IPluginExecutionContext pluginExecutionContext, ITracingService tracingService, TEntityType targetEntity);
    }
}
