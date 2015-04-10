namespace DSmall.DynamicsCrm.Plugins.Core.UnitTest
{
    using System;
    using Microsoft.Xrm.Sdk;

    /// <summary>The dummy add to queue plugin.</summary>
    public class DummyAddToQueuePlugin : AddToQueuePlugin
    {
        /// <summary>Gets the organization service.</summary>
        public IOrganizationService OrganizationService { get; private set; }

        /// <summary>Gets the plugin execution context.</summary>
        public IPluginExecutionContext PluginExecutionContext { get; private set; }

        /// <summary>Gets the tracing service.</summary>
        public ITracingService TracingService { get; private set; }

        /// <summary>Gets the target.</summary>
        public EntityReference Target { get; private set; }

        /// <summary>Gets the destination queue id.</summary>
        public Guid DestinationQueueId { get; private set; }

        /// <summary>Gets the source queue id.</summary>
        public Guid SourceQueueId { get; private set; }

        /// <summary>The execute.</summary>
        /// <param name="organizationService">The organization service.</param>
        /// <param name="pluginExecutionContext">The plugin execution context.</param>
        /// <param name="tracingService">The tracing service.</param>
        /// <param name="target">The target.</param>
        /// <param name="destinationQueueId">The destination queue id.</param>
        /// <param name="sourceQueueId">The source queue id.</param>
        public override void Execute(
            IOrganizationService organizationService,
            IPluginExecutionContext pluginExecutionContext,
            ITracingService tracingService,
            EntityReference target,
            Guid destinationQueueId,
            Guid sourceQueueId)
        {
            OrganizationService = organizationService;
            PluginExecutionContext = pluginExecutionContext;
            TracingService = tracingService;
            Target = target;
            DestinationQueueId = destinationQueueId;
            SourceQueueId = sourceQueueId;
        }
    }
}