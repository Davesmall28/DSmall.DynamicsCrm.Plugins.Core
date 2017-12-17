namespace Springboard365.Xrm.Plugins.Core.Test.Entities
{
    using System.Runtime.Serialization;
    using Microsoft.Xrm.Sdk;
    using Microsoft.Xrm.Sdk.Client;

    [DataContract]
    [EntityLogicalName("order")]
    internal class Order : Entity
    {
        internal Order() :
            base(EntityLogicalName)
        {
        }

        internal const string EntityLogicalName = "order";
    }
}