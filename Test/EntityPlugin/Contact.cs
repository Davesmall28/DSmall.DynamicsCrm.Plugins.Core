namespace Springboard365.Xrm.Plugins.Core.Test
{
    using Microsoft.Xrm.Sdk;
    using Microsoft.Xrm.Sdk.Client;

    [EntityLogicalName("contact")]
    public class Contact : Entity
    {
        public Contact() :
            base("contact")
        {
        }
    }
}