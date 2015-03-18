namespace DSmall.DynamicsCrm.Plugins.Core.Samples
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Xml.Serialization;
    using DSmall.DynamicsCrm.Plugins.Core.Samples.Model;
    using Microsoft.Xrm.Sdk;

    /// <summary>The parameter plugin.</summary>
    public class ParameterPlugin : Plugin
    {
        private IOrganizationService organizationService;
        private IPluginExecutionContext pluginExecutionContext;
        private ITracingService tracingService;

        /// <summary>The execute.</summary>
        /// <param name="orgService">The organization service.</param>
        /// <param name="pluginContext">The plugin execution context.</param>
        /// <param name="traceService">The tracing service.</param>
        public override void Execute(
            IOrganizationService orgService,
            IPluginExecutionContext pluginContext,
            ITracingService traceService)
        {
            organizationService = orgService;
            pluginExecutionContext = pluginContext;
            tracingService = traceService;

            var parameters = PopulatePluginParameters();

            var xmlBlob = GetObjectAsXml(parameters);
            tracingService.Trace(xmlBlob);

            WriteToEntity(xmlBlob);

            throw new Exception("Succeeded");
        }

        private PluginParameters PopulatePluginParameters()
        {
            tracingService.Trace("Input Parameters");
            var inputParameters = GetParameters(pluginExecutionContext.InputParameters);

            tracingService.Trace("Output Parameters");
            var outputParameters = GetParameters(pluginExecutionContext.OutputParameters);

            tracingService.Trace("Pre Entity Images");
            var preEntityImages = GetParameters(pluginExecutionContext.PreEntityImages);

            tracingService.Trace("Post Entity Images");
            var postEntityImages = GetParameters(pluginExecutionContext.PostEntityImages);

            return new PluginParameters
            {
                InputParameters = inputParameters,
                OutputParameters = outputParameters,
                PreEntityImages = preEntityImages,
                PostEntityImages = postEntityImages,
            };
        }

        private string GetObjectAsXml(PluginParameters parameters)
        {
            var stringWriter = new StringWriter();
            var serializer = new XmlSerializer(typeof(PluginParameters));
            serializer.Serialize(stringWriter, parameters);

            return stringWriter.ToString();
        }

        private List<ParameterDetail> GetParameters(
            IEnumerable<KeyValuePair<string, object>> parameterCollection)
        {
            var parameters = new List<ParameterDetail>();
            
            foreach (var parameter in parameterCollection)
            {
                var parameterValueType = parameter.Value != null ? parameter.Value.GetType().ToString() : string.Empty;
                tracingService.Trace("Key: {0}, Value Type: {1}", parameter.Key, parameterValueType);

                parameters.Add(
                    new ParameterDetail
                        {
                            Name = parameter.Key,
                            Type = parameterValueType
                        });
            }

            return parameters;
        }

        private List<ParameterDetail> GetParameters(
            IEnumerable<KeyValuePair<string, Entity>> parameterCollection)
        {
            var parameters = new List<ParameterDetail>();

            foreach (var parameter in parameterCollection)
            {
                var parameterValueType = parameter.Value != null ? parameter.Value.GetType().ToString() : string.Empty;
                tracingService.Trace("Key: {0}, Value Type: {1}", parameter.Key, parameterValueType);
                parameters.Add(new ParameterDetail { Name = parameter.Key, Type = parameterValueType });
            }

            return parameters;
        }

        private void WriteToEntity(string xmlBlob)
        {
            var name = string.Format("On the {0} of {1}", pluginExecutionContext.MessageName, pluginExecutionContext.PrimaryEntityName);
            tracingService.Trace("Name: {0}", name);

            var toCreate = new Entity("ds_pluginparameter");
            toCreate["ds_name"] = name;
            toCreate["ds_messagename"] = pluginExecutionContext.MessageName;
            toCreate["ds_primaryentityname"] = pluginExecutionContext.PrimaryEntityName;
            toCreate["ds_pluginparameters"] = xmlBlob;

            organizationService.Create(toCreate);
        }
    }
}