namespace Springboard365.Xrm.Plugins.Core.Test
{
    using System;
    using System.Xml;

    public class PluginConfigurationExtensionSpecificationsFixture
    {
        public string UnderTest { get; private set; }

        public XmlDocument UnderTestXml { get; private set; }

        public Guid ExpectedId { get; private set; }

        public void PerformTestSetup()
        {
            if (ExpectedId == Guid.Empty)
            {
                ExpectedId = Guid.NewGuid();
            }

            if (string.IsNullOrWhiteSpace(UnderTest))
            {
                UnderTest = $"<settings><setting name='ContactId'><value>{ExpectedId}</value></setting></settings>";
            }

            UnderTestXml = new XmlDocument();
            UnderTestXml.LoadXml(UnderTest);
        }
    }
}