namespace DSmall.DynamicsCrm.Plugins.Core.IntegrationTest
{
    using System;
    using Microsoft.Crm.Sdk.Messages;
    using Microsoft.Xrm.Sdk;

    /// <summary>The assign entity specification fixture.</summary>
    public class AssignEntitySpecificationFixture : SpecificationFixtureBase
    {
        /// <summary>Gets the assign request.</summary>
        public AssignRequest AssignRequest { get; private set; }

        /// <summary>Gets the message name.</summary>
        public string MessageName { get; private set; }

        /// <summary>The perform test setup.</summary>
        public void PerformTestSetup()
        {
            MessageName = "Assign";

            var targetEntity = new Entity("contact")
            {
                Id = Guid.NewGuid()
            };
            targetEntity["firstname"] = "DummyFirstName";
            OrganizationService.Create(targetEntity);
            
            AssignRequest = new AssignRequest
            {
                Target = targetEntity.ToEntityReference(),
                Assignee = CrmReader.GetSystemUser()
            };
        }
    }
}