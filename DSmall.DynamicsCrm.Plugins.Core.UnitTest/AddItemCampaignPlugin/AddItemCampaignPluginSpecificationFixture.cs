namespace DSmall.DynamicsCrm.Plugins.Core.UnitTest
{
    /// <summary>The add item campaign plugin specification fixture.</summary>
    public class AddItemCampaignPluginSpecificationFixture : SpecificationFixture<DummyAddItemCampaignPlugin>
    {
        /// <summary>The perform test setup.</summary>
        public override void PerformTestSetup()
        {
            ServiceProvider = new ServiceProviderInitializer().SetupForAddItemPlugin();
        }
    }
}
