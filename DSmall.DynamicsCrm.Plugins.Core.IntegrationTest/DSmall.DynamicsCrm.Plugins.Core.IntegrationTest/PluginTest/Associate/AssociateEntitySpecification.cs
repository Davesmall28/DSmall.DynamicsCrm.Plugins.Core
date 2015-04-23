namespace DSmall.DynamicsCrm.Plugins.Core.IntegrationTest
{
    using DSmall.UnitTest.Core;
    using Microsoft.Xrm.Sdk;
    using NUnit.Framework;

    /// <summary>The associate entity specification.</summary>
    [TestFixture]
    public class AssociateEntitySpecification : SpecificationBase
    {
        private AssociateEntitySpecificationFixture testFixture;

        /// <summary>The should return input parameters containing three parameters.</summary>
        [Test]
        public void ShouldReturnInputParametersContainingThreeParameters()
        {
            Assert.IsTrue(testFixture.Result.InputParameters.Count == 3);
        }

        /// <summary>The should return input parameter containing target entity.</summary>
        [Test]
        public void ShouldReturnInputParameterContainingTargetEntity()
        {
            Assert.IsTrue(testFixture.Result.InputParameters.Count("Target", typeof(EntityReference)) == 1);
        }

        /// <summary>The should return input parameter containing relationship.</summary>
        [Test]
        public void ShouldReturnInputParameterContainingRelationship()
        {
            Assert.IsTrue(testFixture.Result.InputParameters.Count("Relationship", typeof(Relationship)) == 1);
        }

        /// <summary>The should return input parameter containing related entities.</summary>
        [Test]
        public void ShouldReturnInputParameterContainingRelatedEntities()
        {
            Assert.IsTrue(testFixture.Result.InputParameters.Count("RelatedEntities", typeof(EntityReferenceCollection)) == 1);
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

        /// <summary>The because of.</summary>
        protected override void BecauseOf()
        {
            testFixture.CrmWriter.Execute(testFixture.RequestId, testFixture.AssociateRequest);

            testFixture.Result = Retry.Do(() => testFixture.EntitySerializer.Deserialize(testFixture.RequestId, testFixture.MessageName));
        }

        /// <summary>The context.</summary>
        protected override void Context()
        {
            testFixture = new AssociateEntitySpecificationFixture();
            testFixture.PerformTestSetup();
        }
    }
}