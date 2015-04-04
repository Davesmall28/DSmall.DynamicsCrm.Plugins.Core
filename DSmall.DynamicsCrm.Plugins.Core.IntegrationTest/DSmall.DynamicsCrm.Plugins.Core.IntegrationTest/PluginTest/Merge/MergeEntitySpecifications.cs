namespace DSmall.DynamicsCrm.Plugins.Core.IntegrationTest.Merge
{
    using System;
    using DSmall.UnitTest.Core;
    using Microsoft.Xrm.Sdk;
    using NUnit.Framework;

    /// <summary>The merge entity specifications.</summary>
    [TestFixture]
    public class MergeEntitySpecifications : SpecificationBase
    {
        private MergeEntitySpecificationFixture testFixture;

        /// <summary>The should return input parameter containing four parameters.</summary>
        [Test]
        public void ShouldReturnInputParameterContainingFourParameters()
        {
            Assert.IsTrue(testFixture.Result.InputParameters.Count == 4);
        }

        /// <summary>The should return input parameter containing update content.</summary>
        [Test]
        public void ShouldReturnInputParameterContainingUpdateContent()
        {
            Assert.IsTrue(testFixture.Result.InputParameters.Count("UpdateContent", typeof(Entity)) == 1);
        }

        /// <summary>The should return input parameter containing target entity.</summary>
        [Test]
        public void ShouldReturnInputParameterContainingTargetEntity()
        {
            Assert.IsTrue(testFixture.Result.InputParameters.Count("Target", typeof(EntityReference)) == 1);
        }

        /// <summary>The should return input parameter containing subordinate id.</summary>
        [Test]
        public void ShouldReturnInputParameterContainingSubordinateId()
        {
            Assert.IsTrue(testFixture.Result.InputParameters.Count("SubordinateId", typeof(Guid)) == 1);
        }

        /// <summary>The should return input parameter containing perform parenting checks.</summary>
        [Test]
        public void ShouldReturnInputParameterContainingPerformParentingChecks()
        {
            Assert.IsTrue(testFixture.Result.InputParameters.Count("PerformParentingChecks", typeof(bool)) == 1);
        }

        /// <summary>The should return no pre entity images.</summary>
        [Test]
        public void ShouldReturnNoPreEntityImages()
        {
            Assert.IsTrue(testFixture.Result.PreEntityImages.Count == 0);
        }

        /// <summary>The should return no post entity images.</summary>
        [Test]
        public void ShouldReturnOnePostEntityImage()
        {
            Assert.IsTrue(testFixture.Result.PostEntityImages.Count == 1);
        }

        /// <summary>The should return post entity image containing asynchronous step primary name.</summary>
        [Test]
        public void ShouldReturnPostEntityImageContainingAsynchronousStepPrimaryName()
        {
            Assert.IsTrue(testFixture.Result.PostEntityImages.Count("AsynchronousStepPrimaryName", typeof(Entity)) == 1);
        }

        /// <summary>The because of.</summary>
        protected override void BecauseOf()
        {
            testFixture.CrmWriter.Execute(testFixture.RequestId, testFixture.MergeRequest);

            testFixture.Result = Retry.Do(() => testFixture.EntitySerializer.Deserialize(testFixture.RequestId));
        }

        /// <summary>The context.</summary>
        protected override void Context()
        {
            testFixture = new MergeEntitySpecificationFixture();
            testFixture.PerformTestSetup();
        }
    }
}