namespace Springboard365.Xrm.Plugins.Core
{
    using System;
    using Microsoft.Xrm.Sdk;
    using Springboard365.Xrm.Plugins.Core.Constants;
    using Springboard365.Xrm.Plugins.Core.Extensions;
    using Springboard365.Xrm.Plugins.Core.Framework;

    public abstract class AddItemCampaignPlugin : Plugin
    {
        protected override void Execute(
            IOrganizationService organizationService,
            IPluginExecutionContext pluginExecutionContext,
            ITracingService tracingService)
        {
            var campaignId = pluginExecutionContext.InputParameters.GetParameter<Guid>(InputParameterType.CampaignId);
            var entityId = pluginExecutionContext.InputParameters.GetParameter<Guid>(InputParameterType.EntityId);
            var entityName = pluginExecutionContext.InputParameters.GetParameter<string>(InputParameterType.EntityName);

            Execute(organizationService, pluginExecutionContext, tracingService, campaignId, entityId, entityName);
        }

        protected abstract void Execute(
            IOrganizationService organizationService,
            IPluginExecutionContext pluginExecutionContext,
            ITracingService tracingService,
            Guid campaignId,
            Guid entityId,
            string entityName);
    }
}