namespace DSmall.DynamicsCrm.Plugins.Core.IntegrationTest
{
    using DSmall.UnitTest.Core;
    using Microsoft.Xrm.Sdk;
    using NUnit.Framework;

    /// <summary>The win opportunity specifications.</summary>
    [TestFixture]
    public class WinOpportunitySpecifications : SpecificationBase
    {
        private WinOpportunitySpecificationFixture testFixture;

        /// <summary>The should return input parameter containing opportunity close entity.</summary>
        [Test]
        public void ShouldReturnInputParameterContainingOpportunityCloseEntity()
        {
            Assert.IsTrue(testFixture.Result.InputParameters.Count("OpportunityClose", typeof(Entity)) == 1);
        }

        /// <summary>The should return input parameter containing status code.</summary>
        [Test]
        public void ShouldReturnInputParameterContainingStatusCode()
        {
            Assert.IsTrue(testFixture.Result.InputParameters.Count("Status", typeof(OptionSetValue)) == 1);
        }

        /// <summary>The should return input parameter containing two parameters.</summary>
        [Test]
        public void ShouldReturnInputParameterContainingTwoParameters()
        {
            Assert.IsTrue(testFixture.Result.InputParameters.Count == 2);
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

        /// <summary>The should return post entity image containing one parameter.</summary>
        public void ShouldReturnPostEntityImageContainingOneParameter()
        {
            Assert.IsTrue(testFixture.Result.InputParameters.Count == 1);
        }

        /// <summary>The because of.</summary>
        protected override void BecauseOf()
        {
            base.BecauseOf();

            testFixture.CrmWriter.Execute(testFixture.RequestId, testFixture.WinOpportunityRequest);

            testFixture.Result = Retry.Do(() => testFixture.EntitySerializer.Deserialize(testFixture.RequestId));
        }

        /// <summary>The context.</summary>
        protected override void Context()
        {
            base.Context();

            testFixture = new WinOpportunitySpecificationFixture();
            testFixture.PerformTestSetup();
        }
    }
}
