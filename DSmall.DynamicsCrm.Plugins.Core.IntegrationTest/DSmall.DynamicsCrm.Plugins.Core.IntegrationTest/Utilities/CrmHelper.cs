namespace DSmall.DynamicsCrm.Plugins.Core.IntegrationTest
{
    using System;
    using Microsoft.Xrm.Sdk;

    /// <summary>The crm helper.</summary>
    public class CrmHelper
    {
        private readonly IOrganizationService organizationService;

        /// <summary>Initialises a new instance of the <see cref="CrmHelper"/> class.</summary>
        /// <param name="organizationService">The organization service.</param>
        public CrmHelper(IOrganizationService organizationService)
        {
            this.organizationService = organizationService;
        }

        /// <summary>The create contact.</summary>
        /// <param name="entity">The entity.</param>
        /// <returns>The <see cref="Guid"/>.</returns>
        public Guid CreateContact(Entity entity)
        {
            return organizationService.Create(entity);
        }

        /// <summary>The create contact.</summary>
        /// <param name="entity">The entity.</param>
        /// <returns>The <see cref="Guid"/>.</returns>
        public Guid UpdateContact(Entity entity)
        {
            organizationService.Update(entity);

            return entity.Id;
        }
    }
}