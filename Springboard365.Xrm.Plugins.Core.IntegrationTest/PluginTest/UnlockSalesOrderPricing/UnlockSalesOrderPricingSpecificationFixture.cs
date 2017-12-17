namespace Springboard365.Xrm.Plugins.Core.IntegrationTest
{
    using Microsoft.Crm.Sdk.Messages;

    public class UnlockSalesOrderPricingSpecificationFixture : SpecificationFixtureBase
    {
        public UnlockSalesOrderPricingRequest UnlockSalesOrderPricingRequest { get; private set; }

        public UnlockSalesOrderPricingSpecificationFixture()
            : base("UnlockSalesOrderPricing")
        {
        }

        public void PerformTestSetup()
        {
            var salesOrderEntity = EntityFactory.CreateSalesOrder();

            var lockSalesOrderPricingRequest = new LockSalesOrderPricingRequest
            {
                SalesOrderId = salesOrderEntity.Id,
            };

            OrganizationService.Execute(lockSalesOrderPricingRequest);

            UnlockSalesOrderPricingRequest = new UnlockSalesOrderPricingRequest
            {
                SalesOrderId = salesOrderEntity.Id,
            };
        }
    }
}