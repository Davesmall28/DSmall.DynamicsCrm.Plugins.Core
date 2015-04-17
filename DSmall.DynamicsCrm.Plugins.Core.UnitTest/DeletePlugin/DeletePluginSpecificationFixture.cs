namespace DSmall.DynamicsCrm.Plugins.Core.UnitTest
{
    using System;
    using DSmall.DynamicsCrm.UnitTest.Core;
    using Microsoft.Xrm.Sdk;

    /// <summary>The delete plugin specification fixture.</summary>
    public class DeletePluginSpecificationFixture : SpecificationFixture<DummyDeletePlugin>
    {
        /// <summary>The perform test setup.</summary>
        public override void PerformTestSetup()
        {
            ServiceProvider = ServiceProviderInitializer.Setup().WithInputParameters(GetDummyInputParameters());
        }

        private ParameterCollection GetDummyInputParameters()
        {
            return new ParameterCollection
            {
                { "Target", new EntityReference("contact", Guid.NewGuid()) },
            };
        }
    }
}