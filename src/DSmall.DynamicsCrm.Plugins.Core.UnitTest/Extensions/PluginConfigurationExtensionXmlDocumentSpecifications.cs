namespace DSmall.DynamicsCrm.Plugins.Core.UnitTest
{
    using System;
    using DSmall.UnitTest.Core;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>The plugin configuration extension xml document specifications.</summary>
    [TestClass]
    public class PluginConfigurationExtensionXmlDocumentSpecifications : SpecificationBase
    {
        private PluginConfigurationExtensionSpecificationsFixture testFixture;
        private Guid result;

        /// <summary>The should return expected guid value.</summary>
        [TestMethod]
        public void ShouldReturnExpectedGuidValue()
        {
            Assert.AreEqual(testFixture.ExpectedId, result);
        }

        /// <summary>The should return non empty guid.</summary>
        [TestMethod]
        public void ShouldReturnNonEmptyGuid()
        {
            Assert.AreNotEqual(Guid.Empty, result);
        }

        /// <summary>The because of.</summary>
        protected override void BecauseOf()
        {
            base.BecauseOf();

            result = testFixture.UnderTestXml.GetConfigDataGuid<Guid>("ContactId");
        }

        /// <summary>The context.</summary>
        protected override void Context()
        {
            base.Context();

            testFixture = new PluginConfigurationExtensionSpecificationsFixture();
            testFixture.PerformTestSetup();
        }
    }
}