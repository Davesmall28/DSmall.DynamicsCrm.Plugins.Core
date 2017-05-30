namespace Springboard365.Xrm.Plugins.Core.Test
{
    using NUnit.Framework;
    using Springboard365.UnitTest.Core;

    public class WhenExecutingCancelContractPluginSuccessfully : SpecificationBase
    {
        private CancelContractPluginSpecificationFixture testFixture;

        protected override void Context()
        {
            testFixture = new CancelContractPluginSpecificationFixture();
            testFixture.PerformTestSetup();
        }

        protected override void BecauseOf()
        {
            testFixture.UnderTest.Execute(testFixture.ServiceProvider.Object);
        }

        [Test]
        public void OrganizationServiceShouldNotBeNull()
        {
            Assert.IsNotNull(testFixture.UnderTest.OrganizationService);
        }

        [Test]
        public void PluginExecutionContextShouldNotBeNull()
        {
            Assert.IsNotNull(testFixture.UnderTest.PluginExecutionContext);
        }

        [Test]
        public void TracingServiceShouldNotBeNull()
        {
            Assert.IsNotNull(testFixture.UnderTest.TracingService);
        }

        [Test]
        public void CancelDateReferenceShouldNotBeNull()
        {
            Assert.IsNotNull(testFixture.UnderTest.CancelDate);
        }

        [Test]
        public void ContractIdShouldNotBeNull()
        {
            Assert.IsNotNull(testFixture.UnderTest.ContractId);
        }

        [Test]
        public void StatusShouldNotBeNull()
        {
            Assert.IsNotNull(testFixture.UnderTest.Status);
        }
    }
}