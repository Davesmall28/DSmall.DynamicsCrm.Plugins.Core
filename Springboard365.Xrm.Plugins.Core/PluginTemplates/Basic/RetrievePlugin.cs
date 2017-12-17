namespace Springboard365.Xrm.Plugins.Core
{
    using Microsoft.Xrm.Sdk;
    using Microsoft.Xrm.Sdk.Query;
    using Springboard365.Xrm.Plugins.Core.Constants;
    using Springboard365.Xrm.Plugins.Core.Extensions;
    using Springboard365.Xrm.Plugins.Core.Framework;

    public abstract class RetrievePlugin : Plugin
    {
        protected override void Execute(IOrganizationService organizationService, IPluginExecutionContext pluginExecutionContext, ITracingService tracingService)
        {
            var targetEntityReference = pluginExecutionContext.InputParameters.GetParameter<EntityReference>(InputParameterType.Target);
            var columnSet = pluginExecutionContext.InputParameters.GetParameter<ColumnSet>(InputParameterType.ColumnSet);
            var returnNotifications = pluginExecutionContext.InputParameters.GetParameter<bool>(InputParameterType.ReturnNotifications);
            var relatedEntitiesQuery = pluginExecutionContext.InputParameters.GetParameter<RelationshipQueryCollection>(InputParameterType.RelatedEntitiesQuery);

            Execute(organizationService, pluginExecutionContext, tracingService, targetEntityReference, columnSet, returnNotifications, relatedEntitiesQuery);
        }

        protected abstract void Execute(
            IOrganizationService organizationService,
            IPluginExecutionContext pluginExecutionContext,
            ITracingService tracingService,
            EntityReference targetEntityReference,
            ColumnSet columnSet,
            bool returnNotifications,
            RelationshipQueryCollection relatedEntitiesQuery);
    }
}