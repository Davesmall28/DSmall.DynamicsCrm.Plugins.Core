namespace DSmall.DynamicsCrm.Plugins.Core.UnitTest
{
    using System;
    using Microsoft.Xrm.Sdk;

    /// <summary>The add item campaign activity plugin specification fixture.</summary>
    public class AddItemCampaignActivityPluginSpecificationFixture : SpecificationFixture<DummyAddItemCampaignActivityPlugin>
    {
        /// <summary>The perform test setup.</summary>
        public override void PerformTestSetup()
        {
            ServiceProvider = new ServiceProviderInitializer().Setup().WithInputParameters(GetDummyEntityCollection());
        }

        private static ParameterCollection GetDummyEntityCollection()
        {
            return new ParameterCollection
            {
                { "CampaignActivityId", Guid.NewGuid() },
                { "ItemId", Guid.NewGuid() },
                { "EntityName", "Contact" }
            };
        }
    }
}
