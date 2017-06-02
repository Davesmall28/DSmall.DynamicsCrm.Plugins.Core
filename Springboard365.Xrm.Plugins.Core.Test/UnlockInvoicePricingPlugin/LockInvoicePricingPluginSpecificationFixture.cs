namespace Springboard365.Xrm.Plugins.Core.Test
{
    using System;
    using Microsoft.Xrm.Sdk;
    using Springboard365.Xrm.UnitTest.Core;

    public class UnlockInvoicePricingPluginSpecificationFixture : SpecificationFixture<DummyUnlockInvoicePricingPlugin>
    {
        public override void PerformTestSetup()
        {
            ServiceProvider = ServiceProviderInitializer.Setup().WithInputParameters(() => new ParameterCollection
            {
                { InputParameterType.InvoiceId, Guid.NewGuid() }
            });
        }
    }
}