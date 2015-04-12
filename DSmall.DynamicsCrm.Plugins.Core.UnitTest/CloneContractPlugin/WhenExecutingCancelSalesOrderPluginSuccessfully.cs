namespace DSmall.DynamicsCrm.Plugins.Core.UnitTest
{
    using DSmall.UnitTest.Core;
    using NUnit.Framework;

    /// <summary>The when executing clone contract plugin successfully.</summary>
    public class WhenExecutingCloneContractPluginSuccessfully : SpecificationBase
    {
        private CloneContractSpecificationFixture testFixture;

        /// <summary>The organization service should not be null.</summary>
        [Test]
        public void OrganizationServiceShouldNotBeNull()
        {
            Assert.IsNotNull(testFixture.UnderTest.OrganizationService);
        }

        /// <summary>The plugin execution context should not be null.</summary>
        [Test]
        public void PluginExecutionContextShouldNotBeNull()
        {
            Assert.IsNotNull(testFixture.UnderTest.PluginExecutionContext);
        }

        /// <summary>The tracing service should not be null.</summary>
        [Test]
        public void TracingServiceShouldNotBeNull()
        {
            Assert.IsNotNull(testFixture.UnderTest.TracingService);
        }

        /// <summary>The contract id should not be null.</summary>
        [Test]
        public void ContractIdShouldNotBeNull()
        {
            Assert.IsNotNull(testFixture.UnderTest.ContractId);
        }

        /// <summary>The include canceled lines should not be null.</summary>
        [Test]
        public void IncludeCanceledLinesShouldNotBeNull()
        {
            Assert.IsNotNull(testFixture.UnderTest.IncludeCanceledLines);
        }

        /// <summary>The because of.</summary>
        protected override void BecauseOf()
        {
            base.BecauseOf();

            testFixture.UnderTest.Execute(testFixture.ServiceProvider.Object);
        }

        /// <summary>The context.</summary>
        protected override void Context()
        {
            base.Context();

            testFixture = new CloneContractSpecificationFixture();
            testFixture.PerformTestSetup();
        }
    }
}