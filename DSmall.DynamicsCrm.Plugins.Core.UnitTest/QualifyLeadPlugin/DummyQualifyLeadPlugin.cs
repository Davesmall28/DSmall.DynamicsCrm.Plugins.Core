namespace DSmall.DynamicsCrm.Plugins.Core.UnitTest
{
    using Microsoft.Xrm.Sdk;

    /// <summary>The dummy qualify lead plugin.</summary>
    public class DummyQualifyLeadPlugin : QualifyLeadPlugin
    {
        /// <summary>Gets the organization service.</summary>
        public IOrganizationService OrganizationService { get; private set; }

        /// <summary>Gets the plugin execution context.</summary>
        public IPluginExecutionContext PluginExecutionContext { get; private set; }

        /// <summary>Gets the tracing service.</summary>
        public ITracingService TracingService { get; private set; }

        /// <summary>Gets the lead id.</summary>
        public EntityReference LeadId { get; private set; }

        /// <summary>Gets or sets a value indicating whether create account.</summary>
        public bool CreateAccount { get; private set; }

        /// <summary>Gets or sets a value indicating whether create contact.</summary>
        public bool CreateContact { get; private set; }

        /// <summary>Gets or sets a value indicating whether create opportunity.</summary>
        public bool CreateOpportunity { get; private set; }

        /// <summary>Gets the opportunity customer id.</summary>
        public EntityReference OpportunityCustomerId { get; private set; }

        /// <summary>Gets the source campaign id.</summary>
        public EntityReference SourceCampaignId { get; private set; }

        /// <summary>Gets the status.</summary>
        public OptionSetValue Status { get; private set; }

        /// <summary>Gets the opportunity currency id.</summary>
        public EntityReference OpportunityCurrencyId { get; private set; }

        /// <summary>The execute.</summary>
        /// <param name="organizationService">The organization service.</param>
        /// <param name="pluginExecutionContext">The plugin execution context.</param>
        /// <param name="tracingService">The tracing service.</param>
        /// <param name="leadId">The lead id.</param>
        /// <param name="createAccount">The create account.</param>
        /// <param name="createContact">The create contact.</param>
        /// <param name="createOpportunity">The create opportunity.</param>
        /// <param name="opportunityCustomerId">The opportunity customer id.</param>
        /// <param name="sourceCampaignId">The source campaign id.</param>
        /// <param name="status">The status.</param>
        /// <param name="opportunityCurrencyId">The opportunity currency id.</param>
        public override void Execute(
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