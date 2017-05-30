namespace Springboard365.Xrm.Plugins.Core
{
    using System;
    using Microsoft.Xrm.Sdk;

    public abstract class UnlockSalesOrderPricingPlugin : Plugin
    {
        public override void Execute(
            IOrganizationService organizationService,
            IPluginExecutionContext pluginExecutionContext,
            ITracingService tracingService)
        {
            var salesOrderId = pluginExecutionContext.InputParameters.GetParameter<Guid>(InputParameterType.SalesOrderId);

            Execute(organizationService, pluginExecutionContext, tracingService, salesOrderId);
        }

        public abstract void Execute(
            IOrganizationService organizationService,
            IPluginExecutionContext pluginExecutionContext,
            ITracingService tracingService,
            Guid salesOrderId);
    }
}