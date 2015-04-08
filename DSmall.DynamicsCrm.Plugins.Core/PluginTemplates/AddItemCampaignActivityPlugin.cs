namespace DSmall.DynamicsCrm.Plugins.Core
{
    using System;
    using Microsoft.Xrm.Sdk;

    /// <summary>The add item campaign activity plugin.</summary>
    public abstract class AddItemCampaignActivityPlugin : Plugin
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
            var campaignActivityId = pluginExecutionContext.InputParameters.GetParameter<Guid>(InputParameterType.CampaignActivityId);
            var itemId = pluginExecutionContext.InputParameters.GetParameter<Guid>(InputParameterType.ItemId);
            var entityName = pluginExecutionContext.InputParameters.GetParameter<string>(InputParameterType.EntityName);

            Execute(organizationService, pluginExecutionContext, tracingService, campaignActivityId, itemId, entityName);
        }

        /// <summary>The execute.</summary>
        /// <param name="organizationService">The organization service.</param>
        /// <param name="pluginExecutionContext">The plugin execution context.</param>
        /// <param name="tracingService">The tracing service.</param>
        /// <param name="campaignActivityId">The campaign activity id.</param>
        /// <param name="itemId">The item id.</param>
        /// <param name="entityName">The entity name.</param>
        public abstract void Execute(
            IOrganizationService organizationService,
            IPluginExecutionContext pluginExecutionContext,
            ITracingService tracingService,
            Guid campaignActivityId,
            Guid itemId,
            string entityName);
    }
}
