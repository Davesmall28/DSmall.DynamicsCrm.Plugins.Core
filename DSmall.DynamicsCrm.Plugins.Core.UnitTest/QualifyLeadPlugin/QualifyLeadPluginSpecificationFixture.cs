namespace DSmall.DynamicsCrm.Plugins.Core.UnitTest
{
    using System;
    using Microsoft.Xrm.Sdk;

    /// <summary>The qualify lead plugin specification fixture.</summary>
    public class QualifyLeadPluginSpecificationFixture : SpecificationFixture<DummyQualifyLeadPlugin>
    {
        /// <summary>The perform test setup.</summary>
        public override void PerformTestSetup()
        {
            ServiceProvider = new ServiceProviderInitializer().Setup().WithInputParameters(GetDummyInputParameters());
        }

        private ParameterCollection GetDummyInputParameters()
        {
            return new ParameterCollection
            {
                { "LeadId", new EntityReference("lead", Guid.NewGuid()) },
                { "CreateAccount", true },
                { "CreateContact", true },
                { "CreateOpportunity", true },
                { "OpportunityCustomerId", new EntityReference("contact", Guid.NewGuid()) },
                { "SourceCampaignId", new EntityReference("campaign", Guid.NewGuid()) },
                { "Status", new OptionSetValue(1) },
                { "OpportunityCurrencyId", new EntityReference("currency", Guid.NewGuid()) },
            };
        }
    }
}