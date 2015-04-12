namespace DSmall.DynamicsCrm.Plugins.Core.UnitTest
{
    using System;
    using Microsoft.Xrm.Sdk;

    /// <summary>The clone contract plugin specification fixture.</summary>
    public class CloneContractPluginSpecificationFixture : SpecificationFixture<DummyCloneContractPlugin>
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
                { "ContractId", Guid.NewGuid() },
                { "IncludeCanceledLines", true }
            };
        }
    }
}