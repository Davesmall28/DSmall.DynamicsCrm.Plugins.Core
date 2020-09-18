namespace Springboard365.Xrm.Plugins.Core.IntegrationTest
{
    using System;
    using NUnit.Framework;
    using Springboard365.UnitTest.Core;

    [TestFixture]
    public class UnlockInvoicePricingSpecification : SpecificationBase
    {
        private UnlockInvoicePricingSpecificationFixture testFixture;

        protected override void Context()
        {
            testFixture = new UnlockInvoicePricingSpecificationFixture();
            testFixture.PerformTestSetup();
        }

        protected override void BecauseOf()
        {
            testFixture.CrmWriter.Execute(testFixture.RequestId, testFixture.UnlockInvoicePricingRequest);

            testFixture.Result = Retry.Do(() => testFixture.EntitySerializer.Deserialize(testFixture.RequestId, testFixture.MessageName));
        }

        [Test]
        public void ShouldReturnInputParametersContainingOneParameter()
        {
            Assert.IsTrue(testFixture.Result.InputParameters.One());
        }

        [Test]
        public void ShouldReturnInputParametersContainingInvoiceId()
        {
            Assert.IsTrue(testFixture.Result.InputParameters.OneOf<Guid>("InvoiceId"));
        }

        [Test]
        public void ShouldReturnNoPreEntityImages()
        {
            Assert.IsTrue(testFixture.Result.PreEntityImages.NoParameters());
        }

        [Test]
        public void ShouldReturnNoPostEntityImages()
        {
            Assert.IsTrue(testFixture.Result.PostEntityImages.NoParameters());
        }
    }
}