namespace Springboard365.Xrm.Plugins.Core.IntegrationTest
{
    using Microsoft.Xrm.Sdk;
    using NUnit.Framework;
    using Springboard365.UnitTest.Core;

    [TestFixture]
    public class DeleteContactSpecification : SpecificationBase
    {
        private DeleteContactSpecificationFixture testFixture;

        protected override void Context()
        {
            testFixture = new DeleteContactSpecificationFixture();
            testFixture.PerformTestSetup();
        }

        protected override void BecauseOf()
        {
            testFixture.CrmWriter.Delete(testFixture.RequestId, testFixture.EntityReferenceToDelete);

            testFixture.Result = Retry.Do(() => testFixture.EntitySerializer.Deserialize(testFixture.RequestId, testFixture.MessageName));
        }

        [Test]
        public void ShouldReturnInputParameterContainingTargetEntityReference()
        {
            Assert.IsTrue(testFixture.Result.InputParameters.OneOf<EntityReference>("Target"));
        }

        [Test]
        public void ShouldReturnPreEntityImageContainingAsynchronousStepPrimaryName()
        {
            Assert.IsTrue(testFixture.Result.PreEntityImages.OneOf<Entity>("AsynchronousStepPrimaryName"));
        }

        [Test]
        public void ShouldReturnNoPostEntityImages()
        {
            Assert.IsTrue(testFixture.Result.PostEntityImages.NoParameters());
        }
    }
}