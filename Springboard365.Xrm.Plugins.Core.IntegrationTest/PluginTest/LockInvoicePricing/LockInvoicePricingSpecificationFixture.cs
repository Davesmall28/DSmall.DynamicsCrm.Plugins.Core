namespace Springboard365.Xrm.Plugins.Core.IntegrationTest
{
    using Microsoft.Crm.Sdk.Messages;

    public class LockInvoicePricingSpecificationFixture : SpecificationFixtureBase
    {
        public LockInvoicePricingRequest LockInvoicePricingRequest { get; private set; }

        public LockInvoicePricingSpecificationFixture()
            : base("LockInvoicePricing")
        {
        }

        public void PerformTestSetup()
        {
            var invoiceEntity = EntityFactory.CreateInvoice();

            LockInvoicePricingRequest = new LockInvoicePricingRequest
            {
                InvoiceId = invoiceEntity.Id,
            };
        }
    }
}