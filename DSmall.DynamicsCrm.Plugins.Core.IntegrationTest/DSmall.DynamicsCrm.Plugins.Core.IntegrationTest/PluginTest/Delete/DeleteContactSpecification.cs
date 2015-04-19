namespace DSmall.DynamicsCrm.Plugins.Core.IntegrationTest
{
    using System;
    using DSmall.UnitTest.Core;
    using Microsoft.Xrm.Sdk;
    using NUnit.Framework;

    /// <summary>The delete contact specification.</summary>
    [TestFixture]
    public class DeleteContactSpecification : SpecificationBase
    {
        private DeleteContactSpecificationFixture testFixture;
        private Guid requestId;

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
            testFixture.CrmWriter.Delete(requestId, testFixture.EntityReferenceToDelete);

            testFixture.Result = Retry.Do(() => testFixture.EntitySerializer.Deserialize(requestId, testFixture.MessageName));
        }

        /// <summary>The context.</summary>
        protected override void Context()
        {
            testFixture = new DeleteContactSpecificationFixture();
            testFixture.PerformTestSetup();

            requestId = Guid.NewGuid();
        }
    }
}