namespace Springboard365.Xrm.Plugins.Core.Test
{
    using Microsoft.Xrm.Sdk;
    using Springboard365.Xrm.Plugins.Core;

    public class DummyEntityPlugin : EntityPlugin
    {
        public IOrganizationService OrganizationService { get; private set; }

        public IPluginExecutionContext PluginExecutionContext { get; private set; }

        public ITracingService TracingService { get; private set; }

        public Entity TargetEntity { get; private set; }

        protected override void Execute(
            IOrganizationService organizationService,
            IPluginExecutionContext pluginExecutionContext,
            ITracingService tracingService,
            Entity targetEntity)
        {
            OrganizationService = organizationService;
            PluginExecutionContext = pluginExecutionContext;
            TracingService = tracingService;
            TargetEntity = targetEntity;
        }
    }
}