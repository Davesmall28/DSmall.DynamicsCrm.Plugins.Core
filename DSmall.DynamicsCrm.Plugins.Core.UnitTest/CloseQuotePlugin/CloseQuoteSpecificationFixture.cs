namespace DSmall.DynamicsCrm.Plugins.Core.UnitTest
{
    using Microsoft.Xrm.Sdk;

    /// <summary>The close quote specification fixture.</summary>
    public class CloseQuoteSpecificationFixture : SpecificationFixture<DummyCloseQuotePlugin>
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
                { "QuoteClose", new Entity("quoteclose") },
                { "Status", new OptionSetValue(1) }
            };
        }
    }
}