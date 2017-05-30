namespace Springboard365.Xrm.Plugins.Core
{
    using Microsoft.Xrm.Sdk;

    public abstract class CancelSalesOrderPlugin : Plugin
    {
        public override void Execute(
            IOrganizationService organizationService,
            IPluginExecutionContext pluginExecutionContext,
            ITracingService tracingService)
        {
            var orderClose = pluginExecutionContext.InputParameters.GetParameter<Entity>(InputParameterType.OrderClose);
            var status = pluginExecutionContext.InputParameters.GetParameter<OptionSetValue>(InputParameterType.Status);

            Execute(organizationService, pluginExecutionContext, tracingService, orderClose, status);
        }

        public abstract void Execute(
            IOrganizationService organizationService,
            IPluginExecutionContext pluginExecutionContext,
            ITracingService tracingService,
            Entity orderClose,
            OptionSetValue status);
    }
}