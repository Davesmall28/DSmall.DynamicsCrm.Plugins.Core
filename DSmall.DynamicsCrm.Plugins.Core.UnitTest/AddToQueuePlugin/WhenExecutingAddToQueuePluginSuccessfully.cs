namespace DSmall.DynamicsCrm.Plugins.Core.UnitTest
{
    using DSmall.UnitTest.Core;
    using NUnit.Framework;

    /// <summary>The when executing add to queue plugin successfully.</summary>
    public class WhenExecutingAddToQueuePluginSuccessfully : SpecificationBase
    {
        private AddToQueueSpecificationFixture testFixture;

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

        /// <summary>The destination queue id should not be null.</summary>
        [Test]
        public void DestinationQueueIdShouldNotBeNull()
        {
            Assert.IsNotNull(testFixture.UnderTest.DestinationQueueId);
        }

        /// <summary>The source queue id should not be null.</summary>
        [Test]
        public void SourceQueueIdShouldNotBeNull()
        {
            Assert.IsNotNull(testFixture.UnderTest.SourceQueueId);
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

            testFixture = new AddToQueueSpecificationFixture();
            testFixture.PerformTestSetup();
        }
    }
}