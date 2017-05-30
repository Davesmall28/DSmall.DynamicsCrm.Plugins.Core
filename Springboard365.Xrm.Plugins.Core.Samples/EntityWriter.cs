namespace Springboard365.Xrm.Plugins.Core.Samples
{
    using System.Collections.Generic;
    using System.IO;
    using System.Xml.Serialization;
    using Microsoft.Xrm.Sdk;
    using Springboard365.Xrm.Plugins.Core.Model;

    public class EntityWriter
    {
        private readonly IOrganizationService organizationService;
        private readonly IPluginExecutionContext pluginExecutionContext;
        private readonly ITracingService tracingService;

        public EntityWriter(IOrganizationService organizationService, IPluginExecutionContext pluginExecutionContext, ITracingService tracingService)
        {
            this.organizationService = organizationService;
            this.pluginExecutionContext = pluginExecutionContext;
            this.tracingService = tracingService;
        }

        public PluginParameters PopulatePluginParameters()
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

        public string GetObjectAsXml(PluginParameters parameters)
        {
            var stringWriter = new StringWriter();
            var serializer = new XmlSerializer(typeof(PluginParameters));
            serializer.Serialize(stringWriter, parameters);

            return stringWriter.ToString();
        }

        public void WriteToEntity(string xmlBlob)
        {
            tracingService.Trace("XmlBlob");
            tracingService.Trace(xmlBlob);

            var name = string.Format("On the {0} of {1}", pluginExecutionContext.MessageName, pluginExecutionContext.PrimaryEntityName);
            tracingService.Trace("Name: {0}", name);
            tracingService.Trace("RequestId: {0}", pluginExecutionContext.RequestId);

            var toCreate = new Entity("sb365_pluginparameter");
            toCreate["sb365_pluginexecutionrequestid"] = pluginExecutionContext.RequestId.ToString();
            toCreate["sb365_name"] = name;
            toCreate["sb365_messagename"] = pluginExecutionContext.MessageName;
            toCreate["sb365_primaryentityname"] = pluginExecutionContext.PrimaryEntityName;
            toCreate["sb365_pluginparameters"] = xmlBlob;

            organizationService.Create(toCreate);
        }

        private List<ParameterDetail> GetParameters(IEnumerable<KeyValuePair<string, object>> parameterCollection)
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

        private List<ParameterDetail> GetParameters(IEnumerable<KeyValuePair<string, Entity>> parameterCollection)
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
    }
}