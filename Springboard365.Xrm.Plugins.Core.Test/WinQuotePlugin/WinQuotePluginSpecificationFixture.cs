namespace Springboard365.Xrm.Plugins.Core.Test
{
    using System;
    using Microsoft.Xrm.Sdk;
    using Springboard365.Xrm.UnitTest.Core;

    public class WinQuotePluginSpecificationFixture : SpecificationFixture<DummyWinQuotePlugin>
    {
        public override void PerformTestSetup()
        {
            ServiceProvider = ServiceProviderInitializer.Setup().WithInputParameters(GetDummyInputParameters());
        }

        private static ParameterCollection GetDummyInputParameters()
        {
            return new ParameterCollection
            {
                { InputParameterType.QuoteClose, new Entity("quoteclose") { Id = Guid.NewGuid() } },
                { InputParameterType.Status, new OptionSetValue(1) }
            };
        }
    }
}