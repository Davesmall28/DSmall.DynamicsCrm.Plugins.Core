namespace Springboard365.Xrm.Plugins.Core.Test.Entities
{
    using System.Runtime.Serialization;
    using Microsoft.Xrm.Sdk;
    using Microsoft.Xrm.Sdk.Client;

    [DataContract]
    [EntityLogicalName("lead")]
    internal class Lead : Entity
    {
        internal Lead() :
            base(EntityLogicalName)
        {
        }

        internal const string EntityLogicalName = "lead";
    }
}