namespace Springboard365.Xrm.Plugins.Core
{
    using System;
    using Microsoft.Xrm.Sdk;
    using Springboard365.Xrm.Plugins.Core.Constants;
    using Springboard365.Xrm.Plugins.Core.Extensions;
    using Springboard365.Xrm.Plugins.Core.Framework;

    public abstract class UnlockSalesOrderPricingPlugin : Plugin
    {
        protected override void Execute(
            IOrganizationService organizationService,
            IPluginExecutionContext pluginExecutionContext,
            ITracingService tracingService)
        {
            var salesOrderId = pluginExecutionContext.InputParameters.GetParameter<Guid>(InputParameterType.SalesOrderId);

            Execute(organizationService, pluginExecutionContext, tracingService, salesOrderId);
        }

        protected abstract void Execute(
            IOrganizationService organizationService,
            IPluginExecutionContext pluginExecutionContext,
            ITracingService tracingService,
            Guid salesOrderId);
    }
}