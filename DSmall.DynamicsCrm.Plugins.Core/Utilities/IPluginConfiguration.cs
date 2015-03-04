namespace DSmall.DynamicsCrm.Plugins.Core
{
    using System.Xml;

    /// <summary>The PluginConfiguration interface.</summary>
    public interface IPluginConfiguration
    {
        /// <summary>The get config data guid.</summary>
        /// <param name="doc">The doc.</param>
        /// <param name="label">The label.</param>
        /// <typeparam name="TDataType">The data type to return.</typeparam>
        /// <returns>The <see cref="TDataType"/>.</returns>
        TDataType GetConfigDataGuid<TDataType>(XmlDocument doc, string label);
    }
}