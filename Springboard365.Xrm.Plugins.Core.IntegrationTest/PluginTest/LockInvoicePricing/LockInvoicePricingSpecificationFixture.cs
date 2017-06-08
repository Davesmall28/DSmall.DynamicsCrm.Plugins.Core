namespace Springboard365.Xrm.Plugins.Core.IntegrationTest
{
    using Microsoft.Crm.Sdk.Messages;

    public class LockInvoicePricingSpecificationFixture : SpecificationFixtureBase
    {
        public LockInvoicePricingRequest LockInvoicePricingRequest { get; private set; }

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