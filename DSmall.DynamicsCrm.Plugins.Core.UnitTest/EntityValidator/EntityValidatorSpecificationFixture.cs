namespace DSmall.DynamicsCrm.Plugins.Core.UnitTest
{
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
            PluginContext = serviceProviderInitializer.SetupPluginContext();
        }

        /// <summary>The perform test setup with null target entity.</summary>
        public void PerformTestSetupWithNullPostImage()
        {
            UnderTest = new EntityValidator();

            var serviceProviderInitializer = new ServiceProviderInitializer();
            PluginContext = serviceProviderInitializer.SetupPluginContextWithNullPostImage();
        }
    }
}
