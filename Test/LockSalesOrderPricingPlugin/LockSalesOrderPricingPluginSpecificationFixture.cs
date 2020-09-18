namespace Springboard365.Xrm.Plugins.Core.Test
{
    using System;
    using Microsoft.Xrm.Sdk;
    using Springboard365.Xrm.Plugins.Core.Constants;
    using Springboard365.Xrm.UnitTest.Core;

    public class LockSalesOrderPricingPluginSpecificationFixture : SpecificationFixture<DummyLockSalesOrderPricingPlugin>
    {
        public override void PerformTestSetup()
        {
            ServiceProvider = ServiceProviderInitializer.Setup().WithInputParameters(() => new ParameterCollection
            {
                { InputParameterType.SalesOrderId, Guid.NewGuid() }
            });
        }
    }
}