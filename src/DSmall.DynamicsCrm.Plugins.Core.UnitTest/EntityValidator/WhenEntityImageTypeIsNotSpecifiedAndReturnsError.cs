namespace DSmall.DynamicsCrm.Plugins.Core.UnitTest
{
    using System;
    using DSmall.UnitTest.Core;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Microsoft.Xrm.Sdk;

    /// <summary>The when entity image type is not specified and returns error.</summary>
    [TestClass]
    public class WhenEntityImageTypeIsNotSpecifiedAndReturnsError : SpecificationBase
    {
        private EntityValidatorSpecificationFixture testFixture;
        private Exception exceptionThrown;

        /// <summary>The should return correct exception message.</summary>
        [TestMethod]
        public void ShouldReturnCorrectExceptionMessage()
        {
            Assert.AreEqual("Please specify an Entity Image Type.", exceptionThrown.Message);
        }

        /// <summary>The because of.</summary>
        protected override void BecauseOf()
        {
            base.BecauseOf();

            try
            {
                testFixture.UnderTest.GetValidCrmTargetEntity<Entity>(testFixture.PluginContext.Object, EntityImageType.NotSpecified);
            }
            catch (Exception exception)
            {
                exceptionThrown = exception;
            }
        }

        /// <summary>The context.</summary>
        protected override void Context()
        {
            base.Context();

            testFixture = new EntityValidatorSpecificationFixture();
            testFixture.PerformTestSetupWithNullPostImage();
        }
    }
}
