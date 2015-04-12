namespace DSmall.DynamicsCrm.Plugins.Core.UnitTest
{
    using Microsoft.Xrm.Sdk;

    /// <summary>The cancel sales order specification fixture.</summary>
    public class CancelSalesOrderSpecificationFixture : SpecificationFixture<DummyCancelSalesOrderPlugin>
    {
        /// <summary>The perform test setup.</summary>
        public override void PerformTestSetup()
        {
            ServiceProvider = new ServiceProviderInitializer().Setup().WithInputParameters(GetDummyInputParameters());
        }

        private ParameterCollection GetDummyInputParameters()
        {
            return new ParameterCollection
            {
                { "OrderClose", new Entity("order") },
                { "Status", new OptionSetValue(1) }
            };
        }
    }
}