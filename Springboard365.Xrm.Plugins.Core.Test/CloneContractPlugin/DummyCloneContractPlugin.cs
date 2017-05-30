namespace Springboard365.Xrm.Plugins.Core.Test
{
    using System;
    using Microsoft.Xrm.Sdk;

    public class DummyCloneContractPlugin : CloneContractPlugin
    {
        public IOrganizationService OrganizationService { get; private set; }

        public IPluginExecutionContext PluginExecutionContext { get; private set; }

        public ITracingService TracingService { get; private set; }

        public Guid ContractId { get; private set; }

        public bool IncludeCanceledLines { get; private set; }

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