namespace Springboard365.Xrm.Plugins.Core.IntegrationTest
{
    using Microsoft.Xrm.Sdk;

    public class CreateContactSpecificationFixture : SpecificationFixtureBase
    {
        public Entity EntityToCreate { get; private set; }

        public CreateContactSpecificationFixture()
            : base("Create")
        {
        }

        public void PerformTestSetup()
        {
            EntityToCreate = new Entity("contact");
            EntityToCreate.Attributes.Add("firstname", "DummyFirstName");
        }
    }
}