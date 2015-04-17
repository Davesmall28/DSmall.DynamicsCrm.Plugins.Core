namespace DSmall.DynamicsCrm.Plugins.Core.UnitTest
{
    using DSmall.DynamicsCrm.UnitTest.Core;
    using Microsoft.Xrm.Sdk;

    /// <summary>The win or lose opportunity plugin specification fixture.</summary>
    public class WinOrLoseOpportunityPluginSpecificationFixture : SpecificationFixture<DummyWinOrLoseOpportunityPlugin>
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
                { "OpportunityClose", new Entity("opportunityclose") },
                { "State", new OptionSetValue(1) },
                { "Status", new OptionSetValue(1) }
            };
        }
    }
}