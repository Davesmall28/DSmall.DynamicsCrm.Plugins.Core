namespace Springboard365.Xrm.Plugins.Core
{
    using Microsoft.Xrm.Sdk;
    using Springboard365.Xrm.Plugins.Core.Constants;
    using Springboard365.Xrm.Plugins.Core.Extensions;
    using Springboard365.Xrm.Plugins.Core.Framework;

    public abstract class DisassociatePlugin : Plugin
    {
        protected override void Execute(
            IOrganizationService organizationService,
            IPluginExecutionContext pluginExecutionContext,
            ITracingService tracingService)
        {
            var targetEntity = pluginExecutionContext.InputParameters.GetParameter<EntityReference>(InputParameterType.Target);
            var relationship = pluginExecutionContext.InputParameters.GetParameter<Relationship>(InputParameterType.Relationship);
            var relatedEntities = pluginExecutionContext.InputParameters.GetParameter<EntityReferenceCollection>(InputParameterType.RelatedEntities);

            Execute(organizationService, pluginExecutionContext, tracingService, targetEntity, relationship, relatedEntities);
        }

        protected abstract void Execute(
            IOrganizationService organizationService,
            IPluginExecutionContext pluginExecutionContext,
            ITracingService tracingService,
            EntityReference target,
            Relationship relationship,
            EntityReferenceCollection relatedEntities);
    }
}