namespace Springboard365.Xrm.Plugins.Core.IntegrationTest
{
    using System;
    using Microsoft.Crm.Sdk.Messages;
    using Microsoft.Xrm.Sdk;

    public class MergeEntitySpecificationFixture : SpecificationFixtureBase
    {
        public MergeRequest MergeRequest { get; private set; }

        public void PerformTestSetup()
        {
            MessageName = "Merge";

            var targetEntity = new Entity("contact")
            {
                Id = Guid.NewGuid()
            };
            targetEntity["firstname"] = "DummyFirstName";
            OrganizationService.Create(targetEntity);
            
            var subordinateEntity = new Entity("contact");
            subordinateEntity["firstname"] = "DummyFirstName";
            var subordinateId = OrganizationService.Create(subordinateEntity);

            MergeRequest = new MergeRequest
            {
                SubordinateId = subordinateId,
                Target = targetEntity.ToEntityReference(),
                UpdateContent = new Entity("contact")
            };
        }
    }
}