namespace DSmall.DynamicsCrm.Plugins.Core.IntegrationTest
{
    using Microsoft.Xrm.Sdk;

    /// <summary>The delete contact specification fixture.</summary>
    public class DeleteContactSpecificationFixture : SpecificationFixtureBase
    {
        /// <summary>Gets the entity reference to delete.</summary>
        public EntityReference EntityReferenceToDelete { get; private set; }

        /// <summary>The perform test setup.</summary>
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