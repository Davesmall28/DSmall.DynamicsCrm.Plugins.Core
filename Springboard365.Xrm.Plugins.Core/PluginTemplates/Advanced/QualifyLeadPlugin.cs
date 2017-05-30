namespace Springboard365.Xrm.Plugins.Core
{
    using Microsoft.Xrm.Sdk;

    public abstract class QualifyLeadPlugin : Plugin
    {
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