namespace Springboard365.Xrm.Plugins.Core.Framework
{
    using Microsoft.Xrm.Sdk;
    using Springboard365.Xrm.Core;

    public abstract class EntityPlugin : Plugin
    {
        protected override void Execute(IOrganizationService organizationService, IPluginExecutionContext pluginExecutionContext, ITracingService tracingService)
        {
            var targetEntity = EntityValidator.GetValidCrmTargetEntity<Entity>(pluginExecutionContext, EntityImageType.Target);

            Execute(organizationService, pluginExecutionContext, tracingService, targetEntity);
        }

        protected abstract void Execute(
            IOrganizationService organizationService,
            IPluginExecutionContext pluginExecutionContext,
            ITracingService tracingService,
            Entity targetEntity);
    }
}