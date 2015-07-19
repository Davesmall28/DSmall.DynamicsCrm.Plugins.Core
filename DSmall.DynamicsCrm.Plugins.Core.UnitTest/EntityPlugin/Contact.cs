namespace DSmall.DynamicsCrm.Plugins.Core.UnitTest
{
    using Microsoft.Xrm.Sdk;

    /// <summary>The contact.</summary>
    [Microsoft.Xrm.Sdk.Client.EntityLogicalNameAttribute("contact")]
    public class Contact : Entity
    {
        /// <summary>Initialises a new instance of the <see cref="Contact"/> class.</summary>
        public Contact() :
            base("contact")
        {
        }
    }
}