namespace DSmall.DynamicsCrm.Plugins.Core.IntegrationTest
{
    using Microsoft.Crm.Sdk.Messages;
    using Microsoft.Xrm.Sdk;

    /// <summary>The cancel sales order specification fixture.</summary>
    public class CancelSalesOrderSpecificationFixture : SpecificationFixtureBase
    {
        /// <summary>Gets the cancel sales order request.</summary>
        public CancelSalesOrderRequest CancelSalesOrderRequest { get; private set; }

        /// <summary>Gets the message name.</summary>
        public string MessageName { get; private set; }

        /// <summary>The perform test setup.</summary>
        public void PerformTestSetup()
        {
            MessageName = "Cancel";

            var orderEntity = EntityFactory.CreateSalesOrder();

            var orderCloseEntity = new Entity("orderclose");
            orderCloseEntity["salesorderid"] = orderEntity.ToEntityReference();

            CancelSalesOrderRequest = new CancelSalesOrderRequest
            {
                OrderClose = orderCloseEntity,
                Status = new OptionSetValue(4)
            };
        }
    }
}