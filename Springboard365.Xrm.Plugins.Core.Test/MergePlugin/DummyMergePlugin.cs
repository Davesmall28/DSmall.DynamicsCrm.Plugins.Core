namespace Springboard365.Xrm.Plugins.Core.Test
{
    using System;
    using Microsoft.Xrm.Sdk;

    public class DummyMergePlugin : MergePlugin
    {
        public IOrganizationService OrganizationService { get; private set; }

        public IPluginExecutionContext PluginExecutionContext { get; private set; }

        public ITracingService TracingService { get; private set; }

        public EntityReference TargetEntity { get; private set; }

        public Guid SubordinateId { get; private set; }

        public Entity UpdateContent { get; private set; }

        protected override void Execute(
            IOrganizationService organizationService,
            IPluginExecutionContext pluginExecutionContext,
            ITracingService tracingService,
            EntityReference target,
            Guid subordinateId,
            Entity updateContent)
        {
            OrganizationService = organizationService;
            PluginExecutionContext = pluginExecutionContext;
            TracingService = tracingService;
            TargetEntity = target;
            SubordinateId = subordinateId;
            UpdateContent = updateContent;
        }
    }
}