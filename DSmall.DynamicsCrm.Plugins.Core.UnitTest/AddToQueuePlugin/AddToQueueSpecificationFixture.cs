namespace DSmall.DynamicsCrm.Plugins.Core.UnitTest
{
    using System;
    using Microsoft.Xrm.Sdk;

    /// <summary>The add to queue specification fixture.</summary>
    public class AddToQueueSpecificationFixture : SpecificationFixture<DummyAddToQueuePlugin>
    {
        /// <summary>The perform test setup.</summary>
        public override void PerformTestSetup()
        {
            ServiceProvider = new ServiceProviderInitializer().Setup().WithInputParameters(GetDummyInputParameters());
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