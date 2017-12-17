namespace Springboard365.Xrm.Plugins.Core.IntegrationTest
{
    using Microsoft.Crm.Sdk.Messages;

    public class UnlockInvoicePricingSpecificationFixture : SpecificationFixtureBase
    {
        public UnlockInvoicePricingRequest UnlockInvoicePricingRequest { get; private set; }

        public UnlockInvoicePricingSpecificationFixture()
            : base("UnlockInvoicePricing")
        {
        }

        public void PerformTestSetup()
        {
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