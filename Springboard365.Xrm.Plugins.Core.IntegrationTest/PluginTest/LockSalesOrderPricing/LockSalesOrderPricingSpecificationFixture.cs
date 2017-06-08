namespace Springboard365.Xrm.Plugins.Core.IntegrationTest
{
    using Microsoft.Crm.Sdk.Messages;

    public class LockSalesOrderPricingSpecificationFixture : SpecificationFixtureBase
    {
        public LockSalesOrderPricingRequest LockSalesOrderPricingRequest { get; set; }

        public void PerformTestSetup()
        {
            MessageName = "LockSalesOrderPricing";

            var salesOrderEntity = EntityFactory.CreateSalesOrder();

            LockSalesOrderPricingRequest = new LockSalesOrderPricingRequest
            {
                SalesOrderId = salesOrderEntity.Id,
            };
        }
    }
}