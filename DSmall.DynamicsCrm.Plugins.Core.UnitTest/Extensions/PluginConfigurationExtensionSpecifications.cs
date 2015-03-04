namespace DSmall.DynamicsCrm.Plugins.Core.UnitTest
{
    using System;
    using DSmall.UnitTest.Core;
    using NUnit.Framework;

    /// <summary>The plugin configuration extension specifications.</summary>
    [TestFixture]
    public class PluginConfigurationExtensionSpecifications : SpecificationBase
    {
        private PluginConfigurationExtensionSpecificationsFixture testFixture;
        private Guid result;

        /// <summary>The should return expected guid value.</summary>
        [Test]
        public void ShouldReturnExpectedGuidValue()
        {
            Assert.AreEqual(testFixture.ExpectedId, result);
        }

        /// <summary>The should return non empty guid.</summary>
        [Test]
        public void ShouldReturnNonEmptyGuid()
        {
            Assert.AreNotEqual(Guid.Empty, result);
        }

        /// <summary>The because of.</summary>
        protected override void BecauseOf()
        {
            base.BecauseOf();

            result = testFixture.UnderTest.GetConfigDataGuid<Guid>("ContactId");
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