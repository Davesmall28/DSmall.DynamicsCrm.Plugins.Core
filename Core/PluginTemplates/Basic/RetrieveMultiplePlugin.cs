namespace Springboard365.Xrm.Plugins.Core
{
    using System;
    using Microsoft.Xrm.Sdk;
    using Microsoft.Xrm.Sdk.Query;
    using Springboard365.Xrm.Plugins.Core.Constants;
    using Springboard365.Xrm.Plugins.Core.Extensions;
    using Springboard365.Xrm.Plugins.Core.Framework;

    public abstract class RetrieveMultiplePlugin : Plugin
    {
        protected override void Execute(IOrganizationService organizationService, IPluginExecutionContext pluginExecutionContext, ITracingService tracingService)
        {
            var queryBase = pluginExecutionContext.InputParameters.GetParameter<QueryBase>(InputParameterType.Query);
            var appModuleId = pluginExecutionContext.InputParameters.GetParameter<Guid>(InputParameterType.AppModuleId);
            var isAppModuleContext = pluginExecutionContext.InputParameters.GetParameter<bool>(InputParameterType.IsAppModuleContext);

            Execute(organizationService, pluginExecutionContext, tracingService, queryBase, appModuleId, isAppModuleContext);
        }

        protected abstract void Execute(
            IOrganizationService organizationService,
            IPluginExecutionContext pluginExecutionContext,
            ITracingService tracingService,
            QueryBase queryBase,
            Guid appModuleId,
            bool isAppModuleContext);
    }
}