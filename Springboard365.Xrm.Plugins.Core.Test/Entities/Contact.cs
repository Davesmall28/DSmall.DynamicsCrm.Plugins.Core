namespace Springboard365.Xrm.Plugins.Core.Test.Entities
{
    using System.Runtime.Serialization;
    using Microsoft.Xrm.Sdk;
    using Microsoft.Xrm.Sdk.Client;

    [DataContract]
    [EntityLogicalName("contact")]
    internal class Contact : Entity
    {
        internal Contact() :
            base(EntityLogicalName)
        {
        }

        internal const string EntityLogicalName = "contact";
    }
}