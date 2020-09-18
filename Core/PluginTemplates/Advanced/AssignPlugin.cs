namespace Springboard365.Xrm.Plugins.Core
{
    using Microsoft.Xrm.Sdk;
    using Springboard365.Xrm.Plugins.Core.Constants;
    using Springboard365.Xrm.Plugins.Core.Extensions;
    using Springboard365.Xrm.Plugins.Core.Framework;

    public abstract class AssignPlugin : Plugin
    {
        protected override void Execute(
            IOrganizationService organizationService,
            IPluginExecutionContext pluginExecutionContext,
            ITracingService tracingService)
        {
            var target = pluginExecutionContext.InputParameters.GetParameter<EntityReference>(InputParameterType.Target);
            var assignee = pluginExecutionContext.InputParameters.GetParameter<EntityReference>(InputParameterType.Assignee);

            Execute(organizationService, pluginExecutionContext, tracingService, target, assignee);
        }

        protected abstract void Execute(
            IOrganizationService organizationService,
            IPluginExecutionContext pluginExecutionContext,
            ITracingService tracingService,
            EntityReference target,
            EntityReference assignee);
    }
}