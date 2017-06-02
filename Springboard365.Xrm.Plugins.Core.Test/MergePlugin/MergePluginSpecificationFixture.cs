namespace Springboard365.Xrm.Plugins.Core.Test
{
    using System;
    using Microsoft.Xrm.Sdk;
    using Springboard365.Xrm.UnitTest.Core;

    public class MergePluginSpecificationFixture : SpecificationFixture<DummyMergePlugin>
    {
        public override void PerformTestSetup()
        {
            ServiceProvider = ServiceProviderInitializer.Setup().WithInputParameters(() => new ParameterCollection
            {
                { InputParameterType.Target, new EntityReference("contact", Guid.NewGuid()) },
                { InputParameterType.SubordinateId, Guid.NewGuid() },
                { InputParameterType.UpdateContent, new Entity("contact") { Id = Guid.NewGuid() } }
            });
        }
    }
}
