namespace DSmall.DynamicsCrm.Plugins.Core.UnitTest
{
    using DSmall.UnitTest.Core;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Microsoft.Xrm.Sdk;

    /// <summary>The when entity validator returns post image entity successfully.</summary>
    [TestClass]
    public class WhenEntityValidatorReturnsPostImageEntitySuccessfully : SpecificationBase
    {
        private EntityValidatorSpecificationFixture testFixture;
        private Entity result;

        /// <summary>The should return post image valid entity.</summary>
        [TestMethod]
        public void ShouldReturnValidPostImageEntity()
        {
            Assert.IsNotNull(result);
        }

        /// <summary>The because of.</summary>
        protected override void BecauseOf()
        {
            base.BecauseOf();

            result = testFixture.UnderTest.GetValidCrmTargetEntity<Entity>(testFixture.PluginContext.Object, EntityImageType.PostImage);
        }

        /// <summary>The context.</summary>
        protected override void Context()
        {
            base.Context();

            testFixture = new EntityValidatorSpecificationFixture();
            testFixture.PerformTestSetup();
        }
    }
}
