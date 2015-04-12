namespace DSmall.DynamicsCrm.Plugins.Core.UnitTest
{
    using Microsoft.Xrm.Sdk;

    /// <summary>The close incident specification fixture.</summary>
    public class CloseIncidentSpecificationFixture : SpecificationFixture<DummyCloseIncidentPlugin>
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
                { "IncidentResolution", new Entity("incidentresolution") },
                { "Status", new OptionSetValue(1) }
            };
        }
    }
}