namespace Springboard365.Xrm.Plugins.Core.Test
{
    using NUnit.Framework;
    using Springboard365.UnitTest.Core;

    public class WhenExecutingQualifyLeadPluginSuccessfully : SpecificationBase
    {
        private QualifyLeadPluginSpecificationFixture testFixture;

        protected override void Context()
        {
            testFixture = new QualifyLeadPluginSpecificationFixture();
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
        public void LeadIdShouldNotBeNull()
        {
            Assert.IsNotNull(testFixture.UnderTest.LeadId);
        }

        [Test]
        public void CreateAccountShouldNotBeNull()
        {
            Assert.IsNotNull(testFixture.UnderTest.CreateAccount);
        }

        [Test]
        public void CreateContactShouldNotBeNull()
        {
            Assert.IsNotNull(testFixture.UnderTest.CreateContact);
        }

        [Test]
        public void CreateOpportunityShouldNotBeNull()
        {
            Assert.IsNotNull(testFixture.UnderTest.CreateOpportunity);
        }

        [Test]
        public void OpportunityCustomerIdShouldNotBeNull()
        {
            Assert.IsNotNull(testFixture.UnderTest.OpportunityCustomerId);
        }

        [Test]
        public void SourceCampaignIdShouldNotBeNull()
        {
            Assert.IsNotNull(testFixture.UnderTest.SourceCampaignId);
        }

        [Test]
        public void StatusShouldNotBeNull()
        {
            Assert.IsNotNull(testFixture.UnderTest.Status);
        }

        [Test]
        public void OpportunityCurrencyIdShouldNotBeNull()
        {
            Assert.IsNotNull(testFixture.UnderTest.OpportunityCurrencyId);
        }
    }
}