namespace DSmall.DynamicsCrm.Plugins.Core.IntegrationTest
{
    using Microsoft.Crm.Sdk.Messages;

    /// <summary>The unlock invoice pricing specification fixture.</summary>
    public class UnlockInvoicePricingSpecificationFixture : SpecificationFixtureBase
    {
        /// <summary>Gets the unlock invoice pricing request.</summary>
        public UnlockInvoicePricingRequest UnlockInvoicePricingRequest { get; private set; }

        /// <summary>Gets the message name.</summary>
        public string MessageName { get; private set; }

        /// <summary>The perform test setup.</summary>
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