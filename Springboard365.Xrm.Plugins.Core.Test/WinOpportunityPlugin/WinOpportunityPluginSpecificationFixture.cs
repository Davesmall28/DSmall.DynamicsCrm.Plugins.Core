namespace Springboard365.Xrm.Plugins.Core.Test
{
    using Microsoft.Xrm.Sdk;
    using Springboard365.Xrm.UnitTest.Core;

    public class WinOpportunityPluginSpecificationFixture : SpecificationFixture<DummyWinOpportunityPlugin>
    {
        public override void PerformTestSetup()
        {
            ServiceProvider = ServiceProviderInitializer.Setup().WithInputParameters(() => new ParameterCollection
            {
                { InputParameterType.OpportunityClose, new Entity("opportunityclose") },
                { InputParameterType.Status, new OptionSetValue(1) }
            });
        }
    }
}