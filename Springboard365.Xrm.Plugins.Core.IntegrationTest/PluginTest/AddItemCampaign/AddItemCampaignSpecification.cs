namespace Springboard365.Xrm.Plugins.Core.IntegrationTest
{
    using System;
    using Microsoft.Xrm.Sdk;
    using NUnit.Framework;
    using Springboard365.UnitTest.Core;

    [TestFixture]
    public class AddItemCampaignSpecification : SpecificationBase
    {
        private AddItemCampaignSpecificationFixture testFixture;

        protected override void Context()
        {
            testFixture = new AddItemCampaignSpecificationFixture();
            testFixture.PerformTestSetup();
        }

        protected override void BecauseOf()
        {
            testFixture.CrmWriter.Execute(testFixture.RequestId, testFixture.AddItemCampaignRequest);

            testFixture.Result = Retry.Do(() => testFixture.EntitySerializer.Deserialize(testFixture.RequestId, testFixture.MessageName));
        }

        [Test]
        public void ShouldReturnInputParameterContainingThreeParameters()
        {
            Assert.IsTrue(testFixture.Result.InputParameters.Count == 3);
        }

        [Test]
        public void ShouldReturnInputParameterContainingCampaignId()
        {
            Assert.IsTrue(testFixture.Result.InputParameters.OneOf<Guid>("CampaignId"));
        }

        [Test]
        public void ShouldReturnInputParameterContainingEntityId()
        {
            Assert.IsTrue(testFixture.Result.InputParameters.OneOf<Guid>("EntityId"));
        }

        [Test]
        public void ShouldReturnInputParameterContainingEntityName()
        {
            Assert.IsTrue(testFixture.Result.InputParameters.OneOf<string>("EntityName"));
        }

        [Test]
        public void ShouldReturnNoPreEntityImages()
        {
            Assert.IsTrue(testFixture.Result.PreEntityImages.NoParameters());
        }

        [Test]
        public void ShouldReturnPostEntityImagesContainingOneParameter()
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