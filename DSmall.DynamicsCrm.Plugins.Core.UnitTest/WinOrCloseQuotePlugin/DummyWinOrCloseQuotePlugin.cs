namespace DSmall.DynamicsCrm.Plugins.Core.UnitTest
{
    using Microsoft.Xrm.Sdk;

    /// <summary>The dummy win or close quote plugin.</summary>
    public class DummyWinOrCloseQuotePlugin : WinOrCloseQuotePlugin
    {
        /// <summary>Gets the organization service.</summary>
        public IOrganizationService OrganizationService { get; private set; }

        /// <summary>Gets the plugin execution context.</summary>
        public IPluginExecutionContext PluginExecutionContext { get; private set; }

        /// <summary>Gets the tracing service.</summary>
        public ITracingService TracingService { get; private set; }

        /// <summary>Gets the quote close entity.</summary>
        public Entity QuoteClose { get; private set; }

        /// <summary>Gets the state.</summary>
        public OptionSetValue State { get; private set; }

        /// <summary>Gets the status.</summary>
        public OptionSetValue Status { get; private set; }

        /// <summary>The execute.</summary>
        /// <param name="organizationService">The organization service.</param>
        /// <param name="pluginExecutionContext">The plugin execution context.</param>
        /// <param name="tracingService">The tracing service.</param>
        /// <param name="quoteClose">The quote close.</param>
        /// <param name="state">The state.</param>
        /// <param name="status">The status.</param>
        public override void Execute(
            IOrganizationService organizationService,
            IPluginExecutionContext pluginExecutionContext,
            ITracingService tracingService,
            Entity quoteClose,
            OptionSetValue state,
            OptionSetValue status)
        {
            OrganizationService = organizationService;
            PluginExecutionContext = pluginExecutionContext;
            TracingService = tracingService;
            QuoteClose = quoteClose;
            Status = status;
            State = state;
        }
    }
}