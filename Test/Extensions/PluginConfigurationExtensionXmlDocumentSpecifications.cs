namespace Springboard365.Xrm.Plugins.Core.Test
{
    using System;
    using NUnit.Framework;
    using Springboard365.UnitTest.Core;
    using Springboard365.Xrm.Plugins.Core.Extensions;

    [TestFixture]
    public class PluginConfigurationExtensionXmlDocumentSpecifications : SpecificationBase
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
            result = testFixture.UnderTestXml.GetConfigDataGuid<Guid>("ContactId");
        }

        [Test]
        public void ShouldReturnExpectedGuidValue()
        {
            Assert.AreEqual(testFixture.ExpectedId, result);
        }

        [Test]
        public void ShouldReturnNonEmptyGuid()
        {
            Assert.AreNotEqual(Guid.Empty, result);
        }
    }
}