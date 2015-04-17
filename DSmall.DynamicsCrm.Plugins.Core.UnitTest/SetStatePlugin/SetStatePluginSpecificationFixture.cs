namespace DSmall.DynamicsCrm.Plugins.Core.UnitTest
{
    using System;
    using DSmall.DynamicsCrm.UnitTest.Core;
    using Microsoft.Xrm.Sdk;

    /// <summary>The set state plugin specification fixture.</summary>
    public class SetStatePluginSpecificationFixture : SpecificationFixture<DummySetStatePlugin>
    {
        /// <summary>The perform test setup.</summary>
        public override void PerformTestSetup()
        {
            ServiceProvider = ServiceProviderInitializer.Setup().WithInputParameters(GetDummyEntityCollection());           
        }

        private static ParameterCollection GetDummyEntityCollection()
        {
            return new ParameterCollection
            {
                { "EntityMoniker", new EntityReference("contact", Guid.NewGuid()) },
                { "State", new OptionSetValue(1) },
                { "Status", new OptionSetValue(1) }
            };
        }
    }
}
