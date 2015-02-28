namespace DSmall.DynamicsCrm.Plugins.Core.UnitTest
{
    using System;
    using DSmall.UnitTest.Core;
    using NUnit.Framework;

    /// <summary>The plugin configuration extension with no setting specification.</summary>
    [TestFixture]
    public class PluginConfigurationExtensionWithNoSettingSpecification : SpecificationBase
    {
        private PluginConfigurationExtensionSpecificationsFixture testFixture;
        private Guid result;

        /// <summary>The should return empty guid.</summary>
        [Test]
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