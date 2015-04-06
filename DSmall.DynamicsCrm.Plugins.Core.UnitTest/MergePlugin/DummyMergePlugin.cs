namespace DSmall.DynamicsCrm.Plugins.Core.UnitTest
{
    using System;
    using Microsoft.Xrm.Sdk;

    /// <summary>The dummy merge plugin.</summary>
    public class DummyMergePlugin : MergePlugin
    {
        /// <summary>Gets or sets the organization service.</summary>
        public IOrganizationService OrganizationService { get; set; }

        /// <summary>Gets or sets the plugin execution context.</summary>
        public IPluginExecutionContext PluginExecutionContext { get; set; }

        /// <summary>Gets or sets the tracing service.</summary>
        public ITracingService TracingService { get; set; }

        /// <summary>Gets or sets the target entity.</summary>
        public EntityReference TargetEntity { get; set; }

        /// <summary>Gets or sets the subordinate id.</summary>
        public Guid SubordinateId { get; set; }

        /// <summary>Gets or sets the update content.</summary>
        public Entity UpdateContent { get; set; }

        /// <summary>The execute.</summary>
        /// <param name="organizationService">The organization service.</param>
        /// <param name="pluginExecutionContext">The plugin execution context.</param>
        /// <param name="tracingService">The tracing service.</param>
        /// <param name="targetEntity">The target entity.</param>
        /// <param name="subordinateId">The subordinate id.</param>
        /// <param name="updateContent">The update content.</param>
        public override void Execute(
            IOrganizationService organizationService,
            IPluginExecutionContext pluginExecutionContext,
            ITracingService tracingService,
            EntityReference targetEntity,
            Guid subordinateId,
            Entity updateContent)
        {
            OrganizationService = organizationService;
            PluginExecutionContext = pluginExecutionContext;
            TracingService = tracingService;
            TargetEntity = targetEntity;
            SubordinateId = subordinateId;
            UpdateContent = updateContent;
        }
    }
}