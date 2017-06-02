namespace Springboard365.Xrm.Plugins.Core.Test
{
    using System;
    using Microsoft.Xrm.Sdk;
    using Springboard365.Xrm.UnitTest.Core;

    public class AddToQueuePluginSpecificationFixture : SpecificationFixture<DummyAddToQueuePlugin>
    {
        public override void PerformTestSetup()
        {
            ServiceProvider = ServiceProviderInitializer.Setup().WithInputParameters(() => new ParameterCollection
            {
                { InputParameterType.Target, new EntityReference("letter", Guid.NewGuid()) },
                { InputParameterType.DestinationQueueId, Guid.NewGuid() },
                { InputParameterType.SourceQueueId, Guid.NewGuid() }
            });
        }
    }
}