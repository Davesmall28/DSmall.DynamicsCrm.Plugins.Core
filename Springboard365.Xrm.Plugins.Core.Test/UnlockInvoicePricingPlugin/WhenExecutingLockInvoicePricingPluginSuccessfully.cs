namespace Springboard365.Xrm.Plugins.Core.Test
{
    using NUnit.Framework;
    using Springboard365.Xrm.UnitTest.Core;

    [TestFixture]
    public class WhenExecutingUnlockInvoicePricingPluginSuccessfully : Specification<DummyUnlockInvoicePricingPlugin>
    {
        protected override void Context()
        {
            TestFixture = new UnlockInvoicePricingPluginSpecificationFixture();
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
        public void InvoiceIdShouldNotBeNull()
        {
            Assert.IsNotNull(TestFixture.UnderTest.InvoiceId);
        }
    }
}