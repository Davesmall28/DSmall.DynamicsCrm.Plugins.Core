namespace DSmall.DynamicsCrm.Plugins.Core.IntegrationTest
{
    using System;
    using DSmall.UnitTest.Core;
    using NUnit.Framework;

    /// <summary>The unlock invoice pricing specification.</summary>
    [TestFixture]
    public class UnlockInvoicePricingSpecification : SpecificationBase
    {
        private UnlockInvoicePricingSpecificationFixture testFixture;

        /// <summary>The should return input parameters containing one parameter.</summary>
        [Test]
        public void ShouldReturnInputParametersContainingOneParameter()
        {
            Assert.IsTrue(testFixture.Result.InputParameters.Count == 1);
        }

        /// <summary>The should return input parameters containing invoice id.</summary>
        [Test]
        public void ShouldReturnInputParametersContainingInvoiceId()
        {
            Assert.IsTrue(testFixture.Result.InputParameters.Count("InvoiceId", typeof(Guid)) == 1);
        }

        /// <summary>The should return no pre entity images.</summary>
        [Test]
        public void ShouldReturnNoPreEntityImages()
        {
            Assert.IsTrue(testFixture.Result.PreEntityImages.Count == 0);
        }

        /// <summary>The should return no post entity images.</summary>
        [Test]
        public void ShouldReturnNoPostEntityImages()
        {
            Assert.IsTrue(testFixture.Result.PostEntityImages.Count == 0);
        }

        /// <summary>The because of.</summary>
        protected override void BecauseOf()
        {
            testFixture.CrmWriter.Execute(testFixture.RequestId, testFixture.UnlockInvoicePricingRequest);

            testFixture.Result = Retry.Do(() => testFixture.EntitySerializer.Deserialize(testFixture.RequestId, testFixture.MessageName));
        }

        /// <summary>The context.</summary>
        protected override void Context()
        {
            testFixture = new UnlockInvoicePricingSpecificationFixture();
            testFixture.PerformTestSetup();
        }
    }
}