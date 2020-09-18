namespace Springboard365.Xrm.Plugins.Core.IntegrationTest
{
    using System;
    using System.IO;
    using System.Linq;
    using Microsoft.Xrm.Sdk;
    using Microsoft.Xrm.Sdk.Query;

    public class CrmReader : ICrmReader
    {
        private readonly IOrganizationService organizationService;

        public CrmReader(IOrganizationService organizationService)
        {
            this.organizationService = organizationService;
        }

        public EntityReference GetSystemUser()
        {
            var query = new QueryByAttribute
            {
                EntityName = "systemuser",
                ColumnSet = new ColumnSet("systemuserid")
            };
            query.AddAttributeValue("firstname", "David");

            var entityCollection = organizationService.RetrieveMultiple(query);

            return entityCollection.Entities.First().ToEntityReference();
        }

        public Guid GetOrCreateQueue(string queueName)
        {
            var query = new QueryByAttribute
            {
                EntityName = "queue",
                ColumnSet = new ColumnSet("queueid")
            };
            query.AddAttributeValue("name", queueName);

            var entityCollection = organizationService.RetrieveMultiple(query);

            if (entityCollection.Entities.Count > 0)
            {
                return entityCollection.Entities.First().Id;
            }

            var queueEntity = new Entity("queue");
            queueEntity["name"] = queueName;
            return organizationService.Create(queueEntity);
        }

        public EntityReference GetCurrencyId()
        {
            var query = new QueryExpression
            {
                EntityName = "transactioncurrency",
                ColumnSet = new ColumnSet("transactioncurrencyid")
            };

            var entityCollection = organizationService.RetrieveMultiple(query);

            if (entityCollection.Entities.Count == 0)
            {
                throw new InvalidDataException("No currency records exist.");
            }

            return entityCollection.Entities.First().ToEntityReference();
        }

        public EntityReference GetContractTemplateId()
        {
            var query = new QueryExpression
            {
                EntityName = "contracttemplate",
                ColumnSet = new ColumnSet("contracttemplateid")
            };

            var entityCollection = organizationService.RetrieveMultiple(query);

            if (entityCollection.Entities.Count == 0)
            {
                throw new InvalidDataException("No contract template records exist.");
            }

            return entityCollection.Entities.First().ToEntityReference();
        }
    }
}