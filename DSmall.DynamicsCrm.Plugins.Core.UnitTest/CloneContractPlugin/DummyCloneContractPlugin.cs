namespace DSmall.DynamicsCrm.Plugins.Core.UnitTest
{
    using System;
    using Microsoft.Xrm.Sdk;

    /// <summary>The dummy clone contract plugin.</summary>
    public class DummyCloneContractPlugin : CloneContractPlugin
    {
        /// <summary>Gets the organization service.</summary>
        public IOrganizationService OrganizationService { get; private set; }

        /// <summary>Gets the plugin execution context.</summary>
        public IPluginExecutionContext PluginExecutionContext { get; private set; }

        /// <summary>Gets the tracing service.</summary>
        public ITracingService TracingService { get; private set; }

        /// <summary>Gets the contract id.</summary>
        public Guid ContractId { get; private set; }

        /// <summary>Gets a value indicating whether include canceled lines.</summary>
        public bool IncludeCanceledLines { get; private set; }

        /// <summary>The execute.</summary>
        /// <param name="organizationService">The organization service.</param>
        /// <param name="pluginExecutionContext">The plugin execution context.</param>
        /// <param name="tracingService">The tracing service.</param>
        /// <param name="contractId">The contract id.</param>
        /// <param name="includeCanceledLines">The includeCanceledLines.</param>
        public override void Execute(
            IOrganizationService organizationService,
            IPluginExecutionContext pluginExecutionContext,
            ITracingService tracingService,
            Guid contractId,
            bool includeCanceledLines)
        {
            OrganizationService = organizationService;
            PluginExecutionContext = pluginExecutionContext;
            TracingService = tracingService;
            ContractId = contractId;
            IncludeCanceledLines = includeCanceledLines;
        }
    }
}