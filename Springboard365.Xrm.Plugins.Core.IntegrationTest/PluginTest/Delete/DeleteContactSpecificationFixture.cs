namespace Springboard365.Xrm.Plugins.Core.IntegrationTest
{
    using Microsoft.Xrm.Sdk;

    public class DeleteContactSpecificationFixture : SpecificationFixtureBase
    {
        public EntityReference EntityReferenceToDelete { get; private set; }

        public DeleteContactSpecificationFixture()
            : base("Delete")
        {
        }

        public void PerformTestSetup()
        {
            var entityToCreate = new Entity("contact");
            entityToCreate.Attributes.Add("firstname", "DummyFirstName");
            entityToCreate.Attributes.Add("lastname", "DeleteRequest");

            entityToCreate.Id = OrganizationService.Create(entityToCreate);

            EntityReferenceToDelete = new EntityReference(entityToCreate.LogicalName, entityToCreate.Id);
        }
    }
}