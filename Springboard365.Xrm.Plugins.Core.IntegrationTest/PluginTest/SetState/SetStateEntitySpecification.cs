namespace Springboard365.Xrm.Plugins.Core.IntegrationTest
{
    using Microsoft.Xrm.Sdk;
    using NUnit.Framework;
    using Springboard365.UnitTest.Core;

    [TestFixture]
    public class SetStateEntitySpecification : SpecificationBase
    {
        private SetStateEntitySpecificationFixture testFixture;

        protected override void Context()
        {
            testFixture = new SetStateEntitySpecificationFixture();
            testFixture.PerformTestSetup();
        }

        protected override void BecauseOf()
        {
            testFixture.CrmWriter.Execute(testFixture.RequestId, testFixture.SetStateRequest);

            testFixture.Result = Retry.Do(() => testFixture.EntitySerializer.Deserialize(testFixture.RequestId, testFixture.MessageName));
        }

        [Test]
        public void ShouldReturnInputParameterContainingThreeParameters()
        {
            Assert.AreEqual(3, testFixture.Result.InputParameters.Count);
        }

        [Test]
        public void ShouldReturnInputParameterContainingEntityMoniker()
        {
            Assert.IsTrue(testFixture.Result.InputParameters.OneOf<EntityReference>("EntityMoniker"));
        }

        [Test]
        public void ShouldReturnInputParameterContainingStateCode()
        {
            Assert.IsTrue(testFixture.Result.InputParameters.OneOf<OptionSetValue>("State"));
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
        public void ShouldReturnOnePostEntityImage()
        {
            Assert.IsTrue(testFixture.Result.PostEntityImages.One());
        }

        [Test]
        public void ShouldReturnPostEntityImageContainingAsynchronousStepPrimaryName()
        {
            Assert.IsTrue(testFixture.Result.PostEntityImages.OneOf<Entity>("AsynchronousStepPrimaryName"));
        }
    }
}