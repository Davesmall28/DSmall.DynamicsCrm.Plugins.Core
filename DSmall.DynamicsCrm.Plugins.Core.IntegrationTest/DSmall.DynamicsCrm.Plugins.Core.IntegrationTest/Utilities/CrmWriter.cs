namespace DSmall.DynamicsCrm.Plugins.Core.IntegrationTest
{
    using System;
    using Microsoft.Xrm.Sdk;
    using Microsoft.Xrm.Sdk.Messages;

    /// <summary>The crm writer.</summary>
    public class CrmWriter
    {
        private readonly IOrganizationService organizationService;

        /// <summary>Initialises a new instance of the <see cref="CrmWriter"/> class.</summary>
        /// <param name="organizationService">The organization service.</param>
        public CrmWriter(IOrganizationService organizationService)
        {
            this.organizationService = organizationService;
        }

        /// <summary>The create entity.</summary>
        /// <param name="requestId">The request Id.</param>
        /// <param name="entity">The entity.</param>
        /// <returns>The <see cref="Guid"/>.</returns>
        public Guid Create(Guid requestId, Entity entity)
        {
            var request = new CreateRequest
            {
                Target = entity,
            };

            var response = (CreateResponse)Execute(requestId, request);

            return response.id;
        }

        /// <summary>The update entity.</summary>
        /// <param name="requestId">The request Id.</param>
        /// <param name="entity">The entity.</param>
        public void Update(Guid requestId, Entity entity)
        {
            var request = new UpdateRequest
            {
                Target = entity,
            };

            Execute(requestId, request);
        }

        /// <summary>The delete.</summary>
        /// <param name="requestId">The request id.</param>
        /// <param name="entityReference">The entity reference.</param>
        public void Delete(Guid requestId, EntityReference entityReference)
        {
            var request = new DeleteRequest
            {
                Target = entityReference
            };

            Execute(requestId, request);
        }

        /// <summary>The execute.</summary>
        /// <param name="requestId">The request Id.</param>
        /// <param name="organizationRequest">The organization request.</param>
        /// <returns>The <see cref="OrganizationResponse"/>.</returns>
        public OrganizationResponse Execute(Guid requestId, OrganizationRequest organizationRequest)
        {
            organizationRequest.RequestId = requestId;
            return organizationService.Execute(organizationRequest);
        }
    }
}