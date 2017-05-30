namespace Springboard365.Xrm.Plugins.Core
{
    using System;
    using Microsoft.Xrm.Sdk;

    public abstract class LockInvoicePricingPlugin : Plugin
    {
        public override void Execute(
            IOrganizationService organizationService,
            IPluginExecutionContext pluginExecutionContext,
            ITracingService tracingService)
        {
            var invoiceId = pluginExecutionContext.InputParameters.GetParameter<Guid>(InputParameterType.InvoiceId);

            Execute(organizationService, pluginExecutionContext, tracingService, invoiceId);
        }

        public abstract void Execute(
            IOrganizationService organizationService,
            IPluginExecutionContext pluginExecutionContext,
            ITracingService tracingService,
            Guid invoiceId);
    }
}