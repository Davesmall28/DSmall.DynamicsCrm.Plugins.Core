namespace DSmall.DynamicsCrm.Plugins.Core.UnitTest
{
    using DSmall.DynamicsCrm.UnitTest.Core;
    using Microsoft.Xrm.Sdk;

    /// <summary>The cancel sales order plugin specification fixture.</summary>
    public class CancelSalesOrderPluginSpecificationFixture : SpecificationFixture<DummyCancelSalesOrderPlugin>
    {
        /// <summary>The perform test setup.</summary>
        public override void PerformTestSetup()
        {
            ServiceProvider = ServiceProviderInitializer.Setup().WithInputParameters(GetDummyInputParameters());
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