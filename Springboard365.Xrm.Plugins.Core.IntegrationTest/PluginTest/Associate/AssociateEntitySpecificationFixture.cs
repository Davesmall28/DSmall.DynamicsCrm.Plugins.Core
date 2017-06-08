namespace Springboard365.Xrm.Plugins.Core.IntegrationTest
{
    using Microsoft.Xrm.Sdk;
    using Microsoft.Xrm.Sdk.Messages;

    public class AssociateEntitySpecificationFixture : SpecificationFixtureBase
    {
        public AssociateRequest AssociateRequest { get; private set; }

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