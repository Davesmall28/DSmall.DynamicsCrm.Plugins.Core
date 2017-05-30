namespace Springboard365.Xrm.Plugins.Core.Test
{
    using System;
    using Microsoft.Xrm.Sdk;
    using Springboard365.Xrm.UnitTest.Core;

    public class CancelContractPluginSpecificationFixture : SpecificationFixture<DummyCancelContractPlugin>
    {
        public override void PerformTestSetup()
        {
            ServiceProvider = ServiceProviderInitializer.Setup().WithInputParameters(GetDummyInputParameters());
        }

        private static ParameterCollection GetDummyInputParameters()
        {
            return new ParameterCollection
            {
                { InputParameterType.ContractId, Guid.NewGuid() },
                { InputParameterType.CancelDate, DateTime.Now },
                { InputParameterType.Status, new OptionSetValue(1) }
            };
        }
    }
}