namespace Springboard365.Xrm.Plugins.Core
{
    using Microsoft.Xrm.Sdk;

    public abstract class AssociatePlugin : Plugin
    {
        public override void Execute(
            IOrganizationService organizationService,
            IPluginExecutionContext pluginExecutionContext,
            ITracingService tracingService)
        {
            var target = pluginExecutionContext.InputParameters.GetParameter<EntityReference>(InputParameterType.Target);
            var relationship = pluginExecutionContext.InputParameters.GetParameter<Relationship>(InputParameterType.Relationship);
            var relatedEntities = pluginExecutionContext.InputParameters.GetParameter<EntityReferenceCollection>(InputParameterType.RelatedEntities);

            Execute(organizationService, pluginExecutionContext, tracingService, target, relationship, relatedEntities);
        }

        public abstract void Execute(
            IOrganizationService organizationService,
            IPluginExecutionContext pluginExecutionContext,
            ITracingService tracingService,
            EntityReference target,
            Relationship relationship,
            EntityReferenceCollection relatedEntities);
    }
}