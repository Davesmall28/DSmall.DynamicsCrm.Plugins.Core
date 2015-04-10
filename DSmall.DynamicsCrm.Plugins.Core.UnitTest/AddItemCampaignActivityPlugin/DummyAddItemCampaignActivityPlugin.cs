﻿namespace DSmall.DynamicsCrm.Plugins.Core.UnitTest
{
    using System;
    using Microsoft.Xrm.Sdk;

    /// <summary>The dummy add item campaign activity plugin.</summary>
    public class DummyAddItemCampaignActivityPlugin : AddItemCampaignActivityPlugin
    {
        /// <summary>Gets or sets the organization service.</summary>
        public IOrganizationService OrganizationService { get; set; }

        /// <summary>Gets or sets the plugin execution context.</summary>
        public IPluginExecutionContext PluginExecutionContext { get; set; }

        /// <summary>Gets or sets the tracing service.</summary>
        public ITracingService TracingService { get; set; }

        /// <summary>Gets or sets the campaign activity id.</summary>
        public Guid CampaignActivityId { get; set; }

        /// <summary>Gets or sets the item id.</summary>
        public Guid ItemId { get; set; }

        /// <summary>Gets or sets the entity name.</summary>
        public string EntityName { get; set; }
        
        /// <summary>The execute.</summary>
        /// <param name="organizationService">The organization service.</param>
        /// <param name="pluginExecutionContext">The plugin execution context.</param>
        /// <param name="tracingService">The tracing service.</param>
        /// <param name="campaignActivityId">The campaign activity id.</param>
        /// <param name="itemId">The item id.</param>
        /// <param name="entityName">The entity name.</param>
        public override void Execute(
            IOrganizationService organizationService,
            IPluginExecutionContext pluginExecutionContext,
            ITracingService tracingService,
            Guid campaignActivityId,
            Guid itemId,
            string entityName)
        {
            OrganizationService = organizationService;
            PluginExecutionContext = pluginExecutionContext;
            TracingService = tracingService;
            CampaignActivityId = campaignActivityId;
            ItemId = itemId;
            EntityName = entityName;
        }
    }
}