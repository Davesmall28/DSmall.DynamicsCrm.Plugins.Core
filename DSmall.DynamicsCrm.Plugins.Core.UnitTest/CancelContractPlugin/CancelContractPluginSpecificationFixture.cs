namespace DSmall.DynamicsCrm.Plugins.Core.UnitTest
{
    using System;
    using Microsoft.Xrm.Sdk;

    /// <summary>The cancel contract plugin specification fixture.</summary>
    public class CancelContractPluginSpecificationFixture : SpecificationFixture<DummyCancelContractPlugin>
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
                { "CancelDate", DateTime.Now },
                { "Status", new OptionSetValue(1) }
            };
        }
    }
}