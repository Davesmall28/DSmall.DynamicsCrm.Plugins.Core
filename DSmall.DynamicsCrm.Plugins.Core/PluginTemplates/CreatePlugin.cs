namespace DSmall.DynamicsCrm.Plugins.Core
{
    using DSmall.DynamicsCrm.Core;
    using Microsoft.Xrm.Sdk;

    /// <summary>The create plugin </summary>
    public abstract class CreatePlugin : Plugin
    {
        /// <summary>The execute.</summary>
        /// <param name="organizationService">The organization service.</param>
        /// <param name="pluginExecutionContext">The plugin execution context.</param>
        /// <param name="tracingService">The tracing service.</param>
        public override void Execute(IOrganizationService organizationService, IPluginExecutionContext pluginExecutionContext, ITracingService tracingService)
        {
            var target = EntityValidator.GetValidCrmTargetEntity<Entity>(pluginExecutionContext, EntityImageType.Target);

            Execute(organizationService, pluginExecutionContext, tracingService, target);
        }

        /// <summary>The execute.</summary>
        /// <param name="organizationService">The organization service.</param>
        /// <param name="pluginExecutionContext">The plugin execution context.</param>
        /// <param name="tracingService">The tracing service.</param>
        /// <param name="target">The target entity.</param>
        public abstract void Execute(
            IOrganizationService organizationService, 
            IPluginExecutionContext pluginExecutionContext, 
            ITracingService tracingService, 
            Entity target);
    }
}
