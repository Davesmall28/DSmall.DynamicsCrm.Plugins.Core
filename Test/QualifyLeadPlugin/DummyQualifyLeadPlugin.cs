namespace Springboard365.Xrm.Plugins.Core.Test
{
    using Microsoft.Xrm.Sdk;

    public class DummyQualifyLeadPlugin : QualifyLeadPlugin
    {
        public IOrganizationService OrganizationService { get; private set; }

        public IPluginExecutionContext PluginExecutionContext { get; private set; }

        public ITracingService TracingService { get; private set; }

        public EntityReference LeadId { get; private set; }

        public bool CreateAccount { get; private set; }

        public bool CreateContact { get; private set; }

        public bool CreateOpportunity { get; private set; }

        public EntityReference OpportunityCustomerId { get; private set; }

        public EntityReference SourceCampaignId { get; private set; }

        public OptionSetValue Status { get; private set; }

        public EntityReference OpportunityCurrencyId { get; private set; }

        protected override void Execute(
            IOrganizationService organizationService,
            IPluginExecutionContext pluginExecutionContext,
            ITracingService tracingService,
            EntityReference leadId,
            bool createAccount,
            bool createContact,
            bool createOpportunity,
            EntityReference opportunityCustomerId,
            EntityReference sourceCampaignId,
            OptionSetValue status,
            EntityReference opportunityCurrencyId)
        {
            OrganizationService = organizationService;
            PluginExecutionContext = pluginExecutionContext;
            TracingService = tracingService;
            LeadId = leadId;
            CreateAccount = createAccount;
            CreateContact = createContact;
            CreateOpportunity = createOpportunity;
            OpportunityCustomerId = opportunityCustomerId;
            SourceCampaignId = sourceCampaignId;
            Status = status;
            OpportunityCurrencyId = opportunityCurrencyId;
        }
    }
}