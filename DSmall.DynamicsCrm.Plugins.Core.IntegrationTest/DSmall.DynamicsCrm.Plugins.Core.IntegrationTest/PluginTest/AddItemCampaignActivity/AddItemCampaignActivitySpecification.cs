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
        private Guid requestId;

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
            Assert.IsTrue(testFixture.Result.InputParameters.Count("CampaignActivityId", typeof(Guid)) == 1);
        }

        /// <summary>The should return input parameter containing item id.</summary>
        [Test]
        public void ShouldReturnInputParameterContainingItemId()
        {
            Assert.IsTrue(testFixture.Result.InputParameters.Count("ItemId", typeof(Guid)) == 1);
        }

        /// <summary>The should return input parameter containing entity name.</summary>
        [Test]
        public void ShouldReturnInputParameterContainingEntityName()
        {
            Assert.IsTrue(testFixture.Result.InputParameters.Count("EntityName", typeof(string)) == 1);
        }

        /// <summary>The should return no pre entity images.</summary>
        [Test]
        public void ShouldReturnNoPreEntityImages()
        {
            Assert.IsTrue(testFixture.Result.PreEntityImages.Count == 0);
        }

        /// <summary>The should return post entity images containing one parameter.</summary>
        [Test]
        public void ShouldReturnPostEntityImagesContainingOneParameter()
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
            testFixture.CrmWriter.Execute(requestId, testFixture.AddItemCampaignActivityRequest);

            testFixture.Result = Retry.Do(() => testFixture.EntitySerializer.Deserialize(requestId, testFixture.MessageName));
        }

        /// <summary>The context.</summary>
        protected override void Context()
        {
            testFixture = new AddItemCampaignActivitySpecificationFixture();
            testFixture.PerformTestSetup();

            requestId = Guid.NewGuid();
        }
    }
}