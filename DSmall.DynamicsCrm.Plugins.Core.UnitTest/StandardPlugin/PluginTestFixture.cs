namespace DSmall.DynamicsCrm.Plugins.Core.UnitTest
{
    using System;
    using Moq;

    /// <summary>The plugin test fixture.</summary>
    public class PluginTestFixture
    {
        /// <summary>Gets or sets the under test.</summary>
        public DummyPlugin UnderTest { get; set; }

        /// <summary>Gets or sets the service provider.</summary>
        public Mock<IServiceProvider> ServiceProvider { get; set; }

        /// <summary>The perform test setup.</summary>
        public void PerformTestSetup()
        {
            var serviceProviderInitializer = new ServiceProviderInitializer();
            ServiceProvider = serviceProviderInitializer.Setup();

            UnderTest = new DummyPlugin();
        }
    }
}