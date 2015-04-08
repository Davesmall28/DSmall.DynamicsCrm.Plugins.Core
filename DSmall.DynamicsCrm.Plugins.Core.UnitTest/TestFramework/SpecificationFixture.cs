namespace DSmall.DynamicsCrm.Plugins.Core.UnitTest
{
    using System;
    using Moq;

    /// <summary>The specification fixture.</summary>
    /// <typeparam name="TUnderTest">The under test parameter type.</typeparam>
    public class SpecificationFixture<TUnderTest>
        where TUnderTest : class
    {
        /// <summary>Initialises a new instance of the <see cref="SpecificationFixture{TUnderTest}"/> class.</summary>
        public SpecificationFixture()
        {
            var serviceProviderInitializer = new ServiceProviderInitializer();
            ServiceProvider = serviceProviderInitializer.Setup();

            UnderTest = (TUnderTest)Activator.CreateInstance(typeof(TUnderTest));
        }

        /// <summary>Gets or sets the under test.</summary>
        public TUnderTest UnderTest { get; set; }

        /// <summary>Gets or sets the service provider.</summary>
        public Mock<IServiceProvider> ServiceProvider { get; set; }

        /// <summary>The perform test setup.</summary>
        public virtual void PerformTestSetup()
        {
        }
    }
}
