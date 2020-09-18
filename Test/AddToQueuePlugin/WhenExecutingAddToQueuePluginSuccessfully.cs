namespace Springboard365.Xrm.Plugins.Core.Test
{
    using NUnit.Framework;
    using Springboard365.Xrm.UnitTest.Core;

    [TestFixture]
    public class WhenExecutingAddToQueuePluginSuccessfully : Specification<DummyAddToQueuePlugin>
    {
        protected override void Context()
        {
            TestFixture = new AddToQueuePluginSpecificationFixture();
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
        public void DestinationQueueIdShouldNotBeNull()
        {
            Assert.IsNotNull(TestFixture.UnderTest.DestinationQueueId);
        }

        [Test]
        public void SourceQueueIdShouldNotBeNull()
        {
            Assert.IsNotNull(TestFixture.UnderTest.SourceQueueId);
        }
    }
}