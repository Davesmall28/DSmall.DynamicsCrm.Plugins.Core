namespace Springboard365.Xrm.Plugins.Core.Test
{
    using NUnit.Framework;
    using Springboard365.UnitTest.Core;

    public class WhenExecutingWinOrLoseOpportunityPluginSuccessfully : SpecificationBase
    {
        private WinOrLoseOpportunityPluginSpecificationFixture testFixture;

        protected override void Context()
        {
            testFixture = new WinOrLoseOpportunityPluginSpecificationFixture();
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
        public void OpportunityCloseShouldNotBeNull()
        {
            Assert.IsNotNull(testFixture.UnderTest.OpportunityClose);
        }

        [Test]
        public void StateShouldNotBeNull()
        {
            Assert.IsNotNull(testFixture.UnderTest.State);
        }

        [Test]
        public void StatusShouldNotBeNull()
        {
            Assert.IsNotNull(testFixture.UnderTest.Status);
        }
    }
}