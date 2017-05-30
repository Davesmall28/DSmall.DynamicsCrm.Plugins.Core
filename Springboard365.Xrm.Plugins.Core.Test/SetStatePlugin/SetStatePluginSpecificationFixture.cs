namespace Springboard365.Xrm.Plugins.Core.Test
{
    using System;
    using Microsoft.Xrm.Sdk;
    using Springboard365.Xrm.UnitTest.Core;

    public class SetStatePluginSpecificationFixture : SpecificationFixture<DummySetStatePlugin>
    {
        public override void PerformTestSetup()
        {
            ServiceProvider = ServiceProviderInitializer.Setup().WithInputParameters(GetDummyEntityCollection());
        }

        private static ParameterCollection GetDummyEntityCollection()
        {
            return new ParameterCollection
            {
                { InputParameterType.EntityMoniker, new EntityReference("contact", Guid.NewGuid()) },
                { InputParameterType.State, new OptionSetValue(1) },
                { InputParameterType.Status, new OptionSetValue(1) }
            };
        }
    }
}
