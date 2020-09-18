namespace Springboard365.Xrm.Plugins.Core.Test
{
    using System;
    using Microsoft.Xrm.Sdk;
    using Springboard365.UnitTest.Xrm.Core;
    using Springboard365.Xrm.Plugins.Core.Constants;
    using Springboard365.Xrm.Plugins.Core.Test.Entities;

    public class WinOrCloseQuotePluginSpecificationFixture : SpecificationFixture<DummyWinOrCloseQuotePlugin>
    {
        public override void PerformTestSetup()
        {
            ServiceProvider = ServiceProviderInitializer.Setup().WithInputParameters(() => new ParameterCollection
            {
                { InputParameterType.QuoteClose, new QuoteClose() { Id = Guid.NewGuid() } },
                { InputParameterType.State, new OptionSetValue(1) },
                { InputParameterType.Status, new OptionSetValue(1) }
            });
        }
    }
}