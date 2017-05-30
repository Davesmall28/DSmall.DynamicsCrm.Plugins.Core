namespace Springboard365.Xrm.Plugins.Core.IntegrationTest
{
    using Microsoft.Xrm.Sdk;

    public class CreateContactSpecificationFixture : SpecificationFixtureBase
    {
        public Entity EntityToCreate { get; private set; }

        public string MessageName { get; private set; }

        public void PerformTestSetup()
        {
            MessageName = "Create";

            EntityToCreate = new Entity("contact");
            EntityToCreate.Attributes.Add("firstname", "DummFirstName");
        }
    }
}