namespace DSmall.DynamicsCrm.Plugins.Core.IntegrationTest
{
    using System;
    using Microsoft.Xrm.Sdk;

    /// <summary>The entity factory.</summary>
    public class EntityFactory
    {
        private readonly IOrganizationService organizationService;

        /// <summary>Initialises a new instance of the <see cref="EntityFactory"/> class.</summary>
        /// <param name="organizationService">The organization service.</param>
        public EntityFactory(IOrganizationService organizationService)
        {
            this.organizationService = organizationService;
        }

        /// <summary>The create contact.</summary>
        /// <returns>The <see cref="Guid"/>.</returns>
        public Entity CreateContact()
        {
            var targetEntity = new Entity("contact")
            {
                Id = Guid.NewGuid()
            };
            targetEntity["firstname"] = "DummyFirstName";

            organizationService.Create(targetEntity);

            return targetEntity;
        }

        /// <summary>The create letter.</summary>
        /// <returns>The <see cref="Entity"/>.</returns>
        public Entity CreateLetter()
        {
            var targetEntity = new Entity("letter")
            {
                Id = Guid.NewGuid()
            };
            targetEntity["subject"] = "DummySubject";

            organizationService.Create(targetEntity);

            return targetEntity;
        }
    }
}
