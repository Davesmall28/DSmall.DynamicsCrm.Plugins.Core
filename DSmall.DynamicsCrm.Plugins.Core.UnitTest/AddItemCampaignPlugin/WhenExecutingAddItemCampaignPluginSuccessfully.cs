namespace DSmall.DynamicsCrm.Plugins.Core.UnitTest
{
    using DSmall.UnitTest.Core;
    using NUnit.Framework;

    /// <summary>The when executing add item campaign plugin successfully.</summary>
    [TestFixture]
    [Ignore]
    public class WhenExecutingAddItemCampaignPluginSuccessfully : SpecificationBase
    {
        private AddItemCampaignPluginSpecificationFixture testFixture;

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

            testFixture = new AddItemCampaignPluginSpecificationFixture();
            testFixture.PerformTestSetup();
        }
    }
}
