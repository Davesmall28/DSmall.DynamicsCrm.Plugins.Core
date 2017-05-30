namespace Springboard365.Xrm.Plugins.Core.Test
{
    using NUnit.Framework;
    using Springboard365.UnitTest.Core;

    public class WhenExecutingDisassociatePluginSuccessfully : SpecificationBase
    {
        private DisassociatePluginSpecificationFixture testFixture;

        protected override void Context()
        {
            testFixture = new DisassociatePluginSpecificationFixture();
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
        public void TargetEntityShouldNotBeNull()
        {
            Assert.IsNotNull(testFixture.UnderTest.Target);
        }

        [Test]
        public void RelatedEntitiesShouldNotBeNull()
        {
            Assert.IsNotNull(testFixture.UnderTest.RelatedEntities);
        }

        [Test]
        public void RelationshipShouldNotBeNull()
        {
            Assert.IsNotNull(testFixture.UnderTest.Relationship);
        }
    }
}