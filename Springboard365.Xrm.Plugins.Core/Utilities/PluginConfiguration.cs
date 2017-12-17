namespace Springboard365.Xrm.Plugins.Core.Utilities
{
    using System.ComponentModel;
    using System.Xml;

    public class PluginConfiguration : IPluginConfiguration
    {
        public TDataType GetConfigDataGuid<TDataType>(XmlDocument doc, string label)
        {
            try
            {
                var settingValue = GetSettingValue(doc, label);
                var converter = TypeDescriptor.GetConverter(typeof(TDataType));
                return (TDataType)converter.ConvertFromString(settingValue);
            }
            catch
            {
                return default(TDataType);
            }
        }

        private static string GetSettingValue(XmlNode doc, string key)
        {
            var node = doc.SelectSingleNode($"settings/setting[@name='{key}']");

            if (node == null)
            {
                return string.Empty;
            }

            var selectSingleNode = node.SelectSingleNode("value");
            return selectSingleNode?.InnerText ?? string.Empty;
        }
    }
}