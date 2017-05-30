namespace Springboard365.Xrm.Plugins.Core
{
    using System;
    using Microsoft.Xrm.Sdk;

    public abstract class CancelContractPlugin : Plugin
    {
        public override void Execute(
            IOrganizationService organizationService,
            IPluginExecutionContext pluginExecutionContext,
            ITracingService tracingService)
        {
            var contractId = pluginExecutionContext.InputParameters.GetParameter<Guid>(InputParameterType.ContractId);
            var cancelDate = pluginExecutionContext.InputParameters.GetParameter<DateTime>(InputParameterType.CancelDate);
            var status = pluginExecutionContext.InputParameters.GetParameter<OptionSetValue>(InputParameterType.Status);

            Execute(organizationService, pluginExecutionContext, tracingService, contractId, cancelDate, status);
        }

        public abstract void Execute(
            IOrganizationService organizationService,
            IPluginExecutionContext pluginExecutionContext,
            ITracingService tracingService,
            Guid contractId,
            DateTime cancelDate,
            OptionSetValue status);
    }
}