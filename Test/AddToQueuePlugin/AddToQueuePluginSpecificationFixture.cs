namespace Springboard365.Xrm.Plugins.Core.Test
{
    using System;
    using Microsoft.Xrm.Sdk;
    using Springboard365.UnitTest.Xrm.Core;
    using Springboard365.Xrm.Plugins.Core.Constants;
    using Springboard365.Xrm.Plugins.Core.Test.Entities;

    public class AddToQueuePluginSpecificationFixture : SpecificationFixture<DummyAddToQueuePlugin>
    {
        public override void PerformTestSetup()
        {
            ServiceProvider = ServiceProviderInitializer.Setup().WithInputParameters(() => new ParameterCollection
            {
                { InputParameterType.Target, new EntityReference(Letter.EntityLogicalName, Guid.NewGuid()) },
                { InputParameterType.DestinationQueueId, Guid.NewGuid() },
                { InputParameterType.SourceQueueId, Guid.NewGuid() }
            });
        }
    }
}