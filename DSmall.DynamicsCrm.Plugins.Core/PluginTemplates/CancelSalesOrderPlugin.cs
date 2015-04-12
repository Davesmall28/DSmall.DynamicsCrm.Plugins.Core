namespace DSmall.DynamicsCrm.Plugins.Core
{
    using Microsoft.Xrm.Sdk;

    /// <summary>The cancel sales order plugin.</summary>
    public abstract class CancelSalesOrderPlugin : Plugin
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
            var orderClose = pluginExecutionContext.InputParameters.GetParameter<Entity>(InputParameterType.OrderClose);
            var status = pluginExecutionContext.InputParameters.GetParameter<OptionSetValue>(InputParameterType.Status);

            Execute(organizationService, pluginExecutionContext, tracingService, orderClose, status);
        }

        /// <summary>The execute.</summary>
        /// <param name="organizationService">The organization service.</param>
        /// <param name="pluginExecutionContext">The plugin execution context.</param>
        /// <param name="tracingService">The tracing service.</param>
        /// <param name="orderClose">The order close entity.</param>
        /// <param name="status">The status.</param>
        public abstract void Execute(
            IOrganizationService organizationService,
            IPluginExecutionContext pluginExecutionContext,
            ITracingService tracingService,
            Entity orderClose,
            OptionSetValue status);
    }
}