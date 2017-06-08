namespace Springboard365.Xrm.Plugins.Core.IntegrationTest
{
    using Microsoft.Crm.Sdk.Messages;
    using Microsoft.Xrm.Sdk;

    public class AddToQueueSpecificationFixture : SpecificationFixtureBase
    {
        public AddToQueueRequest AddToQueueRequest { get; private set; }

        public AddToQueueSpecificationFixture()
            : base("AddToQueue")
        {
        }

        public void PerformTestSetup()
        {
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