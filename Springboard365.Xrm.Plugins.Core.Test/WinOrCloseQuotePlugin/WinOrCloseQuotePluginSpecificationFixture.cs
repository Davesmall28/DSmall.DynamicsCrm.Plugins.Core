namespace Springboard365.Xrm.Plugins.Core.Test
{
    using System;
    using Microsoft.Xrm.Sdk;
    using Springboard365.Xrm.UnitTest.Core;

    public class WinOrCloseQuotePluginSpecificationFixture : SpecificationFixture<DummyWinOrCloseQuotePlugin>
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
                { InputParameterType.State, new OptionSetValue(1) },
                { InputParameterType.Status, new OptionSetValue(1) }
            };
        }
    }
}