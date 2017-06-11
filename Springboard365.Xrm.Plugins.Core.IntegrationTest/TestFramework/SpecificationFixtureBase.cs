namespace Springboard365.Xrm.Plugins.Core.IntegrationTest
{
    using System;
    using System.Configuration;
    using System.IO;
    using System.Reflection;
    using System.Threading;
    using Microsoft.Xrm.Sdk;
    using Microsoft.Xrm.Sdk.Client;
    using Microsoft.Xrm.Sdk.WebServiceClient;
    using Model;
    using Springboard365.Xrm.Authentication;

    public abstract class SpecificationFixtureBase
    {
        private const string CrmUrlSettingName = "CrmUrl"; 
        private const string CrmUserNameSettingName = "CrmUserName";
        private const string CrmPasswordSettingName = "CrmPassword";
        private const string CrmDeviceIdSettingName = "CrmDeviceId";
        private const string CrmDevicePasswordSettingName = "CrmDevicePassword";
        private const string ClientIdSettingName = "ClientId";
        private const string ClientSecretSettingName = "ClientSecret";
        private const string TenantSettingName = "Tenant";
        private const string PlatformSettingName = "Platform";

        private SpecificationFixtureBase()
        {
            if (ConfigurationManager.AppSettings.Get(PlatformSettingName).ToLowerInvariant().Equals("web"))
            { 

                var authenticationService = new AuthenticationService();
                var token = authenticationService.AcquireTokenAsync(
                    ConfigurationManager.AppSettings.Get(CrmUrlSettingName),
                    ConfigurationManager.AppSettings.Get(TenantSettingName),
                    new ClientCredentials(ConfigurationManager.AppSettings.Get(ClientIdSettingName), ConfigurationManager.AppSettings.Get(ClientSecretSettingName)),
                    new UserCredentials(ConfigurationManager.AppSettings.Get(CrmUserNameSettingName), ConfigurationManager.AppSettings.Get(CrmPasswordSettingName))).Result;

                if (token == null)
                {
                    throw new Exception("Token is empty");
                }

                var assembly = Assembly.LoadFrom(Path.Combine(Thread.GetDomain().BaseDirectory, "Microsoft.Crm.Sdk.Proxy.dll"));
                OrganizationService = new OrganizationWebProxyClient(GetUri("/web"), assembly)
                {
                    HeaderToken = token.AccessToken,
                    SdkClientVersion = "8.2"
                };
            }
            else
            {
                OrganizationService = new OrganizationServiceProxy(GetUri(), null, GetClientCredentials(), GetDeviceCredentials());
            }

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

        public string MessageName { get; private set; }

        protected IOrganizationService OrganizationService { get; }

        protected ICrmReader CrmReader { get; private set; }

        protected IEntityFactory EntityFactory { get; private set; }

        private static Uri GetUri(string appendText = null)
        {
            return new Uri(ConfigurationManager.AppSettings.Get(CrmUrlSettingName) + "/XRMServices/2011/Organization.svc" + appendText);
        }

        private static System.ServiceModel.Description.ClientCredentials GetClientCredentials()
        {
            return Create(
                ConfigurationManager.AppSettings.Get(CrmUserNameSettingName),
                ConfigurationManager.AppSettings.Get(CrmPasswordSettingName));
        }

        private static System.ServiceModel.Description.ClientCredentials GetDeviceCredentials()
        {
            return Create(
                ConfigurationManager.AppSettings.Get(CrmDeviceIdSettingName),
                ConfigurationManager.AppSettings.Get(CrmDevicePasswordSettingName));
        }

        private static System.ServiceModel.Description.ClientCredentials Create(string userName, string password)
        {
            return new System.ServiceModel.Description.ClientCredentials
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