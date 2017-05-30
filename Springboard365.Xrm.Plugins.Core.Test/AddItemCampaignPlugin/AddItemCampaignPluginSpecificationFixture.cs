namespace Springboard365.Xrm.Plugins.Core.Test
{
    using System;
    using Microsoft.Xrm.Sdk;
    using Springboard365.Xrm.UnitTest.Core;

    public class AddItemCampaignPluginSpecificationFixture : SpecificationFixture<DummyAddItemCampaignPlugin>
    {
        public override void PerformTestSetup()
        {
            ServiceProvider = ServiceProviderInitializer.Setup().WithInputParameters(GetDummyEntityCollection());
        }

        private static ParameterCollection GetDummyEntityCollection()
        {
            return new ParameterCollection
            {
                { InputParameterType.CampaignId, Guid.NewGuid() },
                { InputParameterType.EntityId, Guid.NewGuid() },
                { InputParameterType.EntityName, "Contact" },
            };
        }
    }
}