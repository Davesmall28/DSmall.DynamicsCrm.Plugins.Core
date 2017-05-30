namespace Springboard365.Xrm.Plugins.Core
{
    using System.Xml;

    public static class PluginConfigurationExtensions
    {
        private static readonly IPluginConfiguration PluginConfiguration = new PluginConfiguration();

        public static TDataType GetConfigDataGuid<TDataType>(this string pluginConfigurationDocument, string label)
        {
            var xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(pluginConfigurationDocument);
            return PluginConfiguration.GetConfigDataGuid<TDataType>(xmlDoc, label);
        }

        public static TDataType GetConfigDataGuid<TDataType>(this XmlDocument pluginConfigurationDocument, string label)
        {
            return PluginConfiguration.GetConfigDataGuid<TDataType>(pluginConfigurationDocument, label);
        }
    }
}