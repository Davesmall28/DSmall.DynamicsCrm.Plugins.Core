namespace Springboard365.Xrm.Plugins.Core.Test.Entities
{
    using System.Runtime.Serialization;
    using Microsoft.Xrm.Sdk;
    using Microsoft.Xrm.Sdk.Client;

    [DataContract]
    [EntityLogicalName("letter")]
    internal class Letter : Entity
    {
        internal Letter() :
            base(EntityLogicalName)
        {
        }

        internal const string EntityLogicalName = "letter";
    }
}