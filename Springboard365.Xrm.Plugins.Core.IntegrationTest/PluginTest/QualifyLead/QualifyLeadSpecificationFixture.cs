namespace Springboard365.Xrm.Plugins.Core.IntegrationTest
{
    using Microsoft.Crm.Sdk.Messages;
    using Microsoft.Xrm.Sdk;

    public class QualifyLeadSpecificationFixture : SpecificationFixtureBase
    {
        public QualifyLeadRequest QualifyLeadRequest { get; private set; }

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