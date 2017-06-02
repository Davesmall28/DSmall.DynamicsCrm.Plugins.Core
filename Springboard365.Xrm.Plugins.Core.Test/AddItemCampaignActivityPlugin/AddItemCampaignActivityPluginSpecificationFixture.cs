namespace Springboard365.Xrm.Plugins.Core.Test
{
    using System;
    using Microsoft.Xrm.Sdk;
    using Springboard365.Xrm.UnitTest.Core;

    public class AddItemCampaignActivityPluginSpecificationFixture : SpecificationFixture<DummyAddItemCampaignActivityPlugin>
    {
        public override void PerformTestSetup()
        {
            ServiceProvider = ServiceProviderInitializer.Setup().WithInputParameters(() => new ParameterCollection
            {
                { InputParameterType.CampaignActivityId, Guid.NewGuid() },
                { InputParameterType.ItemId, Guid.NewGuid() },
                { InputParameterType.EntityName, "Contact" }
            });
        }
    }
}