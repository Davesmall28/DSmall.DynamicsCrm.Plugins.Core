namespace Springboard365.Xrm.Plugins.Core.Test
{
    using NUnit.Framework;
    using Springboard365.UnitTest.Core;

    public class WhenExecutingWinOrCloseQuotePluginSuccessfully : SpecificationBase
    {
        private WinOrCloseQuotePluginSpecificationFixture testFixture;

        protected override void Context()
        {
            testFixture = new WinOrCloseQuotePluginSpecificationFixture();
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
        public void QuoteEntityShouldNotBeNull()
        {
            Assert.IsNotNull(testFixture.UnderTest.QuoteClose);
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