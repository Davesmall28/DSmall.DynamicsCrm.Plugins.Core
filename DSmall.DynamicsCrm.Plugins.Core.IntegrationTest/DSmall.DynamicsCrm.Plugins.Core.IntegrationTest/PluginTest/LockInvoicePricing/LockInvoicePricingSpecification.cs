namespace DSmall.DynamicsCrm.Plugins.Core.IntegrationTest
{
    using System;
    using DSmall.UnitTest.Core;
    using NUnit.Framework;

    /// <summary>The lock invoice pricing specification.</summary>
    [TestFixture]
    public class LockInvoicePricingSpecification : SpecificationBase
    {
        private LockInvoicePricingSpecificationFixture testFixture;

        /// <summary>The should return input parameters containing one parameter.</summary>
        [Test]
        public void ShouldReturnInputParametersContainingOneParameter()
        {
            Assert.IsTrue(testFixture.Result.InputParameters.One());
        }

        /// <summary>The should return input parameters containing invoice id.</summary>
        [Test]
        public void ShouldReturnInputParametersContainingInvoiceId()
        {
            Assert.IsTrue(testFixture.Result.InputParameters.OneOf<Guid>("InvoiceId"));
        }

        /// <summary>The should return no pre entity images.</summary>
        [Test]
        public void ShouldReturnNoPreEntityImages()
        {
            Assert.IsTrue(testFixture.Result.PreEntityImages.NoParameters());
        }

        /// <summary>The should return no post entity images.</summary>
        [Test]
        public void ShouldReturnNoPostEntityImages()
        {
            Assert.IsTrue(testFixture.Result.PostEntityImages.NoParameters());
        }

        /// <summary>The because of.</summary>
        protected override void BecauseOf()
        {
            testFixture.CrmWriter.Execute(testFixture.RequestId, testFixture.LockInvoicePricingRequest);

            testFixture.Result = Retry.Do(() => testFixture.EntitySerializer.Deserialize(testFixture.RequestId, testFixture.MessageName));
        }

        /// <summary>The context.</summary>
        protected override void Context()
        {
            testFixture = new LockInvoicePricingSpecificationFixture();
            testFixture.PerformTestSetup();
        }
    }
}