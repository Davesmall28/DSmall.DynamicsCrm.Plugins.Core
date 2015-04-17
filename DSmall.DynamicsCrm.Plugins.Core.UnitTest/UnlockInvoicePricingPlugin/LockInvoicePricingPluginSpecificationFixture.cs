namespace DSmall.DynamicsCrm.Plugins.Core.UnitTest
{
    using System;
    using DSmall.DynamicsCrm.UnitTest.Core;
    using Microsoft.Xrm.Sdk;

    /// <summary>The unlock invoice pricing plugin specification fixture.</summary>
    public class UnlockInvoicePricingPluginSpecificationFixture : SpecificationFixture<DummyUnlockInvoicePricingPlugin>
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
                { "InvoiceId", Guid.NewGuid() }
            };
        }
    }
}