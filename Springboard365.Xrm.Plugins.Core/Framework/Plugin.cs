namespace Springboard365.Xrm.Plugins.Core.Framework
{
    using System;
    using Microsoft.Xrm.Sdk;
    using Springboard365.Core;
    using Springboard365.Xrm.Core;

    public abstract class Plugin : IPlugin
    {
        protected Plugin()
        {
            EntityValidator = new EntityValidator();
        }

        protected Plugin(IEntityValidator entityValidator)
        {
            EntityValidator = entityValidator;
        }

        protected IEntityValidator EntityValidator { get; private set; }

        protected abstract void Execute(IOrganizationService organizationService, IPluginExecutionContext pluginExecutionContext, ITracingService tracingService);

        public void Execute(IServiceProvider serviceProvider)
        {
            Guard.NotNull(serviceProvider);

            var tracingService = (ITracingService)serviceProvider.GetService(typeof(ITracingService));
            var pluginExecutionContext = (IPluginExecutionContext)serviceProvider.GetService(typeof(IPluginExecutionContext));
            var organizationService = CreateCrmService(serviceProvider, pluginExecutionContext.UserId);

            Execute(organizationService, pluginExecutionContext, tracingService);
        }

        private static IOrganizationService CreateCrmService(IServiceProvider serviceProvider, Guid userId)
        {
            var service = (IOrganizationServiceFactory)serviceProvider.GetService(typeof(IOrganizationServiceFactory));
            return service.CreateOrganizationService(userId);
        }
    }
}