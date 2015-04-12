namespace DSmall.DynamicsCrm.Plugins.Core
{
    using Microsoft.Xrm.Sdk;

    /// <summary>The win or close quote plugin.</summary>
    public abstract class WinOrCloseQuotePlugin : Plugin
    {
        private const string QuoteLogicalName = "quote";
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

            var quoteClose = pluginExecutionContext.InputParameters.GetParameter<Entity>(InputParameterType.QuoteClose);
            var status = pluginExecutionContext.InputParameters.GetParameter<OptionSetValue>(InputParameterType.Status);
            var state = stateRetriever.GetStateCodeFromStatusCode(status.Value, QuoteLogicalName);

            Execute(organizationService, pluginExecutionContext, tracingService, quoteClose, state, status);
        }

        /// <summary>The execute.</summary>
        /// <param name="organizationService">The organization service.</param>
        /// <param name="pluginExecutionContext">The plugin execution context.</param>
        /// <param name="tracingService">The tracing service.</param>
        /// <param name="quoteClose">The quote close entity.</param>
        /// <param name="state">The state.</param>
        /// <param name="status">The status.</param>
        public abstract void Execute(
            IOrganizationService organizationService,
            IPluginExecutionContext pluginExecutionContext,
            ITracingService tracingService,
            Entity quoteClose,
            OptionSetValue state,
            OptionSetValue status);
    }
}
