namespace DSmall.DynamicsCrm.Plugins.Core.UnitTest
{
    using System;
    using Microsoft.Xrm.Sdk;

    /// <summary>The dummy add item campaign plugin.</summary>
    public class DummyAddItemCampaignPlugin : AddItemCampaignPlugin
    {
        /// <summary>The execute.</summary>
        /// <param name="organizationService">The organization service.</param>
        /// <param name="pluginExecutionContext">The plugin execution context.</param>
        /// <param name="tracingService">The tracing service.</param>
        /// <param name="campaignId">The campaign id.</param>
        /// <param name="entityId">The entity id.</param>
        /// <param name="entityName">The entity name.</param>
        public override void Execute(
            IOrganizationService organizationService,
            IPluginExecutionContext pluginExecutionContext,
            ITracingService tracingService,
            Guid campaignId,
            Guid entityId,
            string entityName)
        {
            throw new NotImplementedException();
        }
    }
}