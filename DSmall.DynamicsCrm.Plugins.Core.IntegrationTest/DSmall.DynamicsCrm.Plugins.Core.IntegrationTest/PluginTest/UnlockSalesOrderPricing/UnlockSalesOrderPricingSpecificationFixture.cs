namespace DSmall.DynamicsCrm.Plugins.Core.IntegrationTest
{
    using Microsoft.Crm.Sdk.Messages;

    /// <summary>The unlock sales order pricing specification fixture.</summary>
    public class UnlockSalesOrderPricingSpecificationFixture : SpecificationFixtureBase
    {
        /// <summary>Gets the unlock sales order pricing request.</summary>
        public UnlockSalesOrderPricingRequest UnlockSalesOrderPricingRequest { get; private set; }

        /// <summary>Gets the message name.</summary>
        public string MessageName { get; private set; }

        /// <summary>The perform test setup.</summary>
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