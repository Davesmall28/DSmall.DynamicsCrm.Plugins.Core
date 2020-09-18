namespace Springboard365.Xrm.Plugins.Core.IntegrationTest
{
    using System;
    using System.Configuration;
    using System.Net;
    using Microsoft.Xrm.Sdk;
    using Microsoft.Xrm.Tooling.Connector;
    using Springboard365.Xrm.Plugins.Core.Model;

    public class SpecificationFixtureBase
    {
        private const string ConnectionStringSettingName = "CrmConnection";

        public SpecificationFixtureBase()
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            var connectionString = ConfigurationManager.ConnectionStrings[ConnectionStringSettingName].ConnectionString;
            OrganizationService = new CrmServiceClient(connectionString);
            CrmReader = new CrmReader(OrganizationService);
            CrmWriter = new CrmWriter(OrganizationService);
            EntityFactory = new EntityFactory(OrganizationService, new CrmReader(OrganizationService));
            EntitySerializer = new EntitySerializer(OrganizationService);
            RequestId = Guid.NewGuid();
        }

        public IOrganizationService OrganizationService { get; private set; }

        public ICrmReader CrmReader { get; private set; }

        public ICrmWriter CrmWriter { get; private set; }

        public IEntityFactory EntityFactory { get; private set; }

        public IEntitySerializer EntitySerializer { get; private set; }

        public PluginParameters Result { get; set; }

        public Guid RequestId { get; private set; }
    }
}