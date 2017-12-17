namespace Springboard365.Xrm.Plugins.Core.Test
{
    using System;
    using Microsoft.Xrm.Sdk;

    public class DummyAddToQueuePlugin : AddToQueuePlugin
    {
        public IOrganizationService OrganizationService { get; private set; }

        public IPluginExecutionContext PluginExecutionContext { get; private set; }

        public ITracingService TracingService { get; private set; }

        public EntityReference Target { get; private set; }

        public Guid DestinationQueueId { get; private set; }

        public Guid SourceQueueId { get; private set; }

        protected override void Execute(
            IOrganizationService organizationService,
            IPluginExecutionContext pluginExecutionContext,
            ITracingService tracingService,
            EntityReference target,
            Guid destinationQueueId,
            Guid sourceQueueId)
        {
            OrganizationService = organizationService;
            PluginExecutionContext = pluginExecutionContext;
            TracingService = tracingService;
            Target = target;
            DestinationQueueId = destinationQueueId;
            SourceQueueId = sourceQueueId;
        }
    }
}