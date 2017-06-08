namespace Springboard365.Xrm.Plugins.Core.IntegrationTest
{
    using Microsoft.Xrm.Sdk;

    public class UpdateContactSpecificationFixture : SpecificationFixtureBase
    {
        public Entity EntityToUpdate { get; private set; }

        public void PerformTestSetup()
        {
            MessageName = "Update";

            EntityToUpdate = new Entity("contact");
            EntityToUpdate.Attributes.Add("firstname", "DummyFirstName");

            EntityToUpdate.Id = OrganizationService.Create(EntityToUpdate);
        }
    }
}