namespace Springboard365.Xrm.Plugins.Core
{
    using System.Xml;

    public interface IPluginConfiguration
    {
        TDataType GetConfigDataGuid<TDataType>(XmlDocument doc, string label);
    }
}