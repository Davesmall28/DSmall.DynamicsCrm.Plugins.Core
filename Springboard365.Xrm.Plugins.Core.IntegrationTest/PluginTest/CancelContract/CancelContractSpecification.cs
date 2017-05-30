namespace Springboard365.Xrm.Plugins.Core.IntegrationTest
{
    using System;
    using Microsoft.Xrm.Sdk;
    using NUnit.Framework;
    using Springboard365.UnitTest.Core;

    [TestFixture]
    public class CancelContractSpecification : SpecificationBase
    {
        private CancelContractSpecificationFixture testFixture;

        protected override void Context()
        {
            testFixture = new CancelContractSpecificationFixture();
            testFixture.PerformTestSetup();
        }

        protected override void BecauseOf()
        {
            testFixture.CrmWriter.Execute(testFixture.RequestId, testFixture.CancelContractRequest);

            testFixture.Result = Retry.Do(() => testFixture.EntitySerializer.Deserialize(testFixture.RequestId, testFixture.MessageName));
        }

        [Test]
        public void ShouldReturnInputParametersContainingThreeParameters()
        {
            Assert.IsTrue(testFixture.Result.InputParameters.Count == 3);
        }

        [Test]
        public void ShouldReturnInputParameterContainingContractId()
        {
            Assert.IsTrue(testFixture.Result.InputParameters.OneOf<Guid>("ContractId"));
        }

        [Test]
        public void ShouldReturnInputParameterContainingCancelDate()
        {
            Assert.IsTrue(testFixture.Result.InputParameters.OneOf<DateTime>("CancelDate"));
        }

        [Test]
        public void ShouldReturnInputParameterContainingStatus()
        {
            Assert.IsTrue(testFixture.Result.InputParameters.OneOf<OptionSetValue>("Status"));
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