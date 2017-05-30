namespace Springboard365.Xrm.Plugins.Core.Test
{
    using NUnit.Framework;
    using Springboard365.UnitTest.Core;

    [TestFixture]
    public class WhenExecutingTheSetStatePluginSuccessfully : SpecificationBase
    {
        private SetStatePluginSpecificationFixture testFixture;

        protected override void Context()
        {
            testFixture = new SetStatePluginSpecificationFixture();
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
        public void EntityMonikerShouldNotBeNull()
        {
            Assert.IsNotNull(testFixture.UnderTest.EntityMoniker);
        }

        [Test]
        public void StateShouldNotBeNull()
        {
            Assert.IsNotNull(testFixture.UnderTest.State);
        }

        [Test]
        public void StatusShouldNotBeNull()
        {
            Assert.IsNotNull(testFixture.UnderTest.Status);
        }
    }
}
