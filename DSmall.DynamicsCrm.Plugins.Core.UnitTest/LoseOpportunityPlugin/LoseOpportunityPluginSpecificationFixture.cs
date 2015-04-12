namespace DSmall.DynamicsCrm.Plugins.Core.UnitTest
{
    using Microsoft.Xrm.Sdk;

    /// <summary>The lose opportunity plugin specification fixture.</summary>
    public class LoseOpportunityPluginSpecificationFixture : SpecificationFixture<DummyLoseOpportunityPlugin>
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
                { "OpportunityClose", new Entity("opportunityclose") },
                { "Status", new OptionSetValue(1) }
            };
        }
    }
}