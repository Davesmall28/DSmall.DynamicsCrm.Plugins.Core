namespace DSmall.DynamicsCrm.Plugins.Core.IntegrationTest
{
    using System;
    using Microsoft.Crm.Sdk.Messages;
    using Microsoft.Xrm.Sdk;

    /// <summary>The merge entity specification fixture.</summary>
    public class MergeEntitySpecificationFixture : SpecificationFixtureBase
    {
        /// <summary>Gets or sets the merge request.</summary>
        public MergeRequest MergeRequest { get; set; }

        /// <summary>The perform test setup.</summary>
        public void PerformTestSetup()
        {
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