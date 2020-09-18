namespace Springboard365.Xrm.Plugins.Core.Test
{
    using NUnit.Framework;
    using Springboard365.UnitTest.Xrm.Core;

    [TestFixture]
    public class WhenExecutingAddItemCampaignActivityPluginSuccessfully : Specification<DummyAddItemCampaignActivityPlugin>
    {
        protected override void Context()
        {
            TestFixture = new AddItemCampaignActivityPluginSpecificationFixture();
            TestFixture.PerformTestSetup();
        }

        protected override void BecauseOf()
        {
            TestFixture.UnderTest.Execute(TestFixture.ServiceProvider.Object);
        }

        [Test]
        public void OrganizationServiceShouldNotBeNull()
        {
            Assert.IsNotNull(TestFixture.UnderTest.OrganizationService);
        }

        [Test]
        public void PluginExecutionContextShouldNotBeNull()
        {
            Assert.IsNotNull(TestFixture.UnderTest.PluginExecutionContext);
        }

        [Test]
        public void TracingServiceShouldNotBeNull()
        {
            Assert.IsNotNull(TestFixture.UnderTest.TracingService);
        }

        [Test]
        public void CampaignActivityIdShouldNotBeNull()
        {
            Assert.IsNotNull(TestFixture.UnderTest.CampaignActivityId);
        }

        [Test]
        public void ItemIdShouldNotBeNull()
        {
            Assert.IsNotNull(TestFixture.UnderTest.ItemId);
        }

        [Test]
        public void EntityNameShouldNotBeNull()
        {
            Assert.IsNotNull(TestFixture.UnderTest.EntityName);
        }
    }
}