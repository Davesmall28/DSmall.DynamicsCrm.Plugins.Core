namespace Springboard365.Xrm.Plugins.Core.IntegrationTest
{
    using System;
    using Microsoft.Xrm.Sdk;
    using NUnit.Framework;
    using Springboard365.UnitTest.Core;

    [TestFixture]
    public class AddToQueueSpecification : SpecificationBase
    {
        private AddToQueueSpecificationFixture testFixture;

        protected override void Context()
        {
            testFixture = new AddToQueueSpecificationFixture();
            testFixture.PerformTestSetup();
        }

        protected override void BecauseOf()
        {
            testFixture.CrmWriter.Execute(testFixture.RequestId, testFixture.AddToQueueRequest);

            testFixture.Result = Retry.Do(() => testFixture.EntitySerializer.Deserialize(testFixture.RequestId, testFixture.MessageName));
        }

        [Test]
        public void ShouldReturnInputParameterContainingFourParameters()
        {
            Assert.IsTrue(testFixture.Result.InputParameters.Count == 4);
        }

        [Test]
        public void ShouldReturnInputParameterContainingTargetEntity()
        {
            Assert.IsTrue(testFixture.Result.InputParameters.OneOf<EntityReference>("Target"));
        }

        [Test]
        public void ShouldReturnInputParameterContainingSourceQueueId()
        {
            Assert.IsTrue(testFixture.Result.InputParameters.OneOf<Guid>("SourceQueueId"));
        }

        [Test]
        public void ShouldReturnInputParameterContainingDestinationQueueId()
        {
            Assert.IsTrue(testFixture.Result.InputParameters.OneOf<Guid>("DestinationQueueId"));
        }

        [Test]
        public void ShouldReturnInputParameterContainingQueueItemProperties()
        {
            Assert.IsTrue(testFixture.Result.InputParameters.OneOf<Entity>("QueueItemProperties"));
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