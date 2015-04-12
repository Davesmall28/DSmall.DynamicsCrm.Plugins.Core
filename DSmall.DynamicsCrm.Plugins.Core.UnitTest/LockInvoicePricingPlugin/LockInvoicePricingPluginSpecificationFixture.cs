namespace DSmall.DynamicsCrm.Plugins.Core.UnitTest
{
    using System;
    using Microsoft.Xrm.Sdk;

    /// <summary>The lock invoice pricing plugin specification fixture.</summary>
    public class LockInvoicePricingPluginSpecificationFixture : SpecificationFixture<DummyLockInvoicePricingPlugin>
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
                { "InvoiceId", Guid.NewGuid() }
            };
        }
    }
}