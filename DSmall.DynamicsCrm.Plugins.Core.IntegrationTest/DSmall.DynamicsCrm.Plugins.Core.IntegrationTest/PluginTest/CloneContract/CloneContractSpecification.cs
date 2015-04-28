namespace DSmall.DynamicsCrm.Plugins.Core.IntegrationTest
{
    using System;
    using DSmall.UnitTest.Core;
    using Microsoft.Xrm.Sdk;
    using NUnit.Framework;

    /// <summary>The clone contract specification.</summary>
    [TestFixture]
    public class CloneContractSpecification : SpecificationBase
    {
        private CloneContractSpecificationFixture testFixture;

        /// <summary>The should return input parameters containing two parameters.</summary>
        [Test]
        public void ShouldReturnInputParametersContainingTwoParameters()
        {
            Assert.IsTrue(testFixture.Result.InputParameters.Count == 2);
        }

        /// <summary>The should return input parameters containing contract id.</summary>
        [Test]
        public void ShouldReturnInputParametersContainingContractId()
        {
            Assert.IsTrue(testFixture.Result.InputParameters.Count("ContractId", typeof(Guid)) == 1);
        }

        /// <summary>The should return input parameters containing include canceled lines.</summary>
        [Test]
        public void ShouldReturnInputParametersContainingIncludeCanceledLines()
        {
            Assert.IsTrue(testFixture.Result.InputParameters.Count("IncludeCanceledLines", typeof(bool)) == 1);
        }

        /// <summary>The should return no pre entity images.</summary>
        [Test]
        public void ShouldReturnNoPreEntityImages()
        {
            Assert.IsTrue(testFixture.Result.PreEntityImages.Count == 0);
        }

        /// <summary>The should return post entity images containing one parameter.</summary>
        [Test]
        public void ShouldReturnPostEntityImagesContainingOneParameter()
        {
            Assert.IsTrue(testFixture.Result.PostEntityImages.Count == 1);
        }

        /// <summary>The should return post entity images containing asynchronous step primary name.</summary>
        [Test]
        public void ShouldReturnPostEntityImagesContainingAsynchronousStepPrimaryName()
        {
            Assert.IsTrue(testFixture.Result.PostEntityImages.Count("AsynchronousStepPrimaryName", typeof(Entity)) == 1);
        }

        /// <summary>The because of.</summary>
        protected override void BecauseOf()
        {
            testFixture.CrmWriter.Execute(testFixture.RequestId, testFixture.CloneContractRequest);

            testFixture.Result = Retry.Do(() => testFixture.EntitySerializer.Deserialize(testFixture.RequestId, testFixture.MessageName));
        }

        /// <summary>The context.</summary>
        protected override void Context()
        {
            testFixture = new CloneContractSpecificationFixture();
            testFixture.PerformTestSetup();
        }
    }
}