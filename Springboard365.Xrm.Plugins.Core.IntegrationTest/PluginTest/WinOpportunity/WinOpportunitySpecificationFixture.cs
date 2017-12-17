namespace Springboard365.Xrm.Plugins.Core.IntegrationTest
{
    using System;
    using Microsoft.Crm.Sdk.Messages;
    using Microsoft.Xrm.Sdk;

    public class WinOpportunitySpecificationFixture : SpecificationFixtureBase
    {
        public WinOpportunityRequest WinOpportunityRequest { get; private set; }

        public WinOpportunitySpecificationFixture()
            : base("Win")
        {
        }

        public void PerformTestSetup()
        {
            var opportunityEntity = EntityFactory.CreateOpportunity();

            var opportunityClose = new Entity("opportunityclose");
            opportunityClose["opportunityid"] = opportunityEntity.ToEntityReference();
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