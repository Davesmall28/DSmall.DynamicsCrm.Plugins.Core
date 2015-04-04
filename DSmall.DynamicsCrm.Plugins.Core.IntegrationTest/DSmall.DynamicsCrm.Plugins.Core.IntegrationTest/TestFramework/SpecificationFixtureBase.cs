﻿namespace DSmall.DynamicsCrm.Plugins.Core.IntegrationTest
{
    using System;
    using DSmall.DynamicsCrm.Plugins.Core.IntegrationTest.Model;
    using Microsoft.Xrm.Client.Services;
    using Microsoft.Xrm.Sdk;

    /// <summary>The specification fixture base.</summary>
    public class SpecificationFixtureBase
    {
        private const string ConnectionStringSettingName = "CrmConnection";

        /// <summary>Initialises a new instance of the <see cref="SpecificationFixtureBase"/> class.</summary>
        public SpecificationFixtureBase()
        {
            OrganizationService = new OrganizationService(ConnectionStringSettingName);
            CrmWriter = new CrmWriter(OrganizationService);
            CleanUp = new CrmCleaner(OrganizationService);
            EntitySerializer = new EntitySerializer(OrganizationService);
            RequestId = Guid.NewGuid();
        }

        /// <summary>Gets the organization service.</summary>
        public IOrganizationService OrganizationService { get; private set; }

        /// <summary>Gets the crm helper.</summary>
        public CrmWriter CrmWriter { get; private set; }

        /// <summary>Gets the clean up.</summary>
        public CrmCleaner CleanUp { get; private set; }

        /// <summary>Gets the entity serializer.</summary>
        public EntitySerializer EntitySerializer { get; private set; }

        /// <summary>Gets or sets the result.</summary>
        public PluginParameters Result { get; set; }

        /// <summary>Gets the request id.</summary>
        public Guid RequestId { get; private set; }
    }
}