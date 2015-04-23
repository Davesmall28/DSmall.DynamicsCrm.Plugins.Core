namespace DSmall.DynamicsCrm.Plugins.Core.IntegrationTest
{
    using DSmall.UnitTest.Core;
    using Microsoft.Xrm.Sdk;
    using NUnit.Framework;

    /// <summary>The delete contact specification.</summary>
    [TestFixture]
    public class DeleteContactSpecification : SpecificationBase
    {
        private DeleteContactSpecificationFixture testFixture;

        /// <summary>The should return input parameter containing target entity reference.</summary>
        [Test]
        public void ShouldReturnInputParameterContainingTargetEntityReference()
        {
            Assert.IsTrue(testFixture.Result.InputParameters.Count("Target", typeof(EntityReference)) == 1);
        }

        /// <summary>The should return pre entity image containing asynchronous step primary name.</summary>
        [Test]
        public void ShouldReturnPreEntityImageContainingAsynchronousStepPrimaryName()
        {
            Assert.IsTrue(testFixture.Result.PreEntityImages.Count("AsynchronousStepPrimaryName", typeof(Entity)) == 1);
        }

        /// <summary>The should return no post entity images.</summary>
        [Test]
        public void ShouldReturnNoPostEntityImages()
        {
            Assert.IsTrue(testFixture.Result.PostEntityImages.Count == 0);
        }

        /// <summary>The because of.</summary>
        protected override void BecauseOf()
        {
            testFixture.CrmWriter.Delete(testFixture.RequestId, testFixture.EntityReferenceToDelete);

            testFixture.Result = Retry.Do(() => testFixture.EntitySerializer.Deserialize(testFixture.RequestId, testFixture.MessageName));
        }

        /// <summary>The context.</summary>
        protected override void Context()
        {
            testFixture = new DeleteContactSpecificationFixture();
            testFixture.PerformTestSetup();
        }
    }
}