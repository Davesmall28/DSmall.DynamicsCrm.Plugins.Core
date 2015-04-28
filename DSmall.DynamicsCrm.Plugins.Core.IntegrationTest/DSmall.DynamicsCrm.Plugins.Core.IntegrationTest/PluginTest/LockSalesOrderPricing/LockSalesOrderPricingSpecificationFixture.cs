namespace DSmall.DynamicsCrm.Plugins.Core.IntegrationTest
{
    using Microsoft.Crm.Sdk.Messages;

    /// <summary>The lock sales order pricing specification fixture.</summary>
    public class LockSalesOrderPricingSpecificationFixture : SpecificationFixtureBase
    {
        /// <summary>Gets or sets the lock sales order pricing request.</summary>
        public LockSalesOrderPricingRequest LockSalesOrderPricingRequest { get; set; }

        /// <summary>Gets the message name.</summary>
        public string MessageName { get; private set; }

        /// <summary>The perform test setup.</summary>
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