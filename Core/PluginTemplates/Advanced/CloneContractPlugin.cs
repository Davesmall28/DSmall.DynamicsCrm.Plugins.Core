namespace Springboard365.Xrm.Plugins.Core
{
    using System;
    using Microsoft.Xrm.Sdk;
    using Springboard365.Xrm.Plugins.Core.Constants;
    using Springboard365.Xrm.Plugins.Core.Extensions;
    using Springboard365.Xrm.Plugins.Core.Framework;

    public abstract class CloneContractPlugin : Plugin
    {
        protected override void Execute(
            IOrganizationService organizationService,
            IPluginExecutionContext pluginExecutionContext,
            ITracingService tracingService)
        {
            var contractId = pluginExecutionContext.InputParameters.GetParameter<Guid>(InputParameterType.ContractId);
            var includeCanceledLines = pluginExecutionContext.InputParameters.GetParameter<bool>(InputParameterType.IncludeCanceledLines);

            Execute(organizationService, pluginExecutionContext, tracingService, contractId, includeCanceledLines);
        }

        protected abstract void Execute(
            IOrganizationService organizationService,
            IPluginExecutionContext pluginExecutionContext,
            ITracingService tracingService,
            Guid contractId,
            bool includeCanceledLines);
    }
}