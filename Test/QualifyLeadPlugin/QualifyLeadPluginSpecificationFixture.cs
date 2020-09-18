namespace Springboard365.Xrm.Plugins.Core.Test
{
    using System;
    using Microsoft.Xrm.Sdk;
    using Springboard365.UnitTest.Xrm.Core;
    using Springboard365.Xrm.Plugins.Core.Constants;
    using Springboard365.Xrm.Plugins.Core.Test.Entities;

    public class QualifyLeadPluginSpecificationFixture : SpecificationFixture<DummyQualifyLeadPlugin>
    {
        public override void PerformTestSetup()
        {
            ServiceProvider = ServiceProviderInitializer.Setup().WithInputParameters(() => new ParameterCollection
            {
                { InputParameterType.LeadId, new EntityReference(Lead.EntityLogicalName, Guid.NewGuid()) },
                { InputParameterType.CreateAccount, true },
                { InputParameterType.CreateContact, true },
                { InputParameterType.CreateOpportunity, true },
                { InputParameterType.OpportunityCustomerId, new EntityReference(Contact.EntityLogicalName, Guid.NewGuid()) },
                { InputParameterType.SourceCampaignId, new EntityReference(Campaign.EntityLogicalName, Guid.NewGuid()) },
                { InputParameterType.Status, new OptionSetValue(1) },
                { InputParameterType.OpportunityCurrencyId, new EntityReference(Currency.EntityLogicalName, Guid.NewGuid()) },
            });
        }
    }
}