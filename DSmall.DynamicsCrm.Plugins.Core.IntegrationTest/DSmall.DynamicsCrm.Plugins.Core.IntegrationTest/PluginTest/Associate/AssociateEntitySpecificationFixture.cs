namespace DSmall.DynamicsCrm.Plugins.Core.IntegrationTest
{
    using Microsoft.Xrm.Sdk;
    using Microsoft.Xrm.Sdk.Messages;

    /// <summary>The associate entity specification fixture.</summary>
    public class AssociateEntitySpecificationFixture : SpecificationFixtureBase
    {
        /// <summary>Gets or sets the associate request.</summary>
        public AssociateRequest AssociateRequest { get; set; }

        /// <summary>Gets the message name.</summary>
        public string MessageName { get; private set; }

        /// <summary>The perform test setup.</summary>
        public void PerformTestSetup()
        {
            MessageName = "Associate";

            var contactEntity = EntityFactory.CreateContact();
            var letterEntity = EntityFactory.CreateLetter();

            AssociateRequest = new AssociateRequest
            {
                Target = contactEntity.ToEntityReference(),
                Relationship = new Relationship
                {
                    SchemaName = "Contact_Letters"
                },
                RelatedEntities = new EntityReferenceCollection
                {
                    letterEntity.ToEntityReference()
                }
            };
        }
    }
}