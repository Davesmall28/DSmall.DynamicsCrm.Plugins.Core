namespace DSmall.DynamicsCrm.Plugins.Core.IntegrationTest
{
    using System;
    using Microsoft.Xrm.Sdk;

    /// <summary>The crm cleaner.</summary>
    public class CrmCleaner
    {
        private readonly IOrganizationService organizationService;

        /// <summary>Initialises a new instance of the <see cref="CrmCleaner"/> class.</summary>
        /// <param name="organizationService">The organization service.</param>
        public CrmCleaner(IOrganizationService organizationService)
        {
            this.organizationService = organizationService;
        }

        /// <summary>The delete entity.</summary>
        /// <param name="entityName">The entity name.</param>
        /// <param name="entityId">The entity id.</param>
        public void DeleteEntity(string entityName, Guid entityId)
        {
            organizationService.Delete(entityName, entityId);
        }
    }
}