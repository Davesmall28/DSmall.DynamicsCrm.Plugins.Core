namespace DSmall.DynamicsCrm.Plugins.Core.UnitTest
{
    using System;
    using System.Xml;

    /// <summary>The plugin configuration extension specifications fixture.</summary>
    public class PluginConfigurationExtensionSpecificationsFixture
    {
        /// <summary>Gets or sets the under test.</summary>
        public string UnderTest { get; set; }

        /// <summary>Gets or sets the under test xml.</summary>
        public XmlDocument UnderTestXml { get; set; }

        /// <summary>Gets or sets the expected id.</summary>
        public Guid ExpectedId { get; set; }

        /// <summary>The perform test setup.</summary>
        public void PerformTestSetup()
        {
            if (ExpectedId == Guid.Empty)
            {
                ExpectedId = Guid.NewGuid();
            }

            if (string.IsNullOrWhiteSpace(UnderTest))
            {
                UnderTest = string.Format("<settings><setting name='ContactId'><value>{0}</value></setting></settings>", ExpectedId);
            }

            UnderTestXml = new XmlDocument();
            UnderTestXml.LoadXml(UnderTest);
        }
    }
}