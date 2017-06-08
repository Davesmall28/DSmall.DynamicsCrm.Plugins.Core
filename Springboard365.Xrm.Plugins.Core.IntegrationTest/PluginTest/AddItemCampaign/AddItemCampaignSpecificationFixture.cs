namespace Springboard365.Xrm.Plugins.Core.IntegrationTest
{
    using Microsoft.Crm.Sdk.Messages;

    public class AddItemCampaignSpecificationFixture : SpecificationFixtureBase
    {
        public AddItemCampaignRequest AddItemCampaignRequest { get; private set; }

        public AddItemCampaignSpecificationFixture()
            : base("AddItem")
        {
        }

        public void PerformTestSetup()
        {
            var targetEntity = EntityFactory.CreateCampaign();

            var listEntity = EntityFactory.CreateMarketingList();

            AddItemCampaignRequest = new AddItemCampaignRequest
            {
                CampaignId = targetEntity.Id,
                EntityId = listEntity.Id,
                EntityName = listEntity.LogicalName
            };
        }
    }
}