namespace Springboard365.Xrm.Plugins.Core.Test
{
    using System;
    using Microsoft.Xrm.Sdk;

    public class DummyAddItemCampaignPlugin : AddItemCampaignPlugin
    {
        public IOrganizationService OrganizationService { get; private set; }

        public IPluginExecutionContext PluginExecutionContext { get; private set; }

        public ITracingService TracingService { get; private set; }

        public Guid CampaignId { get; private set; }

        public Guid EntityId { get; private set; }

        public string EntityName { get; private set; }

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