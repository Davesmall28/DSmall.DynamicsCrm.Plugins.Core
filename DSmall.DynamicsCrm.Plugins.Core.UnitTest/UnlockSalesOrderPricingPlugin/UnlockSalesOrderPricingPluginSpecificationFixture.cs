namespace DSmall.DynamicsCrm.Plugins.Core.UnitTest
{
    using System;
    using DSmall.DynamicsCrm.UnitTest.Core;
    using Microsoft.Xrm.Sdk;

    /// <summary>The unlock sales order pricing plugin specification fixture.</summary>
    public class UnlockSalesOrderPricingPluginSpecificationFixture : SpecificationFixture<DummyUnlockSalesOrderPricingPlugin>
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
                { "SalesOrderId", Guid.NewGuid() }
            };
        }
    }
}