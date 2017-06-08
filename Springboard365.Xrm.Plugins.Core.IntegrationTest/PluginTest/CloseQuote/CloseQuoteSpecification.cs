namespace Springboard365.Xrm.Plugins.Core.IntegrationTest
{
    using Microsoft.Xrm.Sdk;
    using NUnit.Framework;
    using Springboard365.UnitTest.Core;

    [TestFixture]
    public class CloseQuoteSpecification : SpecificationBase
    {
        private CloseQuoteSpecificationFixture testFixture;

        protected override void Context()
        {
            testFixture = new CloseQuoteSpecificationFixture();
            testFixture.PerformTestSetup();
        }

        protected override void BecauseOf()
        {
            testFixture.CrmWriter.Execute(testFixture.RequestId, testFixture.CloseQuoteRequest);

            testFixture.Result = Retry.Do(() => testFixture.EntitySerializer.Deserialize(testFixture.RequestId, testFixture.MessageName));
        }

        [Test]
        public void ShouldReturnInputParametersContainingTwoParameters()
        {
            Assert.AreEqual(2, testFixture.Result.InputParameters.Count);
        }

        [Test]
        public void ShouldReturnInputParameterContainingQuoteCloseEntity()
        {
            Assert.IsTrue(testFixture.Result.InputParameters.OneOf<Entity>("QuoteClose"));
        }

        [Test]
        public void ShouldReturnInputParameterContainingStatusCode()
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