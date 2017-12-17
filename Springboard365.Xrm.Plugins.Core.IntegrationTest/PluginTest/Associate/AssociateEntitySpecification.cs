namespace Springboard365.Xrm.Plugins.Core.IntegrationTest
{
    using Microsoft.Xrm.Sdk;
    using NUnit.Framework;
    using Springboard365.UnitTest.Core;

    [TestFixture]
    public class AssociateEntitySpecification : SpecificationBase
    {
        private AssociateEntitySpecificationFixture testFixture;

        protected override void Context()
        {
            testFixture = new AssociateEntitySpecificationFixture();
            testFixture.PerformTestSetup();
        }

        protected override void BecauseOf()
        {
            testFixture.CrmWriter.Execute(testFixture.RequestId, testFixture.AssociateRequest);

            testFixture.Result = Retry.Do(() => testFixture.EntitySerializer.Deserialize(testFixture.RequestId, testFixture.MessageName));
        }

        [Test]
        public void ShouldReturnInputParametersContainingThreeParameters()
        {
            Assert.AreEqual(3, testFixture.Result.InputParameters.Count);
        }

        [Test]
        public void ShouldReturnInputParameterContainingTargetEntity()
        {
            Assert.IsTrue(testFixture.Result.InputParameters.OneOf<EntityReference>("Target"));
        }

        [Test]
        public void ShouldReturnInputParameterContainingRelationship()
        {
            Assert.IsTrue(testFixture.Result.InputParameters.OneOf<Relationship>("Relationship"));
        }

        [Test]
        public void ShouldReturnInputParameterContainingRelatedEntities()
        {
            Assert.IsTrue(testFixture.Result.InputParameters.OneOf<EntityReferenceCollection>("RelatedEntities"));
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