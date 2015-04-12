namespace DSmall.DynamicsCrm.Plugins.Core.UnitTest
{
    using System;
    using Microsoft.Xrm.Sdk;

    /// <summary>The dummy lock sales order pricing plugin.</summary>
    public class DummyLockSalesOrderPricingPlugin : LockSalesOrderPricingPlugin
    {
        /// <summary>Gets the organization service.</summary>
        public IOrganizationService OrganizationService { get; private set; }

        /// <summary>Gets the plugin execution context.</summary>
        public IPluginExecutionContext PluginExecutionContext { get; private set; }

        /// <summary>Gets the tracing service.</summary>
        public ITracingService TracingService { get; private set; }

        /// <summary>Gets the sales order id.</summary>
        public Guid SalesOrderId { get; private set; }

        /// <summary>The execute.</summary>
        /// <param name="organizationService">The organization service.</param>
        /// <param name="pluginExecutionContext">The plugin execution context.</param>
        /// <param name="tracingService">The tracing service.</param>
        /// <param name="salesOrderId">The sales order id.</param>
        public override void Execute(
            IOrganizationService organizationService,
            IPluginExecutionContext pluginExecutionContext,
            ITracingService tracingService,
            Guid salesOrderId)
        {
            OrganizationService = organizationService;
            PluginExecutionContext = pluginExecutionContext;
            TracingService = tracingService;
            SalesOrderId = salesOrderId;
        }
    }
}