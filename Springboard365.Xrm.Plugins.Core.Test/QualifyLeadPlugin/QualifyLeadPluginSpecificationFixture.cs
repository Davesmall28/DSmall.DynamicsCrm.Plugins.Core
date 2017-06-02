namespace Springboard365.Xrm.Plugins.Core.Test
{
    using System;
    using Microsoft.Xrm.Sdk;
    using Springboard365.Xrm.UnitTest.Core;

    public class QualifyLeadPluginSpecificationFixture : SpecificationFixture<DummyQualifyLeadPlugin>
    {
        public override void PerformTestSetup()
        {
            ServiceProvider = ServiceProviderInitializer.Setup().WithInputParameters(() => new ParameterCollection
            {
                { InputParameterType.LeadId, new EntityReference("lead", Guid.NewGuid()) },
                { InputParameterType.CreateAccount, true },
                { InputParameterType.CreateContact, true },
                { InputParameterType.CreateOpportunity, true },
                { InputParameterType.OpportunityCustomerId, new EntityReference("contact", Guid.NewGuid()) },
                { InputParameterType.SourceCampaignId, new EntityReference("campaign", Guid.NewGuid()) },
                { InputParameterType.Status, new OptionSetValue(1) },
                { InputParameterType.OpportunityCurrencyId, new EntityReference("currency", Guid.NewGuid()) },
            });
        }
    }
}