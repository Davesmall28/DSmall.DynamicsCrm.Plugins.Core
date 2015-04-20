namespace DSmall.DynamicsCrm.Plugins.Core.IntegrationTest
{
    using System;
    using DSmall.UnitTest.Core;
    using Microsoft.Crm.Sdk.Messages;
    using Microsoft.Xrm.Sdk;
    using NUnit.Framework;

    /// <summary>The assign entity specification.</summary>
    [TestFixture]
    public class AssignEntitySpecification : SpecificationBase
    {
        private AssignEntitySpecificationFixture testFixture;
        private Guid requestId;

        /// <summary>The should return input parameter containing two parameters.</summary>
        [Test]
        public void ShouldReturnInputParameterContainingTwoParameters()
        {
            Assert.IsTrue(testFixture.Result.InputParameters.Count == 2);
        }

        /// <summary>The should return input parameter containing target entity.</summary>
        [Test]
        public void ShouldReturnInputParameterContainingTargetEntity()
        {
            Assert.IsTrue(testFixture.Result.InputParameters.Count("Target", typeof(EntityReference)) == 1);
        }

        /// <summary>The should return input parameter containing assignee.</summary>
        [Test]
        public void ShouldReturnInputParameterContainingAssignee()
        {
            Assert.IsTrue(testFixture.Result.InputParameters.Count("Assignee", typeof(EntityReference)) == 1);
        }

        /// <summary>The should return pre entity image containing one parameter.</summary>
        [Test]
        public void ShouldReturnPreEntityImageContainingOneParameter()
        {
            Assert.IsTrue(testFixture.Result.PreEntityImages.Count == 1);
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
            testFixture.CrmWriter.Execute(requestId, testFixture.AssignRequest);

            testFixture.Result = Retry.Do(() => testFixture.EntitySerializer.Deserialize(requestId, testFixture.MessageName));
        }

        /// <summary>The context.</summary>
        protected override void Context()
        {
            testFixture = new AssignEntitySpecificationFixture();
            testFixture.PerformTestSetup();

            requestId = Guid.NewGuid();
        }
    }
}