namespace DSmall.DynamicsCrm.Plugins.Core.IntegrationTest
{
    using Microsoft.Crm.Sdk.Messages;
    using Microsoft.Xrm.Sdk;

    /// <summary>The qualify lead specification fixture.</summary>
    public class QualifyLeadSpecificationFixture : SpecificationFixtureBase
    {
        /// <summary>Gets the qualify lead request.</summary>
        public QualifyLeadRequest QualifyLeadRequest { get; private set; }

        /// <summary>Gets the message name.</summary>
        public string MessageName { get; private set; }

        /// <summary>The perform test setup.</summary>
        public void PerformTestSetup()
        {
            MessageName = "QualifyLead";

            var accountEntity = EntityFactory.CreateAccount();
            var campaignEntity = EntityFactory.CreateCampaign();
            var leadEntity = EntityFactory.CreateLead();

            QualifyLeadRequest = new QualifyLeadRequest
            {
                CreateAccount = true,
                CreateContact = true,
                CreateOpportunity = true,
                LeadId = leadEntity.ToEntityReference(),
                OpportunityCurrencyId = CrmReader.GetCurrencyId(),
                OpportunityCustomerId = accountEntity.ToEntityReference(),
                SourceCampaignId = campaignEntity.ToEntityReference(),
                Status = new OptionSetValue(3)
            };
        }
    }
}