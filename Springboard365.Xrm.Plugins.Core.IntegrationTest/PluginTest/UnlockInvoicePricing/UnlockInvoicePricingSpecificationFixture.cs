namespace Springboard365.Xrm.Plugins.Core.IntegrationTest
{
    using Microsoft.Crm.Sdk.Messages;

    public class UnlockInvoicePricingSpecificationFixture : SpecificationFixtureBase
    {
        public UnlockInvoicePricingRequest UnlockInvoicePricingRequest { get; private set; }

        public string MessageName { get; private set; }

        public void PerformTestSetup()
        {
            MessageName = "UnlockInvoicePricing";

            var invoiceEntity = EntityFactory.CreateInvoice();

            var lockInvoicePricingRequest = new LockInvoicePricingRequest
            {
                InvoiceId = invoiceEntity.Id,
            };

            OrganizationService.Execute(lockInvoicePricingRequest);

            UnlockInvoicePricingRequest = new UnlockInvoicePricingRequest
            {
                InvoiceId = invoiceEntity.Id,
            };
        }
    }
}