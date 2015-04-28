namespace DSmall.DynamicsCrm.Plugins.Core.IntegrationTest
{
    using Microsoft.Crm.Sdk.Messages;

    /// <summary>The lock invoice pricing specification fixture.</summary>
    public class LockInvoicePricingSpecificationFixture : SpecificationFixtureBase
    {
        /// <summary>Gets the lock invoice pricing request.</summary>
        public LockInvoicePricingRequest LockInvoicePricingRequest { get; private set; }

        /// <summary>Gets the message name.</summary>
        public string MessageName { get; private set; }

        /// <summary>The perform test setup.</summary>
        public void PerformTestSetup()
        {
            MessageName = "LockInvoicePricing";

            var invoiceEntity = EntityFactory.CreateInvoice();

            LockInvoicePricingRequest = new LockInvoicePricingRequest
            {
                InvoiceId = invoiceEntity.Id,
            };
        }
    }
}