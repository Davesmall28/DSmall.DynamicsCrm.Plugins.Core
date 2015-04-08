namespace DSmall.DynamicsCrm.Plugins.Core.UnitTest
{
    /// <summary>The set state plugin specification fixture.</summary>
    public class SetStatePluginSpecificationFixture : SpecificationFixture<DummySetStatePlugin>
    {
        /// <summary>The perform test setup.</summary>
        public override void PerformTestSetup()
        {
            var serviceProviderIntializer = new ServiceProviderInitializer();
            ServiceProvider = serviceProviderIntializer.SetupForSetStatePlugin();
        }
    }
}
