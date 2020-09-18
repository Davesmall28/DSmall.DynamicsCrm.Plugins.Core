namespace Springboard365.Xrm.Plugins.Core.Test
{
    using Springboard365.Xrm.UnitTest.Core;

    public class PluginSpecificationFixture : SpecificationFixture<DummyPlugin>
    {
        public override void PerformTestSetup()
        {
            ServiceProvider = ServiceProviderInitializer.Setup();
        }
    }
}