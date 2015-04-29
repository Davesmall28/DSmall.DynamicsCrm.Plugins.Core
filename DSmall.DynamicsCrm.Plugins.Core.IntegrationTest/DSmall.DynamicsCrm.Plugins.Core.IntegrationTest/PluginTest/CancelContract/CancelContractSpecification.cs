namespace DSmall.DynamicsCrm.Plugins.Core.IntegrationTest
{
    using System;
    using DSmall.UnitTest.Core;
    using Microsoft.Xrm.Sdk;
    using NUnit.Framework;

    /// <summary>The cancel contract specification.</summary>
    [TestFixture]
    public class CancelContractSpecification : SpecificationBase
    {
        private CancelContractSpecificationFixture testFixture;

        /// <summary>The should return input parameters containing three parameters.</summary>
        [Test]
        public void ShouldReturnInputParametersContainingThreeParameters()
        {
            Assert.IsTrue(testFixture.Result.InputParameters.Count == 3);
        }

        /// <summary>The should return input parameter containing contract id.</summary>
        [Test]
        public void ShouldReturnInputParameterContainingContractId()
        {
            Assert.IsTrue(testFixture.Result.InputParameters.OneOf<Guid>("ContractId"));
        }

        /// <summary>The should return input parameter containing cancel date.</summary>
        [Test]
        public void ShouldReturnInputParameterContainingCancelDate()
        {
            Assert.IsTrue(testFixture.Result.InputParameters.OneOf<DateTime>("CancelDate"));
        }

        /// <summary>The should return input parameter containing status.</summary>
        [Test]
        public void ShouldReturnInputParameterContainingStatus()
        {
            Assert.IsTrue(testFixture.Result.InputParameters.OneOf<OptionSetValue>("Status"));
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
            testFixture.CrmWriter.Execute(testFixture.RequestId, testFixture.CancelContractRequest);

            testFixture.Result = Retry.Do(() => testFixture.EntitySerializer.Deserialize(testFixture.RequestId, testFixture.MessageName));
        }

        /// <summary>The context.</summary>
        protected override void Context()
        {
            testFixture = new CancelContractSpecificationFixture();
            testFixture.PerformTestSetup();
        }
    }
}