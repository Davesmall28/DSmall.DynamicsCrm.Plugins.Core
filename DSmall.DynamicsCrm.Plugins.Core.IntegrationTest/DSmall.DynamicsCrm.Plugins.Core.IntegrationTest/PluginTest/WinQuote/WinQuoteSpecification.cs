namespace DSmall.DynamicsCrm.Plugins.Core.IntegrationTest
{
    using System;
    using DSmall.UnitTest.Core;
    using Microsoft.Xrm.Sdk;
    using NUnit.Framework;

    /// <summary>The win quote specification.</summary>
    [TestFixture]
    public class WinQuoteSpecification : SpecificationBase
    {
        private WinQuoteSpecificationFixture testFixture;
        private Guid requestId;

        /// <summary>The should return input parameters containing two parameters.</summary>
        [Test]
        public void ShouldReturnInputParametersContainingTwoParameters()
        {
            Assert.IsTrue(testFixture.Result.InputParameters.Count == 2);
        }

        /// <summary>The should return input parameter containing quote close entity.</summary>
        [Test]
        public void ShouldReturnInputParameterContainingQuoteCloseEntity()
        {
            Assert.IsTrue(testFixture.Result.InputParameters.Count("QuoteClose", typeof(Entity)) == 1);
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
        public void ShouldReturnNoPostEntityImages()
        {
            Assert.IsTrue(testFixture.Result.PostEntityImages.Count == 0);
        }

        /// <summary>The because of.</summary>
        protected override void BecauseOf()
        {
            testFixture.CrmWriter.Execute(requestId, testFixture.WinQuoteRequest);

            testFixture.Result = Retry.Do(() => testFixture.EntitySerializer.Deserialize(requestId, testFixture.MessageName));
        }

        /// <summary>The context.</summary>
        protected override void Context()
        {
            testFixture = new WinQuoteSpecificationFixture();
            testFixture.PerformTestSetup();

            requestId = Guid.NewGuid();
        }
    }
}