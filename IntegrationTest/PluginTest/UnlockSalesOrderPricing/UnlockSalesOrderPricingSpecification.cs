namespace Springboard365.Xrm.Plugins.Core.IntegrationTest
{
    using System;
    using NUnit.Framework;
    using Springboard365.UnitTest.Core;

    [TestFixture]
    public class UnlockSalesOrderPricingSpecification : SpecificationBase
    {
        private UnlockSalesOrderPricingSpecificationFixture testFixture;

        protected override void Context()
        {
            testFixture = new UnlockSalesOrderPricingSpecificationFixture();
            testFixture.PerformTestSetup();
        }

        protected override void BecauseOf()
        {
            testFixture.CrmWriter.Execute(testFixture.RequestId, testFixture.UnlockSalesOrderPricingRequest);

            testFixture.Result = Retry.Do(() => testFixture.EntitySerializer.Deserialize(testFixture.RequestId, testFixture.MessageName));
        }

        [Test]
        public void ShouldReturnInputParametersContainingOneParameter()
        {
            Assert.IsTrue(testFixture.Result.InputParameters.One());
        }

        [Test]
        public void ShouldReturnInputParametersContainingSalesOrderId()
        {
            Assert.IsTrue(testFixture.Result.InputParameters.OneOf<Guid>("SalesOrderId"));
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