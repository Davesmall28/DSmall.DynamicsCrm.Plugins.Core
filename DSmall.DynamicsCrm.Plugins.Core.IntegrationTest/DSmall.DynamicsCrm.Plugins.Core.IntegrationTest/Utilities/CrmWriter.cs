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
                RequestId = requestId,
                Target = entity,
            };

            var response = (CreateResponse)organizationService.Execute(request);

            return response.id;
        }

        /// <summary>The update entity.</summary>
        /// <param name="requestId">The request Id.</param>
        /// <param name="entity">The entity.</param>
        /// <returns>The <see cref="Guid"/>.</returns>
        public Guid Update(Guid requestId, Entity entity)
        {
            var request = new UpdateRequest
            {
                RequestId = requestId,
                Target = entity,
            };

            organizationService.Execute(request);

            return entity.Id;
        }

        /// <summary>The execute.</summary>
        /// <param name="requestId">The request Id.</param>
        /// <param name="organizationRequest">The organization request.</param>
        public void Execute(Guid requestId, OrganizationRequest organizationRequest)
        {
            organizationRequest.RequestId = requestId;
            organizationService.Execute(organizationRequest);
        }
    }
}