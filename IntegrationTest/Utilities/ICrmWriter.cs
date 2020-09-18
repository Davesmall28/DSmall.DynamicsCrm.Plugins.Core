namespace Springboard365.Xrm.Plugins.Core.IntegrationTest
{
    using System;
    using Microsoft.Xrm.Sdk;

    public interface ICrmWriter
    {
        Guid Create(Guid requestId, Entity entity);

        void Delete(Guid requestId, EntityReference entityReference);

        OrganizationResponse Execute(Guid requestId, OrganizationRequest organizationRequest);

        void Update(Guid requestId, Entity entity);
    }
}