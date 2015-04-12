namespace DSmall.DynamicsCrm.Plugins.Core.UnitTest
{
    using System;
    using Microsoft.Xrm.Sdk;

    /// <summary>The cancel contract specification fixture.</summary>
    public class CancelContractSpecificationFixture : SpecificationFixture<DummyCancelContractPlugin>
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