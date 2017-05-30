namespace Springboard365.Xrm.Plugins.Core.IntegrationTest
{
    using System;
    using Springboard365.Xrm.Plugins.Core.Model;

    public interface IEntitySerializer
    {
        PluginParameters Deserialize(Guid requestId, string messageName);
    }
}