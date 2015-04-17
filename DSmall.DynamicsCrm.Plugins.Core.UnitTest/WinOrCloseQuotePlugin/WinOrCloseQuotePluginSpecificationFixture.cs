namespace DSmall.DynamicsCrm.Plugins.Core.UnitTest
{
    using System;
    using DSmall.DynamicsCrm.UnitTest.Core;
    using Microsoft.Xrm.Sdk;

    /// <summary>The win or close quote plugin specification fixture.</summary>
    public class WinOrCloseQuotePluginSpecificationFixture : SpecificationFixture<DummyWinOrCloseQuotePlugin>
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
                { "QuoteClose", new Entity("quoteclose") { Id = Guid.NewGuid() } },
                { "State", new OptionSetValue(1) },
                { "Status", new OptionSetValue(1) }
            };
        }
    }
}