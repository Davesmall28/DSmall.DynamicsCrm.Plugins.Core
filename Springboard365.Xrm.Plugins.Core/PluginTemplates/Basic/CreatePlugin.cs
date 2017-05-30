namespace Springboard365.Xrm.Plugins.Core
{
    using Microsoft.Xrm.Sdk;
    using Springboard365.Xrm.Core;

    public abstract class CreatePlugin : Plugin
    {
        public override void Execute(IOrganizationService organizationService, IPluginExecutionContext pluginExecutionContext, ITracingService tracingService)
        {
            var target = EntityValidator.GetValidCrmTargetEntity<Entity>(pluginExecutionContext, EntityImageType.Target);

            Execute(organizationService, pluginExecutionContext, tracingService, target);
        }

        public abstract void Execute(
            IOrganizationService organizationService, 
            IPluginExecutionContext pluginExecutionContext, 
            ITracingService tracingService,
            Entity targetEntity);
    }
}