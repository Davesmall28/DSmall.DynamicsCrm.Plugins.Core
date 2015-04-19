namespace DSmall.DynamicsCrm.Plugins.Core.IntegrationTest
{
    using System;
    using DSmall.UnitTest.Core;
    using Microsoft.Xrm.Sdk;
    using NUnit.Framework;

    /// <summary>The merge entity specification.</summary>
    [TestFixture]
    public class SetStateEntitySpecification : SpecificationBase
    {
        private SetStateEntitySpecificationFixture testFixture;
        private Guid requestId;

        /// <summary>The should return input parameter containing three parameters.</summary>
        [Test]
        public void ShouldReturnInputParameterContainingThreeParameters()
        {
            Assert.IsTrue(testFixture.Result.InputParameters.Count == 3);
        }

        /// <summary>The should return input parameter containing entity moniker.</summary>
        [Test]
        public void ShouldReturnInputParameterContainingEntityMoniker()
        {
            Assert.IsTrue(testFixture.Result.InputParameters.Count("EntityMoniker", typeof(EntityReference)) == 1);
        }

        /// <summary>The should return input parameter containing state code.</summary>
        [Test]
        public void ShouldReturnInputParameterContainingStateCode()
        {
            Assert.IsTrue(testFixture.Result.InputParameters.Count("State", typeof(OptionSetValue)) == 1);
        }

        /// <summary>The should return input parameter containing status code.</summary>
        [Test]
        public void ShouldReturnInputParameterContainingStatusCode()
        {
            Assert.IsTrue(testFixture.Result.InputParameters.Count("Status", typeof(OptionSetValue)) == 1);
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
            testFixture.CrmWriter.Execute(requestId, testFixture.SetStateRequest);

            testFixture.Result = Retry.Do(() => testFixture.EntitySerializer.Deserialize(requestId, testFixture.MessageName));
        }

        /// <summary>The context.</summary>
        protected override void Context()
        {
            testFixture = new SetStateEntitySpecificationFixture();
            testFixture.PerformTestSetup();

            requestId = Guid.NewGuid();
        }
    }
}