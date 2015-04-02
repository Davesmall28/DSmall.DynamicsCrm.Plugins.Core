namespace DSmall.DynamicsCrm.Plugins.Core.Samples
{
    using System;
    using Microsoft.Xrm.Sdk;

    /// <summary>The parameter plugin.</summary>
    public class ParameterPlugin : Plugin
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
            var entityWriter = new EntityWriter(organizationService, pluginExecutionContext, tracingService);

            var pluginParameters = entityWriter.PopulatePluginParameters();

            var xmlBlob = entityWriter.GetObjectAsXml(pluginParameters);

            entityWriter.WriteToEntity(xmlBlob);

            throw new Exception("Succeeded");
        }
    }
}