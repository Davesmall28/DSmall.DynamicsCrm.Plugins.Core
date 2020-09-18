namespace Springboard365.Xrm.Plugins.Core.Test
{
    using System;
    using Microsoft.Xrm.Sdk;
    using Springboard365.UnitTest.Xrm.Core;
    using Springboard365.Xrm.Plugins.Core.Constants;
    using Springboard365.Xrm.Plugins.Core.Test.Entities;

    public class AddItemCampaignPluginSpecificationFixture : SpecificationFixture<DummyAddItemCampaignPlugin>
    {
        public override void PerformTestSetup()
        {
            ServiceProvider = ServiceProviderInitializer.Setup().WithInputParameters(() => new ParameterCollection
            {
                { InputParameterType.CampaignId, Guid.NewGuid() },
                { InputParameterType.EntityId, Guid.NewGuid() },
                { InputParameterType.EntityName, Contact.EntityLogicalName },
            });
        }
    }
}