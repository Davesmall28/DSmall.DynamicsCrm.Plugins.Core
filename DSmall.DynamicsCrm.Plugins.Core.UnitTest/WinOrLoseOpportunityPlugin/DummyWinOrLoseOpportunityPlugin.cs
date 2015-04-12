namespace DSmall.DynamicsCrm.Plugins.Core.UnitTest
{
    using Microsoft.Xrm.Sdk;

    /// <summary>The dummy win or lose opportunity plugin.</summary>
    public class DummyWinOrLoseOpportunityPlugin : WinOrLoseOpportunityPlugin
    {
        /// <summary>Gets the organization service.</summary>
        public IOrganizationService OrganizationService { get; private set; }

        /// <summary>Gets the plugin execution context.</summary>
        public IPluginExecutionContext PluginExecutionContext { get; private set; }

        /// <summary>Gets the tracing service.</summary>
        public ITracingService TracingService { get; private set; }

        /// <summary>Gets the invoice id.</summary>
        public Entity OpportunityClose { get; private set; }

        /// <summary>Gets the state.</summary>
        public OptionSetValue State { get; private set; }

        /// <summary>Gets the status.</summary>
        public OptionSetValue Status { get; private set; }
        
        /// <summary>The execute.</summary>
        /// <param name="organizationService">The organization service.</param>
        /// <param name="pluginExecutionContext">The plugin execution context.</param>
        /// <param name="tracingService">The tracing service.</param>
        /// <param name="opportunityClose">The opportunity close.</param>
        /// <param name="state">The state.</param>
        /// <param name="status">The status.</param>
        public override void Execute(
            IOrganizationService organizationService,
            IPluginExecutionContext pluginExecutionContext,
            ITracingService tracingService,
            Entity opportunityClose,
            OptionSetValue state,
            OptionSetValue status)
        {
            OrganizationService = organizationService;
            PluginExecutionContext = pluginExecutionContext;
            TracingService = tracingService;
            OpportunityClose = opportunityClose;
            State = state;
            Status = status;
        }
    }
}