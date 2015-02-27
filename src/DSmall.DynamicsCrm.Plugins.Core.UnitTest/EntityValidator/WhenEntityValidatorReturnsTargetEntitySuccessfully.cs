namespace DSmall.DynamicsCrm.Plugins.Core.UnitTest
{
    using DSmall.UnitTest.Core;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Microsoft.Xrm.Sdk;

    /// <summary>The when entity validator returns target entity successfully.</summary>
    [TestClass]
    public class WhenEntityValidatorReturnsTargetEntitySuccessfully : SpecificationBase
    {
        private EntityValidatorSpecificationFixture testFixture;
        private Entity result;

        /// <summary>The should return valid entity.</summary>
        [TestMethod]
        public void ShouldReturnValidEntity()
        {
            Assert.IsNotNull(result);
        }

        /// <summary>The because of.</summary>
        protected override void BecauseOf()
        {
            base.BecauseOf();

            result = testFixture.UnderTest.GetValidCrmTargetEntity<Entity>(testFixture.PluginContext.Object, EntityImageType.Target);
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