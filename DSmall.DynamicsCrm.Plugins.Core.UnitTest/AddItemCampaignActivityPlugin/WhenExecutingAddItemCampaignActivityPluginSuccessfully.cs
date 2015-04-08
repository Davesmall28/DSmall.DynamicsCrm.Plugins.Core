namespace DSmall.DynamicsCrm.Plugins.Core.UnitTest
{
    using DSmall.UnitTest.Core;
    using NUnit.Framework;

    /// <summary>The when executing add item campaign activity plugin successfully.</summary>
    [TestFixture]
    [Ignore]
    public class WhenExecutingAddItemCampaignActivityPluginSuccessfully : SpecificationBase
    {
        private AddItemCampaignActivityPluginSpecificationFixture testFixture;

        /// <summary>The should.</summary>
        [Test]
        public void Should()
        {
        }

        /// <summary>The because of.</summary>
        protected override void BecauseOf()
        {
            base.BecauseOf();

            testFixture.UnderTest.Execute(testFixture.ServiceProvider.Object);
        }

        /// <summary>The context.</summary>
        protected override void Context()
        {
            base.Context();

            testFixture = new AddItemCampaignActivityPluginSpecificationFixture();
            testFixture.PerformTestSetup();
        }
    }
}
