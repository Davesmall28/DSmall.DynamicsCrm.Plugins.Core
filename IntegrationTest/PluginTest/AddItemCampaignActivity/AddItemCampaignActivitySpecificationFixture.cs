namespace Springboard365.Xrm.Plugins.Core.IntegrationTest
{
    using Microsoft.Crm.Sdk.Messages;

    public class AddItemCampaignActivitySpecificationFixture : SpecificationFixtureBase
    {
        public AddItemCampaignActivityRequest AddItemCampaignActivityRequest { get; private set; }

        public string MessageName { get; private set; }

        public void PerformTestSetup()
        {
            MessageName = "AddItem";

            var listEntity = EntityFactory.CreateMarketingList();

            var campaignEntity = EntityFactory.CreateCampaign();

            var targetEntity = EntityFactory.CreateCampaignActivity(campaignEntity.ToEntityReference());

            var addItemCampaignRequest = new AddItemCampaignRequest
            {
                CampaignId = campaignEntity.Id,
                EntityId = listEntity.Id,
                EntityName = listEntity.LogicalName
            };
            OrganizationService.Execute(addItemCampaignRequest);

            AddItemCampaignActivityRequest = new AddItemCampaignActivityRequest
            {
                CampaignActivityId = targetEntity.Id,
                ItemId = listEntity.Id,
                EntityName = listEntity.LogicalName
            };
        }
    }
}