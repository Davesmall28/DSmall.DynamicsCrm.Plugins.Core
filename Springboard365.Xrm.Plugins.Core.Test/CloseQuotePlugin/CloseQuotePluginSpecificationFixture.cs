namespace Springboard365.Xrm.Plugins.Core.Test
{
    using Microsoft.Xrm.Sdk;
    using Springboard365.Xrm.UnitTest.Core;

    public class CloseQuotePluginSpecificationFixture : SpecificationFixture<DummyCloseQuotePlugin>
    {
        public override void PerformTestSetup()
        {
            ServiceProvider = ServiceProviderInitializer.Setup().WithInputParameters(GetDummyInputParameters());
        }

        private static ParameterCollection GetDummyInputParameters()
        {
            return new ParameterCollection
            {
                { InputParameterType.QuoteClose, new Entity("quoteclose") },
                { InputParameterType.Status, new OptionSetValue(1) }
            };
        }
    }
}