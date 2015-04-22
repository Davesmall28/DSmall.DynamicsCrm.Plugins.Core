namespace DSmall.DynamicsCrm.Plugins.Core.IntegrationTest
{
    using Microsoft.Crm.Sdk.Messages;

    /// <summary>The add item campaign specification fixture.</summary>
    public class AddItemCampaignSpecificationFixture : SpecificationFixtureBase
    {
        /// <summary>Gets the add item campaign request.</summary>
        public AddItemCampaignRequest AddItemCampaignRequest { get; private set; }

        /// <summary>Gets the message name.</summary>
        public string MessageName { get; private set; }

        /// <summary>The perform test setup.</summary>
        public void PerformTestSetup()
        {
            MessageName = "AddItem";

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