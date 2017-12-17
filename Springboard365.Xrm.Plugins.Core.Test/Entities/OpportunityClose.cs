namespace Springboard365.Xrm.Plugins.Core.Test.Entities
{
    using System.Runtime.Serialization;
    using Microsoft.Xrm.Sdk;
    using Microsoft.Xrm.Sdk.Client;

    [DataContract]
    [EntityLogicalName("opportunityclose")]
    internal class OpportunityClose : Entity
    {
        internal OpportunityClose() :
            base(EntityLogicalName)
        {
        }

        internal const string EntityLogicalName = "opportunityclose";
    }
}