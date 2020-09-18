namespace Springboard365.Xrm.Plugins.Core.Test.Entities
{
    using System.Runtime.Serialization;
    using Microsoft.Xrm.Sdk;
    using Microsoft.Xrm.Sdk.Client;

    [DataContract]
    [EntityLogicalName("systemuser")]
    internal class SystemUser : Entity
    {
        internal SystemUser() :
            base(EntityLogicalName)
        {
        }

        internal const string EntityLogicalName = "systemuser";
    }
}