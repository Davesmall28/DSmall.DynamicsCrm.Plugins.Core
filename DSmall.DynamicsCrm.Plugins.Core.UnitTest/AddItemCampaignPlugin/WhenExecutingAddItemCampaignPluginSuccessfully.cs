namespace DSmall.DynamicsCrm.Plugins.Core.UnitTest
{
    using DSmall.UnitTest.Core;
    using NUnit.Framework;

    /// <summary>The when executing add item campaign plugin successfully.</summary>
    [TestFixture]
    public class WhenExecutingAddItemCampaignPluginSuccessfully : SpecificationBase
    {
        private AddItemCampaignPluginSpecificationFixture testFixture;

        /// <summary>The organization service should not be null.</summary>
        [Test]
        public void OrganizationServiceShouldNotBeNull()
        {
            Assert.IsNotNull(testFixture.UnderTest.OrganizationService);
        }

        /// <summary>The plugin execution context should not be null.</summary>
        [Test]
        public void PluginExecutionContextShouldNotBeNull()
        {
            Assert.IsNotNull(testFixture.UnderTest.PluginExecutionContext);
        }

        /// <summary>The tracing service should not be null.</summary>
        [Test]
        public void TracingServiceShouldNotBeNull()
        {
            Assert.IsNotNull(testFixture.UnderTest.TracingService);
        }

        /// <summary>The campaign id should not be null.</summary>
        [Test]
        public void CampaignIdShouldNotBeNull()
        {
            Assert.IsNotNull(testFixture.UnderTest.CampaignId);
        }

        /// <summary>The entity id should not be null.</summary>
        [Test]
        public void EntityIdShouldNotBeNull()
        {
            Assert.IsNotNull(testFixture.UnderTest.EntityId);
        }

        /// <summary>The entity name should not be null.</summary>
        [Test]
        public void EntityNameShouldNotBeNull()
        {
            Assert.IsNotNull(testFixture.UnderTest.EntityName);
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
