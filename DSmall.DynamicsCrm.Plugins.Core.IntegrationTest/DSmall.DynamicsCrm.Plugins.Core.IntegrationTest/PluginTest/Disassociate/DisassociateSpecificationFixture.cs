namespace DSmall.DynamicsCrm.Plugins.Core.IntegrationTest
{
    using Microsoft.Xrm.Sdk;
    using Microsoft.Xrm.Sdk.Messages;

    /// <summary>The disassociate specification fixture.</summary>
    public class DisassociateSpecificationFixture : SpecificationFixtureBase
    {
        /// <summary>Gets the disassociate request.</summary>
        public DisassociateRequest DisassociateRequest { get; private set; }

        /// <summary>Gets the message name.</summary>
        public string MessageName { get; private set; }

        /// <summary>The perform test setup.</summary>
        public void PerformTestSetup()
        {
            MessageName = "Disassociate";

            var contactEntity = EntityFactory.CreateContact();
            var letterEntity = EntityFactory.CreateLetter();

            var associateRequest = new AssociateRequest
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

            OrganizationService.Execute(associateRequest);

            DisassociateRequest = new DisassociateRequest
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