namespace Springboard365.Xrm.Plugins.Core.Test
{
    using System;
    using Microsoft.Xrm.Sdk;
    using Springboard365.UnitTest.Xrm.Core;
    using Springboard365.Xrm.Plugins.Core.Constants;
    using Springboard365.Xrm.Plugins.Core.Test.Entities;

    public class MergePluginSpecificationFixture : SpecificationFixture<DummyMergePlugin>
    {
        public override void PerformTestSetup()
        {
            ServiceProvider = ServiceProviderInitializer.Setup().WithInputParameters(() => new ParameterCollection
            {
                { InputParameterType.Target, new EntityReference(Contact.EntityLogicalName, Guid.NewGuid()) },
                { InputParameterType.SubordinateId, Guid.NewGuid() },
                { InputParameterType.UpdateContent, new Contact { Id = Guid.NewGuid() } }
            });
        }
    }
}
