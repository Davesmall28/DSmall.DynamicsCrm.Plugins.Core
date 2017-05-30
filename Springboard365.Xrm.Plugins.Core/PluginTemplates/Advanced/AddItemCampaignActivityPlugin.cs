namespace Springboard365.Xrm.Plugins.Core
{
    using System;
    using Microsoft.Xrm.Sdk;

    public abstract class AddItemCampaignActivityPlugin : Plugin
    {
        public override void Execute(
            IOrganizationService organizationService,
            IPluginExecutionContext pluginExecutionContext,
            ITracingService tracingService)
        {
            var campaignActivityId = pluginExecutionContext.InputParameters.GetParameter<Guid>(InputParameterType.CampaignActivityId);
            var itemId = pluginExecutionContext.InputParameters.GetParameter<Guid>(InputParameterType.ItemId);
            var entityName = pluginExecutionContext.InputParameters.GetParameter<string>(InputParameterType.EntityName);

            Execute(organizationService, pluginExecutionContext, tracingService, campaignActivityId, itemId, entityName);
        }

        public abstract void Execute(
            IOrganizationService organizationService,
            IPluginExecutionContext pluginExecutionContext,
            ITracingService tracingService,
            Guid campaignActivityId,
            Guid itemId,
            string entityName);
    }
}