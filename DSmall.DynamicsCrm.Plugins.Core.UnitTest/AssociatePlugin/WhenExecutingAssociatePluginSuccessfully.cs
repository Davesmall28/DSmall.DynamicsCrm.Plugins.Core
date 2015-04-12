namespace DSmall.DynamicsCrm.Plugins.Core.UnitTest
{
    using DSmall.UnitTest.Core;
    using NUnit.Framework;

    /// <summary>The when executing associate plugin successfully.</summary>
    public class WhenExecutingAssociatePluginSuccessfully : SpecificationBase
    {
        private AssociatePluginSpecificationFixture testFixture;

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

        /// <summary>The target entity reference should not be null.</summary>
        [Test]
        public void TargetEntityReferenceShouldNotBeNull()
        {
            Assert.IsNotNull(testFixture.UnderTest.Target);
        }

        /// <summary>The relationship should not be null.</summary>
        [Test]
        public void RelationshipShouldNotBeNull()
        {
            Assert.IsNotNull(testFixture.UnderTest.Relationship);
        }

        /// <summary>The related entities should not be null.</summary>
        [Test]
        public void RelatedEntitiesShouldNotBeNull()
        {
            Assert.IsNotNull(testFixture.UnderTest.RelatedEntities);
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

            testFixture = new AssociatePluginSpecificationFixture();
            testFixture.PerformTestSetup();
        }
    }
}