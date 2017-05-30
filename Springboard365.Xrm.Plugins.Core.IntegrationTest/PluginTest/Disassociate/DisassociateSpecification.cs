namespace Springboard365.Xrm.Plugins.Core.IntegrationTest
{
    using Microsoft.Xrm.Sdk;
    using NUnit.Framework;
    using Springboard365.UnitTest.Core;

    [TestFixture]
    public class DisassociateSpecification : SpecificationBase
    {
        private DisassociateSpecificationFixture testFixture;

        protected override void Context()
        {
            testFixture = new DisassociateSpecificationFixture();
            testFixture.PerformTestSetup();
        }

        protected override void BecauseOf()
        {
            testFixture.CrmWriter.Execute(testFixture.RequestId, testFixture.DisassociateRequest);

            testFixture.Result = Retry.Do(() => testFixture.EntitySerializer.Deserialize(testFixture.RequestId, testFixture.MessageName));
        }

        [Test]
        public void ShouldReturnInputParametersContainingThreeParameters()
        {
            Assert.IsTrue(testFixture.Result.InputParameters.Count == 3);
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