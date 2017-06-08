namespace Springboard365.Xrm.Plugins.Core.IntegrationTest
{
    using System;
    using Microsoft.Xrm.Sdk;
    using NUnit.Framework;
    using Springboard365.UnitTest.Core;

    [TestFixture]
    public class CloneContractSpecification : SpecificationBase
    {
        private CloneContractSpecificationFixture testFixture;

        protected override void Context()
        {
            testFixture = new CloneContractSpecificationFixture();
            testFixture.PerformTestSetup();
        }

        protected override void BecauseOf()
        {
            testFixture.CrmWriter.Execute(testFixture.RequestId, testFixture.CloneContractRequest);

            testFixture.Result = Retry.Do(() => testFixture.EntitySerializer.Deserialize(testFixture.RequestId, testFixture.MessageName));
        }

        [Test]
        public void ShouldReturnInputParametersContainingTwoParameters()
        {
            Assert.AreEqual(2, testFixture.Result.InputParameters.Count);
        }

        [Test]
        public void ShouldReturnInputParametersContainingContractId()
        {
            Assert.IsTrue(testFixture.Result.InputParameters.OneOf<Guid>("ContractId"));
        }

        [Test]
        public void ShouldReturnInputParametersContainingIncludeCanceledLines()
        {
            Assert.IsTrue(testFixture.Result.InputParameters.OneOf<bool>("IncludeCanceledLines"));
        }

        [Test]
        public void ShouldReturnNoPreEntityImages()
        {
            Assert.IsTrue(testFixture.Result.PreEntityImages.NoParameters());
        }

        [Test]
        public void ShouldReturnPostEntityImagesContainingOneParameter()
        {
            Assert.IsTrue(testFixture.Result.PostEntityImages.One());
        }

        [Test]
        public void ShouldReturnPostEntityImagesContainingAsynchronousStepPrimaryName()
        {
            Assert.IsTrue(testFixture.Result.PostEntityImages.OneOf<Entity>("AsynchronousStepPrimaryName"));
        }
    }
}