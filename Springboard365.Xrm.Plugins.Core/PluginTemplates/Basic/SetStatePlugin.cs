namespace Springboard365.Xrm.Plugins.Core
{
    using Microsoft.Xrm.Sdk;

    public abstract class SetStatePlugin : Plugin
    {
        public override void Execute(
            IOrganizationService organizationService,
            IPluginExecutionContext pluginExecutionContext,
            ITracingService tracingService)
        {
            var entityMoniker = pluginExecutionContext.InputParameters.GetParameter<EntityReference>(InputParameterType.EntityMoniker);
            var state = pluginExecutionContext.InputParameters.GetParameter<OptionSetValue>(InputParameterType.State);
            var status = pluginExecutionContext.InputParameters.GetParameter<OptionSetValue>(InputParameterType.Status);

            Execute(organizationService, pluginExecutionContext, tracingService, entityMoniker, state, status);
        }

        public abstract void Execute(
            IOrganizationService organizationService,
            IPluginExecutionContext pluginExecutionContext,
            ITracingService tracingService,
            EntityReference entityMoniker,
            OptionSetValue state,
            OptionSetValue status);
    }
}