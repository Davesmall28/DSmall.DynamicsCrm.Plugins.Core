namespace DSmall.DynamicsCrm.Plugins.Core.UnitTest
{
    using System;
    using Microsoft.Xrm.Sdk;

    /// <summary>The win quote plugin specification fixture.</summary>
    public class WinQuotePluginSpecificationFixture : SpecificationFixture<DummyWinQuotePlugin>
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
                { "QuoteClose", new Entity("quoteclose") { Id = Guid.NewGuid() } },
                { "Status", new OptionSetValue(1) }
            };
        }
    }
}