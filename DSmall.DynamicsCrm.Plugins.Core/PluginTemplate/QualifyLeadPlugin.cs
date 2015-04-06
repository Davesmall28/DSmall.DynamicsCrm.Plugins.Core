namespace DSmall.DynamicsCrm.Plugins.Core
{
    using Microsoft.Xrm.Sdk;

    /// <summary>The qualify lead plugin.</summary>
    public abstract class QualifyLeadPlugin : Plugin
    {
        /// <summary>The execute.</summary>
        /// <param name="organizationService">The organization service.</param>
        /// <param name="pluginExecutionContext">The plugin execution context.</param>
        /// <param name="tracingService">The tracing service.</param>
        public override void Execute(
            IOrganizationService organizationService,
            IPluginExecutionContext pluginExecutionContext,
            ITracingService tracingService)
        {
            var leadId = pluginExecutionContext.InputParameters.GetParameter<EntityReference>(InputParameterType.LeadId);
            var createAccount = pluginExecutionContext.InputParameters.GetParameter<bool>(InputParameterType.CreateAccount);
            var createContact = pluginExecutionContext.InputParameters.GetParameter<bool>(InputParameterType.CreateContact);
            var createOpportunity = pluginExecutionContext.InputParameters.GetParameter<bool>(InputParameterType.CreateOpportunity);
            var opportunityCustomerId = pluginExecutionContext.InputParameters.GetParameter<EntityReference>(InputParameterType.OpportunityCustomerId);
            var sourceCampaignId = pluginExecutionContext.InputParameters.GetParameter<EntityReference>(InputParameterType.SourceCampaignId);
            var status = pluginExecutionContext.InputParameters.GetParameter<OptionSetValue>(InputParameterType.Status);
            var opportunityCurrencyId = pluginExecutionContext.InputParameters.GetParameter<EntityReference>(InputParameterType.OpportunityCurrencyId);

            Execute(organizationService, pluginExecutionContext, tracingService, leadId, createAccount, createContact, createOpportunity, opportunityCustomerId, sourceCampaignId, status, opportunityCurrencyId);
        }

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
        public abstract void Execute(
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
            EntityReference opportunityCurrencyId);
    }
}
