namespace Springboard365.Xrm.Plugins.Core
{
    using System;
    using Microsoft.Xrm.Sdk;

    public abstract class CloneContractPlugin : Plugin
    {
        public override void Execute(
            IOrganizationService organizationService,
            IPluginExecutionContext pluginExecutionContext,
            ITracingService tracingService)
        {
            var contractId = pluginExecutionContext.InputParameters.GetParameter<Guid>(InputParameterType.ContractId);
            var includeCanceledLines = pluginExecutionContext.InputParameters.GetParameter<bool>(InputParameterType.IncludeCanceledLines);

            Execute(organizationService, pluginExecutionContext, tracingService, contractId, includeCanceledLines);
        }

        public abstract void Execute(
            IOrganizationService organizationService,
            IPluginExecutionContext pluginExecutionContext,
            ITracingService tracingService,
            Guid contractId,
            bool includeCanceledLines);
    }
}