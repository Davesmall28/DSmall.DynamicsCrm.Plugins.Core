namespace DSmall.DynamicsCrm.Plugins.Core
{
    using System.ComponentModel;
    using System.Xml;

    /// <summary>The plugin configuration.</summary>
    public class PluginConfiguration : IPluginConfiguration
    {
        /// <summary>The get config data guid.</summary>
        /// <param name="doc">The doc.</param>
        /// <param name="label">The label.</param>
        /// <typeparam name="TDataType">The data type to return.</typeparam>
        /// <returns>The <see cref="TDataType"/>.</returns>
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
            var node = doc.SelectSingleNode(string.Format("settings/setting[@name='{0}']", key));

            if (node == null)
            {
                return string.Empty;
            }

            var selectSingleNode = node.SelectSingleNode("value");
            return selectSingleNode != null ? selectSingleNode.InnerText : string.Empty;
        }
    }
}
