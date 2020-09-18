namespace Springboard365.Xrm.Plugins.Core.Test
{
    using Microsoft.Xrm.Sdk;
    using Springboard365.Xrm.Plugins.Core.Constants;
    using Springboard365.Xrm.Plugins.Core.Test.Entities;
    using Springboard365.Xrm.UnitTest.Core;

    public class CloseIncidentPluginSpecificationFixture : SpecificationFixture<DummyCloseIncidentPlugin>
    {
        public override void PerformTestSetup()
        {
            ServiceProvider = ServiceProviderInitializer.Setup().WithInputParameters(() => new ParameterCollection
            {
                { InputParameterType.IncidentResolution, new IncidentResolution() },
                { InputParameterType.Status, new OptionSetValue(1) }
            });
        }
    }
}