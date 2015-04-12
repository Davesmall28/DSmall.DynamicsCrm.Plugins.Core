namespace DSmall.DynamicsCrm.Plugins.Core
{
    using Microsoft.Xrm.Sdk;

    /// <summary>The set state plugin.</summary>
    public abstract class SetStatePlugin : Plugin
    {
        /// <summary>The execute.</summary>
        /// <param name="organizationService">The organization service.</param>
        /// <param name="pluginExecutionContext">The plugin execution context.</param>
        /// <param name="tracingService">The tracing service.</param>
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

        /// <summary>The execute.</summary>
        /// <param name="organizationService">The organization service.</param>
        /// <param name="pluginExecutionContext">The plugin execution context.</param>
        /// <param name="tracingService">The tracing service.</param>
        /// <param name="entityMoniker">The entity moniker.</param>
        /// <param name="state">The state.</param>
        /// <param name="status">The status.</param>
        public abstract void Execute(
            IOrganizationService organizationService,
            IPluginExecutionContext pluginExecutionContext,
            ITracingService tracingService,
            EntityReference entityMoniker,
            OptionSetValue state,
            OptionSetValue status);
    }
}
