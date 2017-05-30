namespace Springboard365.Xrm.Plugins.Core.Test
{
    using Microsoft.Xrm.Sdk;
    using Springboard365.Xrm.UnitTest.Core;

    public class CancelSalesOrderPluginSpecificationFixture : SpecificationFixture<DummyCancelSalesOrderPlugin>
    {
        public override void PerformTestSetup()
        {
            ServiceProvider = ServiceProviderInitializer.Setup().WithInputParameters(GetDummyInputParameters());
        }

        private static ParameterCollection GetDummyInputParameters()
        {
            return new ParameterCollection
            {
                { InputParameterType.OrderClose, new Entity("order") },
                { InputParameterType.Status, new OptionSetValue(1) }
            };
        }
    }
}