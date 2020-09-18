namespace Springboard365.Xrm.Plugins.Core
{
    using Microsoft.Xrm.Sdk;
    using Springboard365.Xrm.Core;
    using Springboard365.Xrm.Plugins.Core.Constants;
    using Springboard365.Xrm.Plugins.Core.Extensions;
    using Springboard365.Xrm.Plugins.Core.Framework;

    public abstract class WinOrLoseOpportunityPlugin : Plugin
    {
        private const string OpportunityLogicalName = "opportunity";
        private IStateRetriever stateRetriever;

        protected override void Execute(
            IOrganizationService organizationService,
            IPluginExecutionContext pluginExecutionContext,
            ITracingService tracingService)
        {
            stateRetriever = new StateRetriever(organizationService);

            var opportunityClose = pluginExecutionContext.InputParameters.GetParameter<Entity>(InputParameterType.OpportunityClose);
            var status = pluginExecutionContext.InputParameters.GetParameter<OptionSetValue>(InputParameterType.Status);
            var state = stateRetriever.GetStateCodeFromStatusCode(status.Value, OpportunityLogicalName);

            Execute(organizationService, pluginExecutionContext, tracingService, opportunityClose, state, status);
        }

        protected abstract void Execute(
            IOrganizationService organizationService,
            IPluginExecutionContext pluginExecutionContext,
            ITracingService tracingService,
            Entity opportunityClose,
            OptionSetValue state,
            OptionSetValue status);
    }
}