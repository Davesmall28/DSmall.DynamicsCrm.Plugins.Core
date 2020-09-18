namespace Springboard365.Xrm.Plugins.Core.Test.Entities
{
    using System.Runtime.Serialization;
    using Microsoft.Xrm.Sdk;
    using Microsoft.Xrm.Sdk.Client;

    [DataContract]
    [EntityLogicalName("quoteclose")]
    internal class QuoteClose : Entity
    {
        internal QuoteClose() :
            base(EntityLogicalName)
        {
        }

        internal const string EntityLogicalName = "quoteclose";
    }
}