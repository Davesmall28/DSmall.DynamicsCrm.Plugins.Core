namespace DSmall.DynamicsCrm.Plugins.Core.IntegrationTest
{
    using Microsoft.Crm.Sdk.Messages;

    /// <summary>The add item campaign activity specification fixture.</summary>
    public class AddItemCampaignActivitySpecificationFixture : SpecificationFixtureBase
    {
        /// <summary>Gets the add item campaign activity request.</summary>
        public AddItemCampaignActivityRequest AddItemCampaignActivityRequest { get; private set; }

        /// <summary>Gets the message name.</summary>
        public string MessageName { get; private set; }

        /// <summary>The perform test setup.</summary>
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