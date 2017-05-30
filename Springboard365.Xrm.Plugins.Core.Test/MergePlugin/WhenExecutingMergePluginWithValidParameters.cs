namespace Springboard365.Xrm.Plugins.Core.Test
{
    using NUnit.Framework;
    using Springboard365.UnitTest.Core;

    [TestFixture]
    public class WhenExecutingMergePluginWithValidParameters : SpecificationBase
    {
        private MergePluginSpecificationFixture testFixture;

        protected override void Context()
        {
            testFixture = new MergePluginSpecificationFixture();
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
            Assert.IsNotNull(testFixture.UnderTest.TargetEntity);
        }

        [Test]
        public void SubordinatedIdShouldNotBeNull()
        {
            Assert.IsNotNull(testFixture.UnderTest.SubordinateId);
        }

        [Test]
        public void UpdateContentShouldNotBeNull()
        {
            Assert.IsNotNull(testFixture.UnderTest.UpdateContent);
        }
    }
}
