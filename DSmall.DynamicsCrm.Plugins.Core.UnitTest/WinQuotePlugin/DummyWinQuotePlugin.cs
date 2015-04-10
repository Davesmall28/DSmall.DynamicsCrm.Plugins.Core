namespace DSmall.DynamicsCrm.Plugins.Core.UnitTest
{
    using Microsoft.Xrm.Sdk;

    /// <summary>The dummy win quote plugin.</summary>
    public class DummyWinQuotePlugin : WinQuotePlugin
    {
        /// <summary>Gets or sets the organization service.</summary>
        public IOrganizationService OrganizationService { get; set; }

        /// <summary>Gets or sets the plugin execution context.</summary>
        public IPluginExecutionContext PluginExecutionContext { get; set; }

        /// <summary>Gets or sets the tracing service.</summary>
        public ITracingService TracingService { get; set; }

        /// <summary>Gets or sets the quote close entity.</summary>
        public Entity QuoteClose { get; set; }

        /// <summary>Gets or sets the status.</summary>
        public OptionSetValue Status { get; set; }

        /// <summary>The execute.</summary>
        /// <param name="organizationService">The organization service.</param>
        /// <param name="pluginExecutionContext">The plugin execution context.</param>
        /// <param name="tracingService">The tracing service.</param>
        /// <param name="quoteClose">The quote close entity.</param>
        /// <param name="status">The status.</param>
        public override void Execute(
            IOrganizationService organizationService,
            IPluginExecutionContext pluginExecutionContext,
            ITracingService tracingService,
            Entity quoteClose,
            OptionSetValue status)
        {
            OrganizationService = organizationService;
            PluginExecutionContext = pluginExecutionContext;
            TracingService = tracingService;
            QuoteClose = quoteClose;
            Status = status;
        }
    }
}