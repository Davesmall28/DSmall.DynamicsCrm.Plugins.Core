namespace Springboard365.Xrm.Plugins.Core.Test
{
    using System;
    using Microsoft.Xrm.Sdk;
    using Springboard365.UnitTest.Xrm.Core;
    using Springboard365.Xrm.Plugins.Core.Constants;
    using Springboard365.Xrm.Plugins.Core.Test.Entities;

    public class AssignPluginSpecificationFixture : SpecificationFixture<DummyAssignPlugin>
    {
        public override void PerformTestSetup()
        {
            ServiceProvider = ServiceProviderInitializer.Setup().WithInputParameters(() => new ParameterCollection
            {
                { InputParameterType.Target, new EntityReference(Letter.EntityLogicalName, Guid.NewGuid()) },
                { InputParameterType.Assignee, new EntityReference(SystemUser.EntityLogicalName, Guid.NewGuid()) }
            });
        }
    }
}