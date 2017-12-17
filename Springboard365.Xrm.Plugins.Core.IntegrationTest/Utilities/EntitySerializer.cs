namespace Springboard365.Xrm.Plugins.Core.IntegrationTest
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Xml.Serialization;
    using Microsoft.Xrm.Sdk;
    using Microsoft.Xrm.Sdk.Client;
    using Springboard365.Xrm.Plugins.Core.Model;

    public class EntitySerializer : IEntitySerializer
    {
        private readonly IOrganizationService organizationService;

        public EntitySerializer(IOrganizationService organizationService)
        {
            this.organizationService = organizationService;
        }

        public PluginParameters Deserialize(Guid requestId, string messageName)
        {
            using (var crmServiceContext = new OrganizationServiceContext(organizationService))
            {
                var pluginParameters = from p in crmServiceContext.CreateQuery("sb365_pluginparameter")
                                       where ((string)p["sb365_pluginexecutionrequestid"]).Equals(requestId.ToString())
                                          && ((string)p["sb365_messagename"]).Equals(messageName)
                                       select p["sb365_pluginparameters"].ToString();

                return GetObject(pluginParameters.Single());
            }
        }

        private static PluginParameters GetObject(string xmlBlob)
        {
            var stringReader = new StringReader(xmlBlob);
            var serializer = new XmlSerializer(typeof(PluginParameters));
            return (PluginParameters)serializer.Deserialize(stringReader);
        }
    }
}