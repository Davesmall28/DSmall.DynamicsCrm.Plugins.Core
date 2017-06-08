namespace Springboard365.Xrm.Plugins.Core.IntegrationTest
{
    using System;
    using System.Configuration;
    using System.ServiceModel.Description;
    using Microsoft.Xrm.Sdk;
    using Microsoft.Xrm.Sdk.Client;
    using Model;

    public abstract class SpecificationFixtureBase
    {
        private const string CrmUrlSettingName = "CrmUrl"; 
        private const string CrmUserNameSettingName = "CrmUserName";
        private const string CrmPasswordSettingName = "CrmPassword";
        private const string CrmDeviceIdSettingName = "CrmDeviceId";
        private const string CrmDevicePasswordSettingName = "CrmDevicePassword";

        protected SpecificationFixtureBase()
        {
            OrganizationService = new OrganizationServiceProxy(GetUri(), null, GetClientCredentials(), GetDeviceCredentials());
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

        public PluginParameters Result { get; set; }

        public ICrmWriter CrmWriter { get; private set; }

        public IEntitySerializer EntitySerializer { get; private set; }

        public Guid RequestId { get; private set; }

        public string MessageName { get; protected set; }

        protected IOrganizationService OrganizationService { get; }

        protected ICrmReader CrmReader { get; private set; }

        protected IEntityFactory EntityFactory { get; private set; }

        private static Uri GetUri()
        {
            return new Uri(ConfigurationManager.AppSettings.Get(CrmUrlSettingName));
        }

        private static ClientCredentials GetClientCredentials()
        {
            return Create(
                ConfigurationManager.AppSettings.Get(CrmUserNameSettingName),
                ConfigurationManager.AppSettings.Get(CrmPasswordSettingName));
        }

        private static ClientCredentials GetDeviceCredentials()
        {
            return Create(
                ConfigurationManager.AppSettings.Get(CrmDeviceIdSettingName),
                ConfigurationManager.AppSettings.Get(CrmDevicePasswordSettingName));
        }

        private static ClientCredentials Create(string userName, string password)
        {
            return new ClientCredentials
            {
                UserName =
                {
                    UserName = userName,
                    Password = password
                }
            };
        }
    }
}