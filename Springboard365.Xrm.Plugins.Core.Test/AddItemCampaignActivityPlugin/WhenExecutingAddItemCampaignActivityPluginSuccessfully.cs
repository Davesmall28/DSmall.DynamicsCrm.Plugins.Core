namespace Springboard365.Xrm.Plugins.Core.Test
{
    using NUnit.Framework;
    using Springboard365.UnitTest.Core;

    [TestFixture]
    public class WhenExecutingAddItemCampaignActivityPluginSuccessfully : SpecificationBase
    {
        private AddItemCampaignActivityPluginSpecificationFixture testFixture;

        protected override void Context()
        {
            testFixture = new AddItemCampaignActivityPluginSpecificationFixture();
            testFixture.PerformTestSetup();
        }

        protected override void BecauseOf()
        {
            testFixture.UnderTest.Execute(testFixture.ServiceProvider.Object);
        }

        [Test]
        public void OrganizationServiceShouldNotBeNull()
        {
            Assert.IsNotNull(testFixture.UnderTest.OrganizationService);
        }

        [Test]
        public void PluginExecutionContextShouldNotBeNull()
        {
            Assert.IsNotNull(testFixture.UnderTest.PluginExecutionContext);
        }

        [Test]
        public void TracingServiceShouldNotBeNull()
        {
            Assert.IsNotNull(testFixture.UnderTest.TracingService);
        }

        [Test]
        public void CampaignActivityIdShouldNotBeNull()
        {
            Assert.IsNotNull(testFixture.UnderTest.CampaignActivityId);
        }

        [Test]
        public void ItemIdShouldNotBeNull()
        {
            Assert.IsNotNull(testFixture.UnderTest.ItemId);
        }

        [Test]
        public void EntityNameShouldNotBeNull()
        {
            Assert.IsNotNull(testFixture.UnderTest.EntityName);
        }
    }
}