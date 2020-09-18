namespace Springboard365.Xrm.Plugins.Core.IntegrationTest
{
    using Microsoft.Crm.Sdk.Messages;

    public class UnlockSalesOrderPricingSpecificationFixture : SpecificationFixtureBase
    {
        public UnlockSalesOrderPricingRequest UnlockSalesOrderPricingRequest { get; private set; }

        public string MessageName { get; private set; }

        public void PerformTestSetup()
        {
            MessageName = "UnlockSalesOrderPricing";

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