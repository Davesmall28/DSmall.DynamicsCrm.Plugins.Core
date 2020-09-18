namespace Springboard365.Xrm.Plugins.Core.Test
{
    using NUnit.Framework;
    using Springboard365.Xrm.UnitTest.Core;

    [TestFixture]
    public class WhenExecutingQualifyLeadPluginSuccessfully : Specification<DummyQualifyLeadPlugin>
    {
        protected override void Context()
        {
            TestFixture = new QualifyLeadPluginSpecificationFixture();
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
        public void LeadIdShouldNotBeNull()
        {
            Assert.IsNotNull(TestFixture.UnderTest.LeadId);
        }

        [Test]
        public void CreateAccountShouldNotBeNull()
        {
            Assert.IsNotNull(TestFixture.UnderTest.CreateAccount);
        }

        [Test]
        public void CreateContactShouldNotBeNull()
        {
            Assert.IsNotNull(TestFixture.UnderTest.CreateContact);
        }

        [Test]
        public void CreateOpportunityShouldNotBeNull()
        {
            Assert.IsNotNull(TestFixture.UnderTest.CreateOpportunity);
        }

        [Test]
        public void OpportunityCustomerIdShouldNotBeNull()
        {
            Assert.IsNotNull(TestFixture.UnderTest.OpportunityCustomerId);
        }

        [Test]
        public void SourceCampaignIdShouldNotBeNull()
        {
            Assert.IsNotNull(TestFixture.UnderTest.SourceCampaignId);
        }

        [Test]
        public void StatusShouldNotBeNull()
        {
            Assert.IsNotNull(TestFixture.UnderTest.Status);
        }

        [Test]
        public void OpportunityCurrencyIdShouldNotBeNull()
        {
            Assert.IsNotNull(TestFixture.UnderTest.OpportunityCurrencyId);
        }
    }
}