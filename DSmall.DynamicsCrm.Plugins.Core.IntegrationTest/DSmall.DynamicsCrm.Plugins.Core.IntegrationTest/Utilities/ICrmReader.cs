namespace DSmall.DynamicsCrm.Plugins.Core.IntegrationTest
{
    using System;
    using Microsoft.Xrm.Sdk;

    public interface ICrmReader
    {
        /// <summary>The get system user.</summary>
        /// <returns>The <see cref="EntityReference"/>.</returns>
        EntityReference GetSystemUser();

        /// <summary>The get or create queue.</summary>
        /// <param name="queueName">The queue name.</param>
        /// <returns>The <see cref="Guid"/>.</returns>
        Guid GetOrCreateQueue(string queueName);

        /// <summary>The get currency id.</summary>
        /// <returns>The <see cref="EntityReference"/>.</returns>
        EntityReference GetCurrencyId();

        /// <summary>The get contract template id.</summary>
        /// <returns>The <see cref="EntityReference"/>.</returns>
        EntityReference GetContractTemplateId();
    }
}