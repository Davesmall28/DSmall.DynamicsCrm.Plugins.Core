namespace Springboard365.Xrm.Plugins.Core.Samples
{
    using Microsoft.Xrm.Sdk;
    using Springboard365.Xrm.Plugins.Core;

    public class ParameterPlugin : Plugin
    {
        public override void Execute(
            IOrganizationService organizationService,
            IPluginExecutionContext pluginExecutionContext,
            ITracingService tracingService)
        {
            var entityWriter = new EntityWriter(organizationService, pluginExecutionContext, tracingService);

            var pluginParameters = entityWriter.PopulatePluginParameters();

            var xmlBlob = entityWriter.GetObjectAsXml(pluginParameters);

            entityWriter.WriteToEntity(xmlBlob);
        }
    }
}