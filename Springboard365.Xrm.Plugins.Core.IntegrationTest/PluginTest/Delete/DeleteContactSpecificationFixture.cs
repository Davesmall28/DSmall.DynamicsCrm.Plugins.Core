namespace Springboard365.Xrm.Plugins.Core.IntegrationTest
{
    using Microsoft.Xrm.Sdk;

    public class DeleteContactSpecificationFixture : SpecificationFixtureBase
    {
        public EntityReference EntityReferenceToDelete { get; private set; }

        public string MessageName { get; private set; }

        public void PerformTestSetup()
        {
            MessageName = "Delete";

            var entityToCreate = new Entity("contact");
            entityToCreate.Attributes.Add("firstname", "DummyFirstName");
            entityToCreate.Attributes.Add("lastname", "DeleteRequest");

            entityToCreate.Id = OrganizationService.Create(entityToCreate);

            EntityReferenceToDelete = new EntityReference(entityToCreate.LogicalName, entityToCreate.Id);
        }
    }
}