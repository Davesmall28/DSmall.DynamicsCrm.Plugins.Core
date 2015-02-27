namespace DSmall.DynamicsCrm.Plugins.Core
{
    using System.Xml;

    /// <summary>The plugin configuration extensions.</summary>
    public static class PluginConfigurationExtensions
    {
        private static readonly IPluginConfiguration PluginConfiguration = new PluginConfiguration();

        /// <summary>The get config data guid.</summary>
        /// <param name="pluginConfigurationDocument">The plugin configuration document.</param>
        /// <param name="label">The label.</param>
        /// <typeparam name="TDataType">The data type to return.</typeparam>
        /// <returns>The <see cref="TDataType"/>.</returns>
        public static TDataType GetConfigDataGuid<TDataType>(this string pluginConfigurationDocument, string label)
        {
            var xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(pluginConfigurationDocument);
            return PluginConfiguration.GetConfigDataGuid<TDataType>(xmlDoc, label);
        }

        /// <summary>The get config data guid.</summary>
        /// <param name="pluginConfigurationDocument">The plugin configuration document.</param>
        /// <param name="label">The label.</param>
        /// <typeparam name="TDataType">The data type to return.</typeparam>
        /// <returns>The <see cref="TDataType"/>.</returns>
        public static TDataType GetConfigDataGuid<TDataType>(this XmlDocument pluginConfigurationDocument, string label)
        {
            return PluginConfiguration.GetConfigDataGuid<TDataType>(pluginConfigurationDocument, label);
        }
    }
}
