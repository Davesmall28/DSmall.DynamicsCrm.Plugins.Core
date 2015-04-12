namespace DSmall.DynamicsCrm.Plugins.Core.UnitTest
{
    using DSmall.UnitTest.Core;
    using NUnit.Framework;

    /// <summary>The when executing cancel contract plugin successfully.</summary>
    public class WhenExecutingCancelContractPluginSuccessfully : SpecificationBase
    {
        private CancelContractPluginSpecificationFixture testFixture;

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

        /// <summary>The cancel date reference should not be null.</summary>
        [Test]
        public void CancelDateReferenceShouldNotBeNull()
        {
            Assert.IsNotNull(testFixture.UnderTest.CancelDate);
        }

        /// <summary>The contract id should not be null.</summary>
        [Test]
        public void ContractIdShouldNotBeNull()
        {
            Assert.IsNotNull(testFixture.UnderTest.ContractId);
        }

        /// <summary>The status should not be null.</summary>
        [Test]
        public void StatusShouldNotBeNull()
        {
            Assert.IsNotNull(testFixture.UnderTest.Status);
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

            testFixture = new CancelContractPluginSpecificationFixture();
            testFixture.PerformTestSetup();
        }
    }
}