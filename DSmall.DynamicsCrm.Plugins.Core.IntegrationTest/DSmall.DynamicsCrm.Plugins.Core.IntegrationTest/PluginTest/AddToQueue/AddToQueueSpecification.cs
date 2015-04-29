namespace DSmall.DynamicsCrm.Plugins.Core.IntegrationTest
{
    using System;
    using DSmall.UnitTest.Core;
    using Microsoft.Xrm.Sdk;
    using NUnit.Framework;

    /// <summary>The add to queue specification.</summary>
    [TestFixture]
    public class AddToQueueSpecification : SpecificationBase
    {
        private AddToQueueSpecificationFixture testFixture;

        /// <summary>The should return input parameter containing four parameters.</summary>
        [Test]
        public void ShouldReturnInputParameterContainingFourParameters()
        {
            Assert.IsTrue(testFixture.Result.InputParameters.Count == 4);
        }

        /// <summary>The should return input parameter containing target entity.</summary>
        [Test]
        public void ShouldReturnInputParameterContainingTargetEntity()
        {
            Assert.IsTrue(testFixture.Result.InputParameters.OneOf<EntityReference>("Target"));
        }

        /// <summary>The should return input parameter containing source queue id.</summary>
        [Test]
        public void ShouldReturnInputParameterContainingSourceQueueId()
        {
            Assert.IsTrue(testFixture.Result.InputParameters.OneOf<Guid>("SourceQueueId"));
        }

        /// <summary>The should return input parameter containing destination queue id.</summary>
        [Test]
        public void ShouldReturnInputParameterContainingDestinationQueueId()
        {
            Assert.IsTrue(testFixture.Result.InputParameters.OneOf<Guid>("DestinationQueueId"));
        }

        /// <summary>The should return input parameter containing queue item properties.</summary>
        [Test]
        public void ShouldReturnInputParameterContainingQueueItemProperties()
        {
            Assert.IsTrue(testFixture.Result.InputParameters.OneOf<Entity>("QueueItemProperties"));
        }

        /// <summary>The should return no pre entity images.</summary>
        [Test]
        public void ShouldReturnNoPreEntityImages()
        {
            Assert.IsTrue(testFixture.Result.PreEntityImages.NoParameters());
        }

        /// <summary>The should return no post entity images.</summary>
        [Test]
        public void ShouldReturnNoPostEntityImages()
        {
            Assert.IsTrue(testFixture.Result.PostEntityImages.NoParameters());
        }

        /// <summary>The because of.</summary>
        protected override void BecauseOf()
        {
            testFixture.CrmWriter.Execute(testFixture.RequestId, testFixture.AddToQueueRequest);

            testFixture.Result = Retry.Do(() => testFixture.EntitySerializer.Deserialize(testFixture.RequestId, testFixture.MessageName));
        }

        /// <summary>The context.</summary>
        protected override void Context()
        {
            testFixture = new AddToQueueSpecificationFixture();
            testFixture.PerformTestSetup();
        }
    }
}