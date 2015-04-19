namespace DSmall.DynamicsCrm.Plugins.Core.IntegrationTest
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Xml.Serialization;
    using DSmall.DynamicsCrm.Plugins.Core.IntegrationTest.Model;
    using Microsoft.Xrm.Sdk;
    using Microsoft.Xrm.Sdk.Client;

    /// <summary>The entity serializer.</summary>
    public class EntitySerializer
    {
        private readonly IOrganizationService organizationService;

        /// <summary>Initialises a new instance of the <see cref="EntitySerializer"/> class.</summary>
        /// <param name="organizationService">The organization service.</param>
        public EntitySerializer(IOrganizationService organizationService)
        {
            this.organizationService = organizationService;
        }

        /// <summary>The deserialize.</summary>
        /// <param name="requestId">The request id.</param>
        /// <param name="messageName">The message name.</param>
        /// <returns>The <see cref="PluginParameters"/>.</returns>
        public PluginParameters Deserialize(Guid requestId, string messageName)
        {
            using (var crmServiceContext = new OrganizationServiceContext(organizationService))
            {
                var pluginParameters = from p in crmServiceContext.CreateQuery("ds_pluginparameter")
                                       where ((string)p["ds_pluginexecutionrequestid"]).Contains(requestId.ToString())
                                          && ((string)p["ds_messagename"]).Equals(messageName)
                                       select p["ds_pluginparameters"].ToString();

                return GetObject(pluginParameters.Single());
            }
        }

        private PluginParameters GetObject(string xmlBlob)
        {
            var stringReader = new StringReader(xmlBlob);
            var serializer = new XmlSerializer(typeof(PluginParameters));
            return (PluginParameters)serializer.Deserialize(stringReader);
        }
    }
}
