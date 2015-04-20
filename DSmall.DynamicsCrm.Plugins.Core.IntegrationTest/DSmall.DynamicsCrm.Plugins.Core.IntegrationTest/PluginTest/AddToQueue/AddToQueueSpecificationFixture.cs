namespace DSmall.DynamicsCrm.Plugins.Core.IntegrationTest
{
    using System;
    using Microsoft.Crm.Sdk.Messages;
    using Microsoft.Xrm.Sdk;

    /// <summary>The add to queue specification fixture.</summary>
    public class AddToQueueSpecificationFixture : SpecificationFixtureBase
    {
        /// <summary>Gets or sets the add to queue request.</summary>
        public AddToQueueRequest AddToQueueRequest { get; set; }

        /// <summary>Gets the message name.</summary>
        public string MessageName { get; private set; }

        /// <summary>The perform test setup.</summary>
        public void PerformTestSetup()
        {
            MessageName = "AddToQueue";

            var targetEntity = EntityFactory.CreateLetter();

            AddToQueueRequest = new AddToQueueRequest
            {
                Target = targetEntity.ToEntityReference(),
                DestinationQueueId = CrmReader.GetOrCreateQueue("queueName"),
                QueueItemProperties = new Entity("queueitem")
            };
        }
    }
}