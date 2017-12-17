namespace Springboard365.Xrm.Plugins.Core.IntegrationTest
{
    using Microsoft.Xrm.Sdk;
    using NUnit.Framework;
    using Springboard365.UnitTest.Core;

    [TestFixture]
    public class AssignEntitySpecification : SpecificationBase
    {
        private AssignEntitySpecificationFixture testFixture;

        protected override void Context()
        {
            testFixture = new AssignEntitySpecificationFixture();
            testFixture.PerformTestSetup();
        }

        protected override void BecauseOf()
        {
            testFixture.CrmWriter.Execute(testFixture.RequestId, testFixture.AssignRequest);

            testFixture.Result = Retry.Do(() => testFixture.EntitySerializer.Deserialize(testFixture.RequestId, testFixture.MessageName));
        }

        [Test]
        public void ShouldReturnInputParameterContainingTwoParameters()
        {
            Assert.AreEqual(2, testFixture.Result.InputParameters.Count);
        }

        [Test]
        public void ShouldReturnInputParameterContainingTargetEntity()
        {
            Assert.IsTrue(testFixture.Result.InputParameters.OneOf<EntityReference>("Target"));
        }

        [Test]
        public void ShouldReturnInputParameterContainingAssignee()
        {
            Assert.IsTrue(testFixture.Result.InputParameters.OneOf<EntityReference>("Assignee"));
        }

        [Test]
        public void ShouldReturnPreEntityImageContainingOneParameter()
        {
            Assert.IsTrue(testFixture.Result.PreEntityImages.One());
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