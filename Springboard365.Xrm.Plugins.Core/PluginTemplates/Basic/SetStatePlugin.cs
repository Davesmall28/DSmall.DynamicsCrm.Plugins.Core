namespace Springboard365.Xrm.Plugins.Core
{
    using Microsoft.Xrm.Sdk;
    using Springboard365.Xrm.Plugins.Core.Constants;
    using Springboard365.Xrm.Plugins.Core.Extensions;
    using Springboard365.Xrm.Plugins.Core.Framework;

    public abstract class SetStatePlugin : Plugin
    {
        protected override void Execute(
            IOrganizationService organizationService,
            IPluginExecutionContext pluginExecutionContext,
            ITracingService tracingService)
        {
            var entityMoniker = pluginExecutionContext.InputParameters.GetParameter<EntityReference>(InputParameterType.EntityMoniker);
            var state = pluginExecutionContext.InputParameters.GetParameter<OptionSetValue>(InputParameterType.State);
            var status = pluginExecutionContext.InputParameters.GetParameter<OptionSetValue>(InputParameterType.Status);

            Execute(organizationService, pluginExecutionContext, tracingService, entityMoniker, state, status);
        }

        protected abstract void Execute(
            IOrganizationService organizationService,
            IPluginExecutionContext pluginExecutionContext,
            ITracingService tracingService,
            EntityReference entityMoniker,
            OptionSetValue state,
            OptionSetValue status);
    }
}