namespace Springboard365.Xrm.Plugins.Core.IntegrationTest
{
    using Microsoft.Xrm.Sdk;
    using Microsoft.Xrm.Sdk.Messages;

    public class DisassociateSpecificationFixture : SpecificationFixtureBase
    {
        public DisassociateRequest DisassociateRequest { get; private set; }

        public DisassociateSpecificationFixture()
            : base("Disassociate")
        {
        }

        public void PerformTestSetup()
        {
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