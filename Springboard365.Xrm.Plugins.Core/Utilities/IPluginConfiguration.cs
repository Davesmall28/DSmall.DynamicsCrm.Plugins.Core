namespace Springboard365.Xrm.Plugins.Core.Utilities
{
    using System.Xml;

    public interface IPluginConfiguration
    {
        TDataType GetConfigDataGuid<TDataType>(XmlDocument doc, string label);
    }
}