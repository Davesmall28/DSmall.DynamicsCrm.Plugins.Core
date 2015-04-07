namespace DSmall.DynamicsCrm.Plugins.Core
{
    using System;
    using Microsoft.Xrm.Sdk;

    /// <summary>The cancel contract plugin.</summary>
    public abstract class CancelContractPlugin : Plugin
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
            var contractId = pluginExecutionContext.InputParameters.GetParameter<Guid>(InputParameterType.ContractId);
            var cancelDate = pluginExecutionContext.InputParameters.GetParameter<DateTime>(InputParameterType.CancelDate);
            var status = pluginExecutionContext.InputParameters.GetParameter<OptionSetValue>(InputParameterType.Status);

            Execute(organizationService, pluginExecutionContext, tracingService, contractId, cancelDate, status);
        }

        /// <summary>The execute.</summary>
        /// <param name="organizationService">The organization service.</param>
        /// <param name="pluginExecutionContext">The plugin execution context.</param>
        /// <param name="tracingService">The tracing service.</param>
        /// <param name="contractId">The contract id.</param>
        /// <param name="cancelDate">The cancel date.</param>
        /// <param name="status">The status.</param>
        public abstract void Execute(
            IOrganizationService organizationService,
            IPluginExecutionContext pluginExecutionContext,
            ITracingService tracingService,
            Guid contractId,
            DateTime cancelDate,
            OptionSetValue status);
    }
}