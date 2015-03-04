namespace DSmall.DynamicsCrm.Plugins.Core.UnitTest
{
    using System;
    using Moq;

    /// <summary>The entity plugin test fixture.</summary>
    public class EntityPluginTestFixture
    {
        /// <summary>Gets or sets the under test.</summary>
        public DummyEntityPlugin UnderTest { get; set; }

        /// <summary>Gets or sets the service provider.</summary>
        public Mock<IServiceProvider> ServiceProvider { get; set; }

        /// <summary>The perform test setup.</summary>
        public void PerformTestSetup()
        {
            var serviceProviderInitializer = new ServiceProviderInitializer();
            ServiceProvider = serviceProviderInitializer.Setup();

            UnderTest = new DummyEntityPlugin();
        }
    }
}