namespace DSmall.DynamicsCrm.Plugins.Core.UnitTest
{
    using System;
    using DSmall.DynamicsCrm.UnitTest.Core;
    using Microsoft.Xrm.Sdk;

    /// <summary>The add to queue plugin specification fixture.</summary>
    public class AddToQueuePluginSpecificationFixture : SpecificationFixture<DummyAddToQueuePlugin>
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
                { "Target", new EntityReference("letter", Guid.NewGuid()) },
                { "DestinationQueueId", Guid.NewGuid() },
                { "SourceQueueId", Guid.NewGuid() }
            };
        }
    }
}