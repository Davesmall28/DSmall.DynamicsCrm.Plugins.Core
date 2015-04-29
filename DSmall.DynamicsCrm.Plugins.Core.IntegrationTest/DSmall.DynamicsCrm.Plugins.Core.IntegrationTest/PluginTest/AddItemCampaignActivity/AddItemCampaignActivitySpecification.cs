namespace DSmall.DynamicsCrm.Plugins.Core.IntegrationTest
{
    using System;
    using DSmall.UnitTest.Core;
    using Microsoft.Xrm.Sdk;
    using NUnit.Framework;

    /// <summary>The add item campaign activity specification.</summary>
    [TestFixture]
    public class AddItemCampaignActivitySpecification : SpecificationBase
    {
        private AddItemCampaignActivitySpecificationFixture testFixture;

        /// <summary>The should return input parameter containing three parameters.</summary>
        [Test]
        public void ShouldReturnInputParameterContainingThreeParameters()
        {
            Assert.IsTrue(testFixture.Result.InputParameters.Count == 3);
        }

        /// <summary>The should return input parameter containing campaign activity id.</summary>
        [Test]
        public void ShouldReturnInputParameterContainingCampaignActivityId()
        {
            Assert.IsTrue(testFixture.Result.InputParameters.OneOf<Guid>("CampaignActivityId"));
        }

        /// <summary>The should return input parameter containing item id.</summary>
        [Test]
        public void ShouldReturnInputParameterContainingItemId()
        {
            Assert.IsTrue(testFixture.Result.InputParameters.OneOf<Guid>("ItemId"));
        }

        /// <summary>The should return input parameter containing entity name.</summary>
        [Test]
        public void ShouldReturnInputParameterContainingEntityName()
        {
            Assert.IsTrue(testFixture.Result.InputParameters.OneOf<string>("EntityName"));
        }

        /// <summary>The should return no pre entity images.</summary>
        [Test]
        public void ShouldReturnNoPreEntityImages()
        {
            Assert.IsTrue(testFixture.Result.PreEntityImages.NoParameters());
        }

        /// <summary>The should return post entity images containing one parameter.</summary>
        [Test]
        public void ShouldReturnPostEntityImagesContainingOneParameter()
        {
            Assert.IsTrue(testFixture.Result.PostEntityImages.One());
        }

        /// <summary>The should return post entity image containing asynchronous step primary name.</summary>
        [Test]
        public void ShouldReturnPostEntityImageContainingAsynchronousStepPrimaryName()
        {
            Assert.IsTrue(testFixture.Result.PostEntityImages.OneOf<Entity>("AsynchronousStepPrimaryName"));
        }

        /// <summary>The because of.</summary>
        protected override void BecauseOf()
        {
            testFixture.CrmWriter.Execute(testFixture.RequestId, testFixture.AddItemCampaignActivityRequest);

            testFixture.Result = Retry.Do(() => testFixture.EntitySerializer.Deserialize(testFixture.RequestId, testFixture.MessageName));
        }

        /// <summary>The context.</summary>
        protected override void Context()
        {
            testFixture = new AddItemCampaignActivitySpecificationFixture();
            testFixture.PerformTestSetup();
        }
    }
}