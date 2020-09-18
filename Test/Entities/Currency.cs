namespace Springboard365.Xrm.Plugins.Core.Test.Entities
{
    using System.Runtime.Serialization;
    using Microsoft.Xrm.Sdk;
    using Microsoft.Xrm.Sdk.Client;

    [DataContract]
    [EntityLogicalName("currency")]
    internal class Currency : Entity
    {
        internal Currency() :
            base(EntityLogicalName)
        {
        }

        internal const string EntityLogicalName = "currency";
    }
}