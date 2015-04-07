namespace DSmall.DynamicsCrm.Plugins.Core
{
    using System;
    using Microsoft.Xrm.Sdk;

    /// <summary>The unlock sales order pricing plugin.</summary>
    public abstract class UnlockSalesOrderPricingPlugin : Plugin
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
            var salesOrderId = pluginExecutionContext.InputParameters.GetParameter<Guid>(InputParameterType.SalesOrderId);

            Execute(organizationService, pluginExecutionContext, tracingService, salesOrderId);
        }

        /// <summary>The execute.</summary>
        /// <param name="organizationService">The organization service.</param>
        /// <param name="pluginExecutionContext">The plugin execution context.</param>
        /// <param name="tracingService">The tracing service.</param>
        /// <param name="salesOrderId">The sales order id.</param>
        public abstract void Execute(
            IOrganizationService organizationService,
            IPluginExecutionContext pluginExecutionContext,
            ITracingService tracingService,
            Guid salesOrderId);
    }
}
