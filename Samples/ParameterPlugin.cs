namespace Springboard365.Xrm.Plugins.Core.Samples
{
    using Microsoft.Xrm.Sdk;
    using Springboard365.Xrm.Plugins.Core.Framework;

    public class ParameterPlugin : Plugin
    {
        protected override void Execute(
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