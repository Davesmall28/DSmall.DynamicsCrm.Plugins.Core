namespace DSmall.DynamicsCrm.Plugins.Core.Samples
{
    using System.Collections.Generic;
    using System.IO;
    using System.Xml.Serialization;
    using DSmall.DynamicsCrm.Plugins.Core.Samples.Model;
    using Microsoft.Xrm.Sdk;

    /// <summary>The entity writer.</summary>
    public class EntityWriter
    {
        private readonly IOrganizationService organizationService;
        private readonly IPluginExecutionContext pluginExecutionContext;
        private readonly ITracingService tracingService;

        /// <summary>Initialises a new instance of the <see cref="EntityWriter"/> class.</summary>
        /// <param name="organizationService">The organization service.</param>
        /// <param name="pluginExecutionContext">The plugin execution context.</param>
        /// <param name="tracingService">The tracing service.</param>
        public EntityWriter(IOrganizationService organizationService, IPluginExecutionContext pluginExecutionContext, ITracingService tracingService)
        {
            this.organizationService = organizationService;
            this.pluginExecutionContext = pluginExecutionContext;
            this.tracingService = tracingService;
        }

        /// <summary>The populate plugin parameters.</summary>
        /// <returns>The <see cref="PluginParameters"/>.</returns>
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

        /// <summary>The get object as xml.</summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>The <see cref="string"/>.</returns>
        public string GetObjectAsXml(PluginParameters parameters)
        {
            var stringWriter = new StringWriter();
            var serializer = new XmlSerializer(typeof(PluginParameters));
            serializer.Serialize(stringWriter, parameters);

            return stringWriter.ToString();
        }

        /// <summary>The write to entity.</summary>
        /// <param name="xmlBlob">The xml blob.</param>
        public void WriteToEntity(string xmlBlob)
        {
            tracingService.Trace("XmlBlob");
            tracingService.Trace(xmlBlob);

            var name = string.Format("On the {0} of {1}", pluginExecutionContext.MessageName, pluginExecutionContext.PrimaryEntityName);
            tracingService.Trace("Name: {0}", name);

            var toCreate = new Entity("ds_pluginparameter");
            toCreate["id"] = pluginExecutionContext.RequestId;
            toCreate["ds_name"] = name;
            toCreate["ds_messagename"] = pluginExecutionContext.MessageName;
            toCreate["ds_primaryentityname"] = pluginExecutionContext.PrimaryEntityName;
            toCreate["ds_pluginparameters"] = xmlBlob;

            organizationService.Create(toCreate);
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
    }
}