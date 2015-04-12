namespace DSmall.DynamicsCrm.Plugins.Core.UnitTest
{
    using DSmall.UnitTest.Core;
    using NUnit.Framework;

    /// <summary>The when executing qualify lead plugin successfully.</summary>
    public class WhenExecutingQualifyLeadPluginSuccessfully : SpecificationBase
    {
        private QualifyLeadPluginSpecificationFixture testFixture;

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

        /// <summary>The lead id should not be null.</summary>
        [Test]
        public void LeadIdShouldNotBeNull()
        {
            Assert.IsNotNull(testFixture.UnderTest.LeadId);
        }

        /// <summary>The create account should not be null.</summary>
        [Test]
        public void CreateAccountShouldNotBeNull()
        {
            Assert.IsNotNull(testFixture.UnderTest.CreateAccount);
        }

        /// <summary>The create contact should not be null.</summary>
        [Test]
        public void CreateContactShouldNotBeNull()
        {
            Assert.IsNotNull(testFixture.UnderTest.CreateContact);
        }

        /// <summary>The create opportunity should not be null.</summary>
        [Test]
        public void CreateOpportunityShouldNotBeNull()
        {
            Assert.IsNotNull(testFixture.UnderTest.CreateOpportunity);
        }

        /// <summary>The opportunity customer id should not be null.</summary>
        [Test]
        public void OpportunityCustomerIdShouldNotBeNull()
        {
            Assert.IsNotNull(testFixture.UnderTest.OpportunityCustomerId);
        }

        /// <summary>The source campaign id should not be null.</summary>
        [Test]
        public void SourceCampaignIdShouldNotBeNull()
        {
            Assert.IsNotNull(testFixture.UnderTest.SourceCampaignId);
        }

        /// <summary>The status should not be null.</summary>
        [Test]
        public void StatusShouldNotBeNull()
        {
            Assert.IsNotNull(testFixture.UnderTest.Status);
        }

        /// <summary>The opportunity currency id should not be null.</summary>
        [Test]
        public void OpportunityCurrencyIdShouldNotBeNull()
        {
            Assert.IsNotNull(testFixture.UnderTest.OpportunityCurrencyId);
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

            testFixture = new QualifyLeadPluginSpecificationFixture();
            testFixture.PerformTestSetup();
        }
    }
}