namespace Springboard365.Xrm.Plugins.Core.Test
{
    using Microsoft.Xrm.Sdk;
    using Springboard365.Xrm.UnitTest.Core;

    public class WinOrLoseOpportunityPluginSpecificationFixture : SpecificationFixture<DummyWinOrLoseOpportunityPlugin>
    {
        public override void PerformTestSetup()
        {
            ServiceProvider = ServiceProviderInitializer.Setup().WithInputParameters(() => new ParameterCollection
            {
                { InputParameterType.OpportunityClose, new Entity("opportunityclose") },
                { InputParameterType.State, new OptionSetValue(1) },
                { InputParameterType.Status, new OptionSetValue(1) }
            });
        }
    }
}