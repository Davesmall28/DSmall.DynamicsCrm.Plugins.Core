namespace DSmall.DynamicsCrm.Plugins.Core.UnitTest
{
    using DSmall.DynamicsCrm.UnitTest.Core;
    using Microsoft.Xrm.Sdk;

    /// <summary>The win opportunity plugin specification fixture.</summary>
    public class WinOpportunityPluginSpecificationFixture : SpecificationFixture<DummyWinOpportunityPlugin>
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
                { "Status", new OptionSetValue(1) }
            };
        }
    }
}