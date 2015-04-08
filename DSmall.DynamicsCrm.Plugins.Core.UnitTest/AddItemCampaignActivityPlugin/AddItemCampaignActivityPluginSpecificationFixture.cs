namespace DSmall.DynamicsCrm.Plugins.Core.UnitTest
{
    /// <summary>The add item campaign activity plugin specification fixture.</summary>
    public class AddItemCampaignActivityPluginSpecificationFixture : SpecificationFixture<DummyAddItemCampaignActivityPlugin>
    {
        /// <summary>The perform test setup.</summary>
        public override void PerformTestSetup()
        {
            ServiceProvider = new ServiceProviderInitializer().SetupForAddItemPlugin();
        }
    }
}
