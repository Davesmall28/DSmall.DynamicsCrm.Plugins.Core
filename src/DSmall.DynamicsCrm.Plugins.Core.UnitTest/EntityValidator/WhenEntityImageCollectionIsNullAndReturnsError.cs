namespace DSmall.DynamicsCrm.Plugins.Core.UnitTest
{
    using System;
    using DSmall.UnitTest.Core;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Microsoft.Xrm.Sdk;

    /// <summary>The when entity image collection is null and returns error.</summary>
    [TestClass]
    public class WhenEntityImageCollectionIsNullAndReturnsError : SpecificationBase
    {
        private const EntityImageType EntityImageType = Core.EntityImageType.PostImage;
        private EntityValidatorSpecificationFixture testFixture;
        private Exception exceptionThrown;

        /// <summary>The should return correct exception message.</summary>
        [TestMethod]
        public void ShouldReturnCorrectExceptionMessage()
        {
            var exceptionMessage = string.Format("Parameters collection does not contain {0} entity or it is not equal to type of (Entity)", EntityImageType);
            Assert.AreEqual(exceptionMessage, exceptionThrown.Message);
        }

        /// <summary>The because of.</summary>
        protected override void BecauseOf()
        {
            base.BecauseOf();

            try
            {
                testFixture.UnderTest.GetValidCrmTargetEntity<Entity>(testFixture.PluginContext.Object, EntityImageType);
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
