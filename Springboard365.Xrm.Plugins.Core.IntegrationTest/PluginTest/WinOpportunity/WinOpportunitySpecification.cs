namespace Springboard365.Xrm.Plugins.Core.IntegrationTest
{
    using Microsoft.Xrm.Sdk;
    using NUnit.Framework;
    using Springboard365.UnitTest.Core;

    [TestFixture]
    public class WinOpportunitySpecification : SpecificationBase
    {
        private WinOpportunitySpecificationFixture testFixture;

        protected override void Context()
        {
            testFixture = new WinOpportunitySpecificationFixture();
            testFixture.PerformTestSetup();
        }

        protected override void BecauseOf()
        {
            testFixture.CrmWriter.Execute(testFixture.RequestId, testFixture.WinOpportunityRequest);

            testFixture.Result = Retry.Do(() => testFixture.EntitySerializer.Deserialize(testFixture.RequestId, testFixture.MessageName));
        }

        [Test]
        public void ShouldReturnInputParameterContainingOpportunityCloseEntity()
        {
            Assert.IsTrue(testFixture.Result.InputParameters.OneOf<Entity>("OpportunityClose"));
        }

        [Test]
        public void ShouldReturnInputParameterContainingStatusCode()
        {
            Assert.IsTrue(testFixture.Result.InputParameters.OneOf<OptionSetValue>("Status"));
        }

        [Test]
        public void ShouldReturnInputParameterContainingTwoParameters()
        {
            Assert.IsTrue(testFixture.Result.InputParameters.Count == 2);
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
