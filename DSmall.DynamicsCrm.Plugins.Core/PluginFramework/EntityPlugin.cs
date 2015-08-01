namespace DSmall.DynamicsCrm.Plugins.Core
{
    using DSmall.DynamicsCrm.Core;
    using Microsoft.Xrm.Sdk;

    /// <summary> The entity plugin </summary>
    public abstract class EntityPlugin : Plugin
    {
        /// <summary>The execute.</summary>
        /// <param name="organizationService">The organization service.</param>
        /// <param name="pluginExecutionContext">The plugin execution context.</param>
        /// <param name="tracingService">The tracing service.</param>
        public override void Execute(IOrganizationService organizationService, IPluginExecutionContext pluginExecutionContext, ITracingService tracingService)
        {
            var targetEntity = EntityValidator.GetValidCrmTargetEntity<Entity>(pluginExecutionContext, EntityImageType.Target);

            Execute(organizationService, pluginExecutionContext, tracingService, targetEntity);
        }

        /// <summary>The execute.</summary>
        /// <param name="organizationService">The organization service.</param>
        /// <param name="pluginExecutionContext">The plugin execution context.</param>
        /// <param name="tracingService">The tracing service.</param>
        /// <param name="targetEntity">The target entity.</param>
        public abstract void Execute(IOrganizationService organizationService, IPluginExecutionContext pluginExecutionContext, ITracingService tracingService, Entity targetEntity);
    }
}