namespace Springboard365.Xrm.Plugins.Core.IntegrationTest
{
    using System;
    using Microsoft.Xrm.Sdk;
    using Microsoft.Xrm.Sdk.Messages;

    public class CrmWriter : ICrmWriter
    {
        private readonly IOrganizationService organizationService;

        public CrmWriter(IOrganizationService organizationService)
        {
            this.organizationService = organizationService;
        }

        public Guid Create(Guid requestId, Entity entity)
        {
            var request = new CreateRequest
            {
                Target = entity,
            };

            var response = (CreateResponse)Execute(requestId, request);

            return response.id;
        }

        public void Update(Guid requestId, Entity entity)
        {
            var request = new UpdateRequest
            {
                Target = entity,
            };

            Execute(requestId, request);
        }

        public void Delete(Guid requestId, EntityReference entityReference)
        {
            var request = new DeleteRequest
            {
                Target = entityReference
            };

            Execute(requestId, request);
        }

        public OrganizationResponse Execute(Guid requestId, OrganizationRequest organizationRequest)
        {
            organizationRequest.RequestId = requestId;
            return organizationService.Execute(organizationRequest);
        }
    }
}