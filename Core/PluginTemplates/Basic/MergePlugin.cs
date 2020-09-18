namespace Springboard365.Xrm.Plugins.Core
{
    using System;
    using Microsoft.Xrm.Sdk;
    using Springboard365.Xrm.Plugins.Core.Constants;
    using Springboard365.Xrm.Plugins.Core.Extensions;
    using Springboard365.Xrm.Plugins.Core.Framework;

    public abstract class MergePlugin : Plugin
    {
        protected override void Execute(IOrganizationService organizationService, IPluginExecutionContext pluginExecutionContext, ITracingService tracingService)
        {
            var target = pluginExecutionContext.InputParameters.GetParameter<EntityReference>(InputParameterType.Target);
            var subordinateId = pluginExecutionContext.InputParameters.GetParameter<Guid>(InputParameterType.SubordinateId);
            var updateContent = pluginExecutionContext.InputParameters.GetParameter<Entity>(InputParameterType.UpdateContent);
            
            Execute(organizationService, pluginExecutionContext, tracingService, target, subordinateId, updateContent);
        }

        protected abstract void Execute(
            IOrganizationService organizationService,
            IPluginExecutionContext pluginExecutionContext,
            ITracingService tracingService,
            EntityReference target, 
            Guid subordinateId, 
            Entity updateContent);
    }
}