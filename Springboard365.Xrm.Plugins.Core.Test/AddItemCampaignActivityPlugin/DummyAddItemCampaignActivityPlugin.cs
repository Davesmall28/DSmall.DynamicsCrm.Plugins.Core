namespace Springboard365.Xrm.Plugins.Core.Test
{
    using System;
    using Microsoft.Xrm.Sdk;

    public class DummyAddItemCampaignActivityPlugin : AddItemCampaignActivityPlugin
    {
        public IOrganizationService OrganizationService { get; private set; }

        public IPluginExecutionContext PluginExecutionContext { get; private set; }

        public ITracingService TracingService { get; private set; }

        public Guid CampaignActivityId { get; private set; }

        public Guid ItemId { get; private set; }

        public string EntityName { get; private set; }
        
        protected override void Execute(
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