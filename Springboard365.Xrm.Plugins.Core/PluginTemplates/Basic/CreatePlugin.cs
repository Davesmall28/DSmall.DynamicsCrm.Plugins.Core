namespace Springboard365.Xrm.Plugins.Core
{
    using Microsoft.Xrm.Sdk;
    using Springboard365.Xrm.Core;
    using Springboard365.Xrm.Plugins.Core.Framework;

    public abstract class CreatePlugin : Plugin
    {
        protected override void Execute(IOrganizationService organizationService, IPluginExecutionContext pluginExecutionContext, ITracingService tracingService)
        {
            var target = EntityValidator.GetValidCrmTargetEntity<Entity>(pluginExecutionContext, EntityImageType.Target);

            Execute(organizationService, pluginExecutionContext, tracingService, target);
        }

        protected abstract void Execute(
            IOrganizationService organizationService, 
            IPluginExecutionContext pluginExecutionContext, 
            ITracingService tracingService,
            Entity targetEntity);
    }
}