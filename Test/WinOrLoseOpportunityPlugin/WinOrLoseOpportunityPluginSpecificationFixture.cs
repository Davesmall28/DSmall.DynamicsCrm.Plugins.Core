namespace Springboard365.Xrm.Plugins.Core.Test
{
    using Microsoft.Xrm.Sdk;
    using Springboard365.UnitTest.Xrm.Core;
    using Springboard365.Xrm.Plugins.Core.Constants;
    using Springboard365.Xrm.Plugins.Core.Test.Entities;

    public class WinOrLoseOpportunityPluginSpecificationFixture : SpecificationFixture<DummyWinOrLoseOpportunityPlugin>
    {
        public override void PerformTestSetup()
        {
            ServiceProvider = ServiceProviderInitializer.Setup().WithInputParameters(() => new ParameterCollection
            {
                { InputParameterType.OpportunityClose, new OpportunityClose() },
                { InputParameterType.State, new OptionSetValue(1) },
                { InputParameterType.Status, new OptionSetValue(1) }
            });
        }
    }
}