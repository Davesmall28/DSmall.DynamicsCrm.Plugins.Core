namespace Springboard365.Xrm.Plugins.Core.Test
{
    using System;
    using NUnit.Framework;
    using Springboard365.UnitTest.Core;

    [TestFixture]
    public class PluginConfigurationExtensionWithNoSettingSpecification : SpecificationBase
    {
        private PluginConfigurationExtensionSpecificationsFixture testFixture;
        private Guid result;

        protected override void Context()
        {
            testFixture = new PluginConfigurationExtensionSpecificationsFixture();
            testFixture.PerformTestSetup();
        }

        protected override void BecauseOf()
        {
            result = "<settings></settings>".GetConfigDataGuid<Guid>("ContactId");
        }

        [Test]
        public void ShouldReturnEmptyGuid()
        {
            Assert.AreEqual(Guid.Empty, result);
        }
    }
}