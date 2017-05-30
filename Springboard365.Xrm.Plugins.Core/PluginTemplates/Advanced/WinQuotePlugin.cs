namespace Springboard365.Xrm.Plugins.Core
{
    using Microsoft.Xrm.Sdk;

    public abstract class WinQuotePlugin : Plugin
    {
        public override void Execute(
            IOrganizationService organizationService,
            IPluginExecutionContext pluginExecutionContext,
            ITracingService tracingService)
        {
            var quoteClose = pluginExecutionContext.InputParameters.GetParameter<Entity>(InputParameterType.QuoteClose);
            var status = pluginExecutionContext.InputParameters.GetParameter<OptionSetValue>(InputParameterType.Status);

            Execute(organizationService, pluginExecutionContext, tracingService, quoteClose, status);
        }

        public abstract void Execute(
            IOrganizationService organizationService,
            IPluginExecutionContext pluginExecutionContext,
            ITracingService tracingService,
            Entity quoteClose,
            OptionSetValue status);
    }
}