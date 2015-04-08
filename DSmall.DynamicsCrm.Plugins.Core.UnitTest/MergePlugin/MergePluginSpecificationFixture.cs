namespace DSmall.DynamicsCrm.Plugins.Core.UnitTest
{
    /// <summary>The merge plugin specification fixture.</summary>
    public class MergePluginSpecificationFixture : SpecificationFixture<DummyMergePlugin>
    {
        /// <summary>The perform test setup.</summary>
        public override void PerformTestSetup()
        {
            var serviceProviderInitializer = new ServiceProviderInitializer();
            ServiceProvider = serviceProviderInitializer.SetupForMergePlugin();
        }
    }
}
