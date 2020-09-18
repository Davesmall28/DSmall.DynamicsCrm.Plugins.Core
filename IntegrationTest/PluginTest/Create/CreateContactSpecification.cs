namespace Springboard365.Xrm.Plugins.Core.IntegrationTest
{
    using System;
    using Microsoft.Xrm.Sdk;
    using NUnit.Framework;
    using Springboard365.UnitTest.Core;

    [TestFixture]
    public class CreateContactSpecification : SpecificationBase
    {
        private CreateContactSpecificationFixture testFixture;
        private Guid entityId;

        protected override void Context()
        {
            testFixture = new CreateContactSpecificationFixture();
            testFixture.PerformTestSetup();
        }

        protected override void BecauseOf()
        {
            entityId = testFixture.CrmWriter.Create(testFixture.RequestId, testFixture.EntityToCreate);

            testFixture.Result = Retry.Do(() => testFixture.EntitySerializer.Deserialize(testFixture.RequestId, testFixture.MessageName));
        }

        [Test]
        public void ShouldReturnANonEmptyId()
        {
            Assert.AreNotEqual(Guid.Empty, entityId);
        }

        [Test]
        public void ShouldReturnInputParameterContainingTargetEntity()
        {
            Assert.IsTrue(testFixture.Result.InputParameters.OneOf<Entity>("Target"));
        }

        [Test]
        public void ShouldReturnNoPreEntityImages()
        {
            Assert.IsTrue(testFixture.Result.PreEntityImages.NoParameters());
        }

        [Test]
        public void ShouldReturnPostEntityImageContainingAsynchronousStepPrimaryName()
        {
            Assert.IsTrue(testFixture.Result.PostEntityImages.OneOf<Entity>("AsynchronousStepPrimaryName"));
        }
    }
}