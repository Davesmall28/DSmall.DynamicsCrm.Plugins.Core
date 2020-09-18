namespace Springboard365.Xrm.Plugins.Core.Test
{
    using System;
    using Microsoft.Xrm.Sdk;
    using Springboard365.UnitTest.Xrm.Core;
    using Springboard365.Xrm.Plugins.Core.Constants;

    public class CancelContractPluginSpecificationFixture : SpecificationFixture<DummyCancelContractPlugin>
    {
        public override void PerformTestSetup()
        {
            ServiceProvider = ServiceProviderInitializer.Setup().WithInputParameters(() => new ParameterCollection
            {
                { InputParameterType.ContractId, Guid.NewGuid() },
                { InputParameterType.CancelDate, DateTime.Now },
                { InputParameterType.Status, new OptionSetValue(1) }
            });
        }
    }
}