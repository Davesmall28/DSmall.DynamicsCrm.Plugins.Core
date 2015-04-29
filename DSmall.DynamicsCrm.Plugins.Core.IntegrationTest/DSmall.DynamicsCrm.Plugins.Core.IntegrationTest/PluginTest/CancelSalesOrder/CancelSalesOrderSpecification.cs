namespace DSmall.DynamicsCrm.Plugins.Core.IntegrationTest
{
    using DSmall.UnitTest.Core;
    using Microsoft.Xrm.Sdk;
    using NUnit.Framework;

    /// <summary>The cancel sales order specification.</summary>
    [TestFixture]
    public class CancelSalesOrderSpecification : SpecificationBase
    {
        private CancelSalesOrderSpecificationFixture testFixture;

        /// <summary>The should return input parameters containing two parameters.</summary>
        [Test]
        public void ShouldReturnInputParametersContainingTwoParameters()
        {
            Assert.IsTrue(testFixture.Result.InputParameters.Count == 2);
        }

        /// <summary>The should return input parameter containing order close entity.</summary>
        [Test]
        public void ShouldReturnInputParameterContainingOrderCloseEntity()
        {
            Assert.IsTrue(testFixture.Result.InputParameters.OneOf<Entity>("OrderClose"));
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
            testFixture.CrmWriter.Execute(testFixture.RequestId, testFixture.CancelSalesOrderRequest);

            testFixture.Result = Retry.Do(() => testFixture.EntitySerializer.Deserialize(testFixture.RequestId, testFixture.MessageName));
        }

        /// <summary>The context.</summary>
        protected override void Context()
        {
            testFixture = new CancelSalesOrderSpecificationFixture();
            testFixture.PerformTestSetup();
        }
    }
}