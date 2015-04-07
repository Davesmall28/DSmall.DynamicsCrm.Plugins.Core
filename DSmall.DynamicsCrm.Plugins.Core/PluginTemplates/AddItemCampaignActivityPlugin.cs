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
            var entityName = pluginExecutionContext.InputParameters.GetParameter<string>(InputParameterType.EntityName);
            var itemId = pluginExecutionContext.InputParameters.GetParameter<Guid>(InputParameterType.ItemId);

            Execute(organizationService, pluginExecutionContext, tracingService, campaignActivityId, entityName, itemId);
        }

        /// <summary>The execute.</summary>
        /// <param name="organizationService">The organization service.</param>
        /// <param name="pluginExecutionContext">The plugin execution context.</param>
        /// <param name="tracingService">The tracing service.</param>
        /// <param name="campaignActivityId">The campaign activity id.</param>
        /// <param name="entityName">The entity name.</param>
        /// <param name="itemId">The item id.</param>
        public abstract void Execute(
            IOrganizationService organizationService,
            IPluginExecutionContext pluginExecutionContext,
            ITracingService tracingService,
            Guid campaignActivityId,
            string entityName,
            Guid itemId);
    }
}
