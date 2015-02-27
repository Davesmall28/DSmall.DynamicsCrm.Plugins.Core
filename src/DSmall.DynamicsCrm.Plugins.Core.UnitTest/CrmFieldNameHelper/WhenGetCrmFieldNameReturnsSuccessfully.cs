namespace DSmall.DynamicsCrm.Plugins.Core.UnitTest
{
    using DSmall.UnitTest.Core;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>The when get crm field name returns successfully.</summary>
    [TestClass]
    public class WhenGetCrmFieldNameReturnsSuccessfully : SpecificationBase
    {
        private CrmFieldNameHelperSpecificationFixture testFixture;
        private string result;

        /// <summary>The should return correct crm field name.</summary>
        [TestMethod]
        public void ShouldReturnCorrectCrmFieldName()
        {
            Assert.AreEqual("customerreference", result);
        }

        /// <summary>The because of.</summary>
        protected override void BecauseOf()
        {
            base.BecauseOf();

            result = testFixture.UnderTest.GetCrmFieldName<DummyEntity>(entity => entity.CustomerReference);
        }

        /// <summary>The context.</summary>
        protected override void Context()
        {
            base.Context();
            testFixture = new CrmFieldNameHelperSpecificationFixture();
            testFixture.PerformTestSetup();
        }
    }
}
