﻿namespace DSmall.DynamicsCrm.Plugins.Core.UnitTest
{
    using System;
    using Microsoft.Xrm.Sdk;
    using Moq;

    /// <summary>The entity validator specification fixture.</summary>
    public class EntityValidatorSpecificationFixture
    {
        /// <summary>Gets or sets the under test.</summary>
        public IEntityValidator UnderTest { get; set; }

        /// <summary>Gets or sets the plugin context.</summary>
        public Mock<IPluginExecutionContext> PluginContext { get; set; }

        /// <summary>The perform test setup.</summary>
        public void PerformTestSetup()
        {
            UnderTest = new EntityValidator();

            var serviceProviderInitializer = new ServiceProviderInitializer();
            PluginContext = serviceProviderInitializer
                .SetupPluginContext()
                .WithInputParameters(GetTargetEntityCollection())
                .WithPreEntityImages(GetPreImageEntityCollection())
                .WithPostEntityImages(GetPostImageEntityCollection());
        }

        /// <summary>The perform test setup with null target entity.</summary>
        public void PerformTestSetupWithNullPostImage()
        {
            UnderTest = new EntityValidator();

            PluginContext = new ServiceProviderInitializer()
                .SetupPluginContext()
                .WithPostEntityImages(new EntityImageCollection { { "PostImage", null } });
        }

        private static ParameterCollection GetTargetEntityCollection()
        {
            return new ParameterCollection
            {
                { "Target", new Entity("contact") { Id = Guid.NewGuid() } }
            };
        }

        private static EntityImageCollection GetPreImageEntityCollection()
        {
            return new EntityImageCollection
            {
                { "PreImage", new Entity("contact") { Id = Guid.NewGuid() } }
            };
        }

        private static EntityImageCollection GetPostImageEntityCollection()
        {
            return new EntityImageCollection
            {
                { "PostImage", new Entity("contact") { Id = Guid.NewGuid() } }
            };
        }
    }
}
