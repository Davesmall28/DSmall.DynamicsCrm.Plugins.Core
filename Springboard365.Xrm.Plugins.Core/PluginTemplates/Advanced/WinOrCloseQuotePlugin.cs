namespace Springboard365.Xrm.Plugins.Core
{
    using Microsoft.Xrm.Sdk;
    using Springboard365.Xrm.Core;

    public abstract class WinOrCloseQuotePlugin : Plugin
    {
        private const string QuoteLogicalName = "quote";
        private IStateRetriever stateRetriever;

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

        public abstract void Execute(
            IOrganizationService organizationService,
            IPluginExecutionContext pluginExecutionContext,
            ITracingService tracingService,
            Entity quoteClose,
            OptionSetValue state,
            OptionSetValue status);
    }
}