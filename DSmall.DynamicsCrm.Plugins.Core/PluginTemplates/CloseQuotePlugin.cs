namespace DSmall.DynamicsCrm.Plugins.Core
{
    using Microsoft.Xrm.Sdk;

    /// <summary>The close quote plugin.</summary>
    public abstract class CloseQuotePlugin : Plugin
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
            var quoteClose = pluginExecutionContext.InputParameters.GetParameter<Entity>(InputParameterType.QuoteClose);
            var status = pluginExecutionContext.InputParameters.GetParameter<OptionSetValue>(InputParameterType.Status);

            Execute(organizationService, pluginExecutionContext, tracingService, quoteClose, status);
        }

        /// <summary>The execute.</summary>
        /// <param name="organizationService">The organization service.</param>
        /// <param name="pluginExecutionContext">The plugin execution context.</param>
        /// <param name="tracingService">The tracing service.</param>
        /// <param name="quoteClose">The quote close entity.</param>
        /// <param name="status">The status.</param>
        public abstract void Execute(
            IOrganizationService organizationService,
            IPluginExecutionContext pluginExecutionContext,
            ITracingService tracingService,
            Entity quoteClose,
            OptionSetValue status);
    }
}
