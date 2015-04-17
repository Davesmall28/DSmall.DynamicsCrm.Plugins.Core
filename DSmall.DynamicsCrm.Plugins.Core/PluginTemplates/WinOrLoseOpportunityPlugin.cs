namespace DSmall.DynamicsCrm.Plugins.Core
{
    using DSmall.DynamicsCrm.Core;
    using Microsoft.Xrm.Sdk;

    /// <summary>The win or Lose opportunity plugin.</summary>
    public abstract class WinOrLoseOpportunityPlugin : Plugin
    {
        private const string OpportunityLogicalName = "opportunity";
        private IStateRetriever stateRetriever;

        /// <summary>The execute.</summary>
        /// <param name="organizationService">The organization service.</param>
        /// <param name="pluginExecutionContext">The plugin execution context.</param>
        /// <param name="tracingService">The tracing service.</param>
        public override void Execute(
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

        /// <summary>The execute.</summary>
        /// <param name="organizationService">The organization service.</param>
        /// <param name="pluginExecutionContext">The plugin execution context.</param>
        /// <param name="tracingService">The tracing service.</param>
        /// <param name="opportunityClose">The opportunity close entity.</param>
        /// <param name="state">The state.</param>
        /// <param name="status">The status.</param>
        public abstract void Execute(
            IOrganizationService organizationService,
            IPluginExecutionContext pluginExecutionContext,
            ITracingService tracingService,
            Entity opportunityClose,
            OptionSetValue state,
            OptionSetValue status);
    }
}
