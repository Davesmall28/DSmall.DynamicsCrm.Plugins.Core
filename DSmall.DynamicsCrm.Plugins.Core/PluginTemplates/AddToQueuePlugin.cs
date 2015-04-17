namespace DSmall.DynamicsCrm.Plugins.Core
{
    using System;
    using Microsoft.Xrm.Sdk;

    /// <summary>The add to queue plugin.</summary>
    public abstract class AddToQueuePlugin : Plugin
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
            var target = pluginExecutionContext.InputParameters.GetParameter<EntityReference>(InputParameterType.Target);
            var destinationQueueId = pluginExecutionContext.InputParameters.GetParameter<Guid>(InputParameterType.DestinationQueueId);
            var sourceQueueId = pluginExecutionContext.InputParameters.GetParameter<Guid>(InputParameterType.SourceQueueId);

            Execute(organizationService, pluginExecutionContext, tracingService, target, destinationQueueId, sourceQueueId);
        }

        /// <summary>The execute.</summary>
        /// <param name="organizationService">The organization service.</param>
        /// <param name="pluginExecutionContext">The plugin execution context.</param>
        /// <param name="tracingService">The tracing service.</param>
        /// <param name="target">The target.</param>
        /// <param name="destinationQueueId">The destination queue id.</param>
        /// <param name="sourceQueueId">The source queue id.</param>
        public abstract void Execute(
            IOrganizationService organizationService,
            IPluginExecutionContext pluginExecutionContext,
            ITracingService tracingService,
            EntityReference target,
            Guid destinationQueueId,
            Guid sourceQueueId);
    }
}
