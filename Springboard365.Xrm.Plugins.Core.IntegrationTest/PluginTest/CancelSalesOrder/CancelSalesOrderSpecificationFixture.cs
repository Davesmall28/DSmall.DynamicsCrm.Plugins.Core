namespace Springboard365.Xrm.Plugins.Core.IntegrationTest
{
    using Microsoft.Crm.Sdk.Messages;
    using Microsoft.Xrm.Sdk;

    public class CancelSalesOrderSpecificationFixture : SpecificationFixtureBase
    {
        public CancelSalesOrderRequest CancelSalesOrderRequest { get; private set; }

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