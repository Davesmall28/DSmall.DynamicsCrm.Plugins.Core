namespace Springboard365.Xrm.Plugins.Core.Test
{
    using NUnit.Framework;
    using Springboard365.UnitTest.Core;
    using Springboard365.Xrm.UnitTest.Core;

    [TestFixture]
    public class WhenExecutingWithValidParameters : SpecificationBase
    {
        private SpecificationFixture<DummyPlugin> testFixture;

        protected override void Context()
        {
            testFixture = new SpecificationFixture<DummyPlugin>();
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
    }
}