namespace DSmall.DynamicsCrm.Plugins.Core.IntegrationTest
{
    using System;
    using System.ServiceModel.Channels;
    using Microsoft.Crm.Sdk.Messages;
    using Microsoft.Xrm.Sdk;

    /// <summary>The win opportunity specification fixture.</summary>
    public class WinOpportunitySpecificationFixture : SpecificationFixtureBase
    {
        /// <summary>Gets the win opportunity request.</summary>
        public WinOpportunityRequest WinOpportunityRequest { get; private set; }

        /// <summary>Gets or sets the opportunity id.</summary>
        public Guid OpportunityId { get; set; }

        /// <summary>Gets the message name.</summary>
        public string MessageName { get; private set; }

        /// <summary>The perform test setup.</summary>
        public void PerformTestSetup()
        {
            MessageName = "Win";
            OpportunityId = Guid.NewGuid();

            var entityToCreate = new Entity("opportunity")
            {
                Id = OpportunityId
            };
            entityToCreate["name"] = "DummyOpportunity";

            OrganizationService.Create(entityToCreate);

            var opportunityClose = new Entity("opportunityclose");
            opportunityClose["opportunityid"] = entityToCreate.ToEntityReference();
            opportunityClose["subject"] = "Won!";
            opportunityClose["actualend"] = DateTime.Now;
            opportunityClose["description"] = "Won!";

            WinOpportunityRequest = new WinOpportunityRequest
            {
                OpportunityClose = opportunityClose,
                Status = new OptionSetValue(3)
            };
        }
    }
}