namespace Springboard365.Xrm.Plugins.Core
{
    using Microsoft.Xrm.Sdk;
    using Springboard365.Xrm.Core;
    using Springboard365.Xrm.Plugins.Core.Constants;
    using Springboard365.Xrm.Plugins.Core.Extensions;
    using Springboard365.Xrm.Plugins.Core.Framework;

    public abstract class WinOrCloseQuotePlugin : Plugin
    {
        private const string QuoteLogicalName = "quote";
        private IStateRetriever stateRetriever;

        protected override void Execute(
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

        protected abstract void Execute(
            IOrganizationService organizationService,
            IPluginExecutionContext pluginExecutionContext,
            ITracingService tracingService,
            Entity quoteClose,
            OptionSetValue state,
            OptionSetValue status);
    }
}