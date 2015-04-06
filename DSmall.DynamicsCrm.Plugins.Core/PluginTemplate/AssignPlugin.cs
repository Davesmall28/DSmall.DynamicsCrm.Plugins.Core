namespace DSmall.DynamicsCrm.Plugins.Core
{
    using Microsoft.Xrm.Sdk;

    /// <summary>The assign plugin.</summary>
    public abstract class AssignPlugin : Plugin
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
            var targetEntity = pluginExecutionContext.InputParameters.GetParameter<EntityReference>(InputParameterType.Target);
            var assignee = pluginExecutionContext.InputParameters.GetParameter<EntityReference>(InputParameterType.Assignee);

            Execute(organizationService, pluginExecutionContext, tracingService, targetEntity, assignee);
        }

        /// <summary>The execute.</summary>
        /// <param name="organizationService">The organization service.</param>
        /// <param name="pluginExecutionContext">The plugin execution context.</param>
        /// <param name="tracingService">The tracing service.</param>
        /// <param name="target">The target.</param>
        /// <param name="assignee">The assignee.</param>
        public abstract void Execute(
            IOrganizationService organizationService,
            IPluginExecutionContext pluginExecutionContext,
            ITracingService tracingService,
            EntityReference target,
            EntityReference assignee);
    }
}