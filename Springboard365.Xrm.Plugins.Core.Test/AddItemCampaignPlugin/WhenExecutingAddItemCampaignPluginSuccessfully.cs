namespace Springboard365.Xrm.Plugins.Core.Test
{
    using NUnit.Framework;
    using Springboard365.UnitTest.Core;

    [TestFixture]
    public class WhenExecutingAddItemCampaignPluginSuccessfully : SpecificationBase
    {
        private AddItemCampaignPluginSpecificationFixture testFixture;

        protected override void Context()
        {
            testFixture = new AddItemCampaignPluginSpecificationFixture();
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
        public void CampaignIdShouldNotBeNull()
        {
            Assert.IsNotNull(testFixture.UnderTest.CampaignId);
        }

        [Test]
        public void EntityIdShouldNotBeNull()
        {
            Assert.IsNotNull(testFixture.UnderTest.EntityId);
        }

        [Test]
        public void EntityNameShouldNotBeNull()
        {
            Assert.IsNotNull(testFixture.UnderTest.EntityName);
        }
    }
}
