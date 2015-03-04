namespace DSmall.DynamicsCrm.Plugins.Core.UnitTest
{
    using Microsoft.Xrm.Sdk;

    /// <summary>The dummy plugin.</summary>
    public class DummyPlugin : Plugin
    {
        /// <summary>Gets or sets the organization service.</summary>
        public IOrganizationService OrganizationService { get; set; }

        /// <summary>Gets or sets the plugin execution context.</summary>
        public IPluginExecutionContext PluginExecutionContext { get; set; }

        /// <summary>Gets or sets the tracing service.</summary>
        public ITracingService TracingService { get; set; }

        /// <summary>The execute.</summary>
        /// <param name="organizationService">The organization service.</param>
        /// <param name="pluginExecutionContext">The plugin execution context.</param>
        /// <param name="tracingService">The tracing service.</param>
        public override void Execute(
            IOrganizationService organizationService,
            IPluginExecutionContext pluginExecutionContext,
            ITracingService tracingService)
        {
            OrganizationService = organizationService;
            PluginExecutionContext = pluginExecutionContext;
            TracingService = tracingService;
        }
    }
}