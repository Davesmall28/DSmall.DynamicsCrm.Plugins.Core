namespace DSmall.DynamicsCrm.Plugins.Core.UnitTest
{
    using System;
    using Microsoft.Xrm.Sdk;
    using Moq;

    /// <summary>The service provider initializer.</summary>
    public class ServiceProviderInitializer
    {
        /// <summary>The setup.</summary>
        /// <returns>The <see cref="IServiceProvider"/>.</returns>
        public Mock<IServiceProvider> Setup()
        {
            var mockPluginContext = SetupPluginContext();
            var mockOrganizationServiceFactory = SetupOrganizationServiceFactory();
            var mockTracingService = new Mock<ITracingService>();

            return SetupServiceProvider(mockPluginContext, mockOrganizationServiceFactory, mockTracingService);
        }

        /// <summary>The setup for merge plugin.</summary>
        /// <returns>The <see cref="Mock"/>.</returns>
        public Mock<IServiceProvider> SetupForMergePlugin()
        {
            var mockPluginContext = SetupPluginContextForMergePlugin();
            var mockOrganizationServiceFactory = SetupOrganizationServiceFactory();
            var mockTracingService = new Mock<ITracingService>();

            return SetupServiceProvider(mockPluginContext, mockOrganizationServiceFactory, mockTracingService);
        }

        /// <summary>The setup organization service factory.</summary>
        /// <returns>The <see cref="Mock"/>.</returns>
        public Mock<IOrganizationServiceFactory> SetupOrganizationServiceFactory()
        {
            var mockOrganizationService = new Mock<IOrganizationService>();
            var mockOrganizationServiceFactory = new Mock<IOrganizationServiceFactory>();

            mockOrganizationServiceFactory
                .Setup(factory => factory.CreateOrganizationService(It.IsAny<Guid?>()))
                .Returns(mockOrganizationService.Object);

            return mockOrganizationServiceFactory;
        }

        /// <summary>The setup plugin context.</summary>
        /// <returns>The <see cref="Mock"/>.</returns>
        public Mock<IPluginExecutionContext> SetupPluginContext()
        {
            var mockPluginContext = new Mock<IPluginExecutionContext>();
            mockPluginContext
                .Setup(context => context.UserId)
                .Returns(Guid.NewGuid);

            mockPluginContext
                .Setup(context => context.InputParameters)
                .Returns(GetTargetEntityCollection);
            mockPluginContext
                .Setup(context => context.PreEntityImages)
                .Returns(GetPreImageEntityCollection);
            mockPluginContext
                .Setup(context => context.PostEntityImages)
                .Returns(GetPostImageEntityCollection);

            return mockPluginContext;
        }

        /// <summary>The setup plugin context with null target entity.</summary>
        /// <returns>The <see cref="Mock"/>.</returns>
        public Mock<IPluginExecutionContext> SetupPluginContextWithNullPostImage()
        {
            var mockPluginContext = new Mock<IPluginExecutionContext>();
            mockPluginContext
                .Setup(context => context.PostEntityImages)
                .Returns(new EntityImageCollection { { "PostImage", null } });
            return mockPluginContext;
        }

        private static Mock<IServiceProvider> SetupServiceProvider(Mock<IPluginExecutionContext> mockPluginContext, Mock<IOrganizationServiceFactory> mockOrganizationServiceFactory, Mock<ITracingService> mockTracingService)
        {
            var serviceProvider = new Mock<IServiceProvider>();
            serviceProvider.Setup(provider => provider.GetService(typeof(IPluginExecutionContext)))
                           .Returns(mockPluginContext.Object);
            serviceProvider.Setup(provider => provider.GetService(typeof(IOrganizationServiceFactory)))
                           .Returns(mockOrganizationServiceFactory.Object);
            serviceProvider.Setup(provider => provider.GetService(typeof(ITracingService))).Returns(mockTracingService.Object);

            return serviceProvider;
        }

        private static Mock<IPluginExecutionContext> SetupPluginContextForMergePlugin()
        {
            var mockPluginContext = new Mock<IPluginExecutionContext>();
            mockPluginContext
                .Setup(context => context.UserId)
                .Returns(Guid.NewGuid);

            mockPluginContext
                .Setup(context => context.InputParameters)
                .Returns(GetMergePluginEntityCollection);

            return mockPluginContext;
        }

        private static ParameterCollection GetMergePluginEntityCollection()
        {
            return new ParameterCollection
            {
                { "Target", new EntityReference("contact", Guid.NewGuid()) },
                { "SubordinateId", Guid.NewGuid() },
                { "UpdateContent", new Entity("contact") { Id = Guid.NewGuid() } }
            };
        }

        private static ParameterCollection GetTargetEntityCollection()
        {
            return new ParameterCollection
            {
                { "Target", new Entity("contact") { Id = Guid.NewGuid() } }
            };
        }

        private static EntityImageCollection GetPostImageEntityCollection()
        {
            return new EntityImageCollection
            {
                { "PostImage", new Entity("contact") { Id = Guid.NewGuid() } }
            };
        }

        private static EntityImageCollection GetPreImageEntityCollection()
        {
            return new EntityImageCollection
            {
                { "PreImage", new Entity("contact") { Id = Guid.NewGuid() } }
            };
        }
    }
}