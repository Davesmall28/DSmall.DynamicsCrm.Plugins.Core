namespace Springboard365.Xrm.Plugins.Core.IntegrationTest
{
    using System;
    using Microsoft.Crm.Sdk.Messages;
    using Microsoft.Xrm.Sdk;

    public class LoseOpportunitySpecificationFixture : SpecificationFixtureBase
    {
        public LoseOpportunityRequest LoseOpportunityRequest { get; private set; }

        public LoseOpportunitySpecificationFixture()
            : base("Lose")
        {
        }

        public void PerformTestSetup()
        {
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