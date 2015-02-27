namespace DSmall.DynamicsCrm.Plugins.Core
{
    using System;
    using Microsoft.Xrm.Sdk;

    /// <summary>The merge records plugin.</summary>
    public abstract class MergePlugin : Plugin
    {
        /// <summary>The execute.</summary>
        /// <param name="organizationService">The organization service.</param>
        /// <param name="pluginExecutionContext">The plugin execution context.</param>
        /// <param name="tracingService">The tracing service.</param>
        public override void Execute(IOrganizationService organizationService, IPluginExecutionContext pluginExecutionContext, ITracingService tracingService)
        {
            var targetEntityReference = pluginExecutionContext.InputParameters.GetParameter<EntityReference>(InputParameterType.Target);
            var subordinateId = pluginExecutionContext.InputParameters.GetParameter<Guid>(InputParameterType.SubordinateId);
            var updateContent = pluginExecutionContext.InputParameters.GetParameter<Entity>(InputParameterType.UpdateContent);
            
            Execute(organizationService, pluginExecutionContext, tracingService, targetEntityReference, subordinateId, updateContent);
        }

        /// <summary>The execute.</summary>
        /// <param name="organizationService">The organization service.</param>
        /// <param name="pluginExecutionContext">The plugin execution context.</param>
        /// <param name="tracingService">The tracing service.</param>
        /// <param name="targetEntity">The target entity.</param>
        /// <param name="subordinateId">The subordinate id.</param>
        /// <param name="updateContent">The update content.</param>
        public abstract void Execute(
            IOrganizationService organizationService,
            IPluginExecutionContext pluginExecutionContext,
            ITracingService tracingService,
            EntityReference targetEntity, 
            Guid subordinateId, 
            Entity updateContent);
    }
}
