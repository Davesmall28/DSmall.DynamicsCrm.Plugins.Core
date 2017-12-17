namespace Springboard365.Xrm.Plugins.Core.IntegrationTest
{
    using System;
    using Microsoft.Xrm.Sdk;
    using NUnit.Framework;
    using Springboard365.UnitTest.Core;

    [TestFixture]
    public class MergeEntitySpecification : SpecificationBase
    {
        private MergeEntitySpecificationFixture testFixture;

        protected override void Context()
        {
            testFixture = new MergeEntitySpecificationFixture();
            testFixture.PerformTestSetup();
        }

        protected override void BecauseOf()
        {
            testFixture.CrmWriter.Execute(testFixture.RequestId, testFixture.MergeRequest);

            testFixture.Result = Retry.Do(() => testFixture.EntitySerializer.Deserialize(testFixture.RequestId, testFixture.MessageName));
        }

        [Test]
        public void ShouldReturnInputParameterContainingFourParameters()
        {
            Assert.AreEqual(4, testFixture.Result.InputParameters.Count);
        }

        [Test]
        public void ShouldReturnInputParameterContainingUpdateContent()
        {
            Assert.IsTrue(testFixture.Result.InputParameters.OneOf<Entity>("UpdateContent"));
        }

        [Test]
        public void ShouldReturnInputParameterContainingTargetEntity()
        {
            Assert.IsTrue(testFixture.Result.InputParameters.OneOf<EntityReference>("Target"));
        }

        [Test]
        public void ShouldReturnInputParameterContainingSubordinateId()
        {
            Assert.IsTrue(testFixture.Result.InputParameters.OneOf<Guid>("SubordinateId"));
        }

        [Test]
        public void ShouldReturnInputParameterContainingPerformParentingChecks()
        {
            Assert.IsTrue(testFixture.Result.InputParameters.OneOf<bool>("PerformParentingChecks"));
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