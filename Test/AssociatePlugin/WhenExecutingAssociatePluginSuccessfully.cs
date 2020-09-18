﻿namespace Springboard365.Xrm.Plugins.Core.Test
{
    using NUnit.Framework;
    using Springboard365.UnitTest.Xrm.Core;

    [TestFixture]
    public class WhenExecutingAssociatePluginSuccessfully : Specification<DummyAssociatePlugin>
    {
        protected override void Context()
        {
            TestFixture = new AssociatePluginSpecificationFixture();
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
        public void TargetEntityReferenceShouldNotBeNull()
        {
            Assert.IsNotNull(TestFixture.UnderTest.Target);
        }

        [Test]
        public void RelationshipShouldNotBeNull()
        {
            Assert.IsNotNull(TestFixture.UnderTest.Relationship);
        }

        [Test]
        public void RelatedEntitiesShouldNotBeNull()
        {
            Assert.IsNotNull(TestFixture.UnderTest.RelatedEntities);
        }
    }
}