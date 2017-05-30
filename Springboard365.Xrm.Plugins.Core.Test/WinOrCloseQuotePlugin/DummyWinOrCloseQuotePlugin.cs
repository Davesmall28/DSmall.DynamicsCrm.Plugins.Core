namespace Springboard365.Xrm.Plugins.Core.Test
{
    using Microsoft.Xrm.Sdk;

    public class DummyWinOrCloseQuotePlugin : WinOrCloseQuotePlugin
    {
        public IOrganizationService OrganizationService { get; private set; }

        public IPluginExecutionContext PluginExecutionContext { get; private set; }

        public ITracingService TracingService { get; private set; }

        public Entity QuoteClose { get; private set; }

        public OptionSetValue State { get; private set; }

        public OptionSetValue Status { get; private set; }

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