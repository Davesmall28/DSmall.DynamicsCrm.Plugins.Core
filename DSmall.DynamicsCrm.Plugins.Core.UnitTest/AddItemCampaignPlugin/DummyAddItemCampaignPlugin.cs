namespace DSmall.DynamicsCrm.Plugins.Core.UnitTest
{
    using System;
    using Microsoft.Xrm.Sdk;

    /// <summary>The dummy add item campaign plugin.</summary>
    public class DummyAddItemCampaignPlugin : AddItemCampaignPlugin
    {
        /// <summary>Gets or sets the organization service.</summary>
        public IOrganizationService OrganizationService { get; set; }

        /// <summary>Gets or sets the plugin execution context.</summary>
        public IPluginExecutionContext PluginExecutionContext { get; set; }

        /// <summary>Gets or sets the tracing service.</summary>
        public ITracingService TracingService { get; set; }

        /// <summary>Gets or sets the campaign id.</summary>
        public Guid CampaignId { get; set; }

        /// <summary>Gets or sets the entity id.</summary>
        public Guid EntityId { get; set; }

        /// <summary>Gets or sets the entity name.</summary>
        public string EntityName { get; set; }

        /// <summary>The execute.</summary>
        /// <param name="organizationService">The organization service.</param>
        /// <param name="pluginExecutionContext">The plugin execution context.</param>
        /// <param name="tracingService">The tracing service.</param>
        /// <param name="campaignId">The campaign id.</param>
        /// <param name="entityId">The entity id.</param>
        /// <param name="entityName">The entity name.</param>
        public override void Execute(
            IOrganizationService organizationService,
            IPluginExecutionContext pluginExecutionContext,
            ITracingService tracingService,
            Guid campaignId,
            Guid entityId,
            string entityName)
        {
            OrganizationService = organizationService;
            PluginExecutionContext = pluginExecutionContext;
            TracingService = tracingService;
            CampaignId = campaignId;
            EntityId = entityId;
            EntityName = entityName;
        }
    }
}