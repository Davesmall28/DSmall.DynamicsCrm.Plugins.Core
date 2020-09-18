namespace Springboard365.Xrm.Plugins.Core.Test
{
    using System;
    using Microsoft.Xrm.Sdk;
    using Springboard365.UnitTest.Xrm.Core;
    using Springboard365.Xrm.Plugins.Core.Constants;
    using Springboard365.Xrm.Plugins.Core.Test.Entities;

    public class WinQuotePluginSpecificationFixture : SpecificationFixture<DummyWinQuotePlugin>
    {
        public override void PerformTestSetup()
        {
            ServiceProvider = ServiceProviderInitializer.Setup().WithInputParameters(() => new ParameterCollection
            {
                { InputParameterType.QuoteClose, new QuoteClose() { Id = Guid.NewGuid() } },
                { InputParameterType.Status, new OptionSetValue(1) }
            });
        }
    }
}