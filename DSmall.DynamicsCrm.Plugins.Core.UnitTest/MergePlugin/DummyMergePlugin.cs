namespace DSmall.DynamicsCrm.Plugins.Core.UnitTest
{
    using System;
    using Microsoft.Xrm.Sdk;

    /// <summary>The dummy merge plugin.</summary>
    public class DummyMergePlugin : MergePlugin
    {
        /// <summary>Gets the organization service.</summary>
        public IOrganizationService OrganizationService { get; private set; }

        /// <summary>Gets the plugin execution context.</summary>
        public IPluginExecutionContext PluginExecutionContext { get; private set; }

        /// <summary>Gets the tracing service.</summary>
        public ITracingService TracingService { get; private set; }

        /// <summary>Gets the target entity.</summary>
        public EntityReference TargetEntity { get; private set; }

        /// <summary>Gets the subordinate id.</summary>
        public Guid SubordinateId { get; private set; }

        /// <summary>Gets the update content.</summary>
        public Entity UpdateContent { get; private set; }

        /// <summary>The execute.</summary>
        /// <param name="organizationService">The organization service.</param>
        /// <param name="pluginExecutionContext">The plugin execution context.</param>
        /// <param name="tracingService">The tracing service.</param>
        /// <param name="target">The target entity.</param>
        /// <param name="subordinateId">The subordinate id.</param>
        /// <param name="updateContent">The update content.</param>
        public override void Execute(
            IOrganizationService organizationService,
            IPluginExecutionContext pluginExecutionContext,
            ITracingService tracingService,
            EntityReference target,
            Guid subordinateId,
            Entity updateContent)
        {
            OrganizationService = organizationService;
            PluginExecutionContext = pluginExecutionContext;
            TracingService = tracingService;
            TargetEntity = target;
            SubordinateId = subordinateId;
            UpdateContent = updateContent;
        }
    }
}