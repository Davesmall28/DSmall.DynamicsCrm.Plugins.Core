namespace Springboard365.Xrm.Plugins.Core.IntegrationTest
{
    using System;
    using System.Configuration;
    using System.ServiceModel.Description;
    using Microsoft.Xrm.Sdk;
    using Microsoft.Xrm.Sdk.Client;
    using Springboard365.Xrm.Plugins.Core.Model;

    public abstract class SpecificationFixtureBase
    {
        private const string CrmUrlSettingName = "CrmUrl"; 
        private const string CrmUserNameSettingName = "CrmUserName";
        private const string CrmPasswordSettingName = "CrmPassword";

        protected SpecificationFixtureBase()
        {
            var uri = new Uri(ConfigurationManager.AppSettings.Get(CrmUrlSettingName));
            var clientCredentials = new ClientCredentials();
            clientCredentials.UserName.UserName = ConfigurationManager.AppSettings.Get(CrmUserNameSettingName);
            clientCredentials.UserName.Password = ConfigurationManager.AppSettings.Get(CrmPasswordSettingName);
            OrganizationService = new OrganizationServiceProxy(uri, null, clientCredentials, null);
            CrmReader = new CrmReader(OrganizationService);
            CrmWriter = new CrmWriter(OrganizationService);
            EntityFactory = new EntityFactory(OrganizationService, new CrmReader(OrganizationService));
            EntitySerializer = new EntitySerializer(OrganizationService);
            RequestId = Guid.NewGuid();
        }

        protected SpecificationFixtureBase(string messageName)
            : this()
        {
            MessageName = messageName;
        }

        public IOrganizationService OrganizationService { get; }

        public ICrmReader CrmReader { get; private set; }

        public ICrmWriter CrmWriter { get; private set; }

        public IEntityFactory EntityFactory { get; private set; }

        public IEntitySerializer EntitySerializer { get; private set; }

        public PluginParameters Result { get; set; }

        public Guid RequestId { get; private set; }

        public string MessageName { get; protected set; }
    }
}