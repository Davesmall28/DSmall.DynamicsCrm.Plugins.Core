namespace DSmall.DynamicsCrm.Plugins.Core
{
    using System;
    using DSmall.DynamicsCrm.Core;
    using Microsoft.Xrm.Sdk;

    /// <summary>The plugin.</summary>
    public abstract class Plugin : IPlugin
    {
        /// <summary>Initialises a new instance of the <see cref="Plugin"/> class.</summary>
        protected Plugin()
        {
            EntityValidator = new EntityValidator();
        }

        /// <summary>Gets the entity validator.</summary>
        public IEntityValidator EntityValidator { get; private set; }

        /// <summary>The execute.</summary>
        /// <param name="organizationService">The organization service.</param>
        /// <param name="pluginExecutionContext">The plugin execution context.</param>
        /// <param name="tracingService">The tracing service.</param>
        public abstract void Execute(IOrganizationService organizationService, IPluginExecutionContext pluginExecutionContext, ITracingService tracingService);

        /// <summary>The execute.</summary>
        /// <param name="serviceProvider">The service provider.</param>
        public void Execute(IServiceProvider serviceProvider)
        {
            if (serviceProvider == null)
            {
                throw new ArgumentNullException("serviceProvider");
            }

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