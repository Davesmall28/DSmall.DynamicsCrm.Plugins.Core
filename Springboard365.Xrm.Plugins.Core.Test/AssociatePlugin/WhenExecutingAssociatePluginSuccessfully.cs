namespace Springboard365.Xrm.Plugins.Core.Test
{
    using NUnit.Framework;
    using Springboard365.UnitTest.Core;

    public class WhenExecutingAssociatePluginSuccessfully : SpecificationBase
    {
        private AssociatePluginSpecificationFixture testFixture;

        protected override void Context()
        {
            testFixture = new AssociatePluginSpecificationFixture();
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
        public void TargetEntityReferenceShouldNotBeNull()
        {
            Assert.IsNotNull(testFixture.UnderTest.Target);
        }

        [Test]
        public void RelationshipShouldNotBeNull()
        {
            Assert.IsNotNull(testFixture.UnderTest.Relationship);
        }

        [Test]
        public void RelatedEntitiesShouldNotBeNull()
        {
            Assert.IsNotNull(testFixture.UnderTest.RelatedEntities);
        }
    }
}