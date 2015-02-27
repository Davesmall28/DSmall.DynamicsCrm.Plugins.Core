namespace DSmall.DynamicsCrm.Plugins.Core.UnitTest
{
    using System;
    using DSmall.UnitTest.Core;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>The plugin configuration extension with no setting specification.</summary>
    [TestClass]
    public class PluginConfigurationExtensionWithNoSettingSpecification : SpecificationBase
    {
        private PluginConfigurationExtensionSpecificationsFixture testFixture;
        private Guid result;

        /// <summary>The should return empty guid.</summary>
        [TestMethod]
        public void ShouldReturnEmptyGuid()
        {
            Assert.AreEqual(Guid.Empty, result);
        }

        /// <summary>The because of.</summary>
        protected override void BecauseOf()
        {
            base.BecauseOf();

            result = "<settings></settings>".GetConfigDataGuid<Guid>("ContactId");
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