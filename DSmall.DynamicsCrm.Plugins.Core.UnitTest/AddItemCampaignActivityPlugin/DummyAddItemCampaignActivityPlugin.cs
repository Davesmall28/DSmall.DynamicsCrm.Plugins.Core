namespace DSmall.DynamicsCrm.Plugins.Core.UnitTest
{
    using System;
    using Microsoft.Xrm.Sdk;

    /// <summary>The dummy add item campaign activity plugin.</summary>
    public class DummyAddItemCampaignActivityPlugin : AddItemCampaignActivityPlugin
    {
        /// <summary>The execute.</summary>
        /// <param name="organizationService">The organization service.</param>
        /// <param name="pluginExecutionContext">The plugin execution context.</param>
        /// <param name="tracingService">The tracing service.</param>
        /// <param name="campaignActivityId">The campaign activity id.</param>
        /// <param name="itemId">The item id.</param>
        /// <param name="entityName">The entity name.</param>
        public override void Execute(
            IOrganizationService organizationService,
            IPluginExecutionContext pluginExecutionContext,
            ITracingService tracingService,
            Guid campaignActivityId,
            Guid itemId,
            string entityName)
        {
            throw new NotImplementedException();
        }
    }
}