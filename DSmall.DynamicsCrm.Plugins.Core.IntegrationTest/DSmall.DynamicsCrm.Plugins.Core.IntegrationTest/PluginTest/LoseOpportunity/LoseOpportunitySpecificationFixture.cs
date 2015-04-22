namespace DSmall.DynamicsCrm.Plugins.Core.IntegrationTest
{
    using System;
    using Microsoft.Crm.Sdk.Messages;
    using Microsoft.Xrm.Sdk;

    /// <summary>The lose opportunity specification fixture.</summary>
    public class LoseOpportunitySpecificationFixture : SpecificationFixtureBase
    {
        /// <summary>Gets the lose opportunity request.</summary>
        public LoseOpportunityRequest LoseOpportunityRequest { get; private set; }

        /// <summary>Gets the message name.</summary>
        public string MessageName { get; private set; }

        /// <summary>The perform test setup.</summary>
        public void PerformTestSetup()
        {
            MessageName = "Lose";

            var opportunityEntity = EntityFactory.CreateOpportunity();

            var opportunityClose = new Entity("opportunityclose");
            opportunityClose["opportunityid"] = opportunityEntity.ToEntityReference();
            opportunityClose["subject"] = "Lost!";
            opportunityClose["actualend"] = DateTime.Now;
            opportunityClose["description"] = "Lost!";

            LoseOpportunityRequest = new LoseOpportunityRequest
            {
                OpportunityClose = opportunityClose,
                Status = new OptionSetValue(5)
            };
        }
    }
}