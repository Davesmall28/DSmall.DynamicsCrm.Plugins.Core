namespace DSmall.DynamicsCrm.Plugins.Core
{
    using System;
    using Microsoft.Xrm.Sdk;

    /// <summary>The add item campaign plugin.</summary>
    public abstract class AddItemCampaignPlugin : Plugin
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
            var campaignId = pluginExecutionContext.InputParameters.GetParameter<Guid>(InputParameterType.CampaignId);
            var entityId = pluginExecutionContext.InputParameters.GetParameter<Guid>(InputParameterType.EntityId);
            var entityName = pluginExecutionContext.InputParameters.GetParameter<string>(InputParameterType.EntityName);

            Execute(organizationService, pluginExecutionContext, tracingService, campaignId, entityId, entityName);
        }

        /// <summary>The execute.</summary>
        /// <param name="organizationService">The organization service.</param>
        /// <param name="pluginExecutionContext">The plugin execution context.</param>
        /// <param name="tracingService">The tracing service.</param>
        /// <param name="campaignId">The campaign id.</param>
        /// <param name="entityId">The entity id.</param>
        /// <param name="entityName">The entity name.</param>
        public abstract void Execute(
            IOrganizationService organizationService,
            IPluginExecutionContext pluginExecutionContext,
            ITracingService tracingService,
            Guid campaignId,
            Guid entityId,
            string entityName);
    }
}
