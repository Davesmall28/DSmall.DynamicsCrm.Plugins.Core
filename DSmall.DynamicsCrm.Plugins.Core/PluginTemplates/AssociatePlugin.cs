namespace DSmall.DynamicsCrm.Plugins.Core
{
    using Microsoft.Xrm.Sdk;

    /// <summary>The associate plugin.</summary>
    public abstract class AssociatePlugin : Plugin
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
            var relationship = pluginExecutionContext.InputParameters.GetParameter<Relationship>(InputParameterType.Relationship);
            var relatedEntities = pluginExecutionContext.InputParameters.GetParameter<EntityReferenceCollection>(InputParameterType.RelatedEntities);

            Execute(organizationService, pluginExecutionContext, tracingService, targetEntity, relationship, relatedEntities);
        }

        /// <summary>The execute.</summary>
        /// <param name="organizationService">The organization service.</param>
        /// <param name="pluginExecutionContext">The plugin execution context.</param>
        /// <param name="tracingService">The tracing service.</param>
        /// <param name="target">The target.</param>
        /// <param name="relationship">The relationship.</param>
        /// <param name="relatedEntities">The related entities.</param>
        public abstract void Execute(
            IOrganizationService organizationService,
            IPluginExecutionContext pluginExecutionContext,
            ITracingService tracingService,
            EntityReference target,
            Relationship relationship,
            EntityReferenceCollection relatedEntities);
    }
}
