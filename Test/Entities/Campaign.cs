namespace Springboard365.Xrm.Plugins.Core.Test.Entities
{
    using System.Runtime.Serialization;
    using Microsoft.Xrm.Sdk;
    using Microsoft.Xrm.Sdk.Client;

    [DataContract]
    [EntityLogicalName("campaign")]
    internal class Campaign : Entity
    {
        internal Campaign() :
            base(EntityLogicalName)
        {
        }

        internal const string EntityLogicalName = "campaign";
    }
}