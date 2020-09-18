namespace Springboard365.Xrm.Plugins.Core.IntegrationTest
{
    using System;
    using Microsoft.Xrm.Sdk;

    public interface ICrmReader
    {
        EntityReference GetSystemUser();

        Guid GetOrCreateQueue(string queueName);

        EntityReference GetCurrencyId();

        EntityReference GetContractTemplateId();
    }
}