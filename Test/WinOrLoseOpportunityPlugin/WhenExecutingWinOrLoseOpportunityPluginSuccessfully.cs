namespace Springboard365.Xrm.Plugins.Core.Test
{
    using NUnit.Framework;
    using Springboard365.UnitTest.Xrm.Core;

    [TestFixture]
    public class WhenExecutingWinOrLoseOpportunityPluginSuccessfully : Specification<DummyWinOrLoseOpportunityPlugin>
    {
        protected override void Context()
        {
            TestFixture = new WinOrLoseOpportunityPluginSpecificationFixture();
            TestFixture.PerformTestSetup();
        }

        protected override void BecauseOf()
        {
            TestFixture.UnderTest.Execute(TestFixture.ServiceProvider.Object);
        }

        [Test]
        public void OrganizationServiceShouldNotBeNull()
        {
            Assert.IsNotNull(TestFixture.UnderTest.OrganizationService);
        }

        [Test]
        public void PluginExecutionContextShouldNotBeNull()
        {
            Assert.IsNotNull(TestFixture.UnderTest.PluginExecutionContext);
        }

        [Test]
        public void TracingServiceShouldNotBeNull()
        {
            Assert.IsNotNull(TestFixture.UnderTest.TracingService);
        }

        [Test]
        public void OpportunityCloseShouldNotBeNull()
        {
            Assert.IsNotNull(TestFixture.UnderTest.OpportunityClose);
        }

        [Test]
        public void StateShouldNotBeNull()
        {
            Assert.IsNotNull(TestFixture.UnderTest.State);
        }

        [Test]
        public void StatusShouldNotBeNull()
        {
            Assert.IsNotNull(TestFixture.UnderTest.Status);
        }
    }
}