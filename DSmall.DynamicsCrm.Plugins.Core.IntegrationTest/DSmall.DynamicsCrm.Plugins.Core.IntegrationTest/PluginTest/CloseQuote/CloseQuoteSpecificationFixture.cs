namespace DSmall.DynamicsCrm.Plugins.Core.IntegrationTest
{
    using Microsoft.Crm.Sdk.Messages;
    using Microsoft.Xrm.Sdk;

    /// <summary>The close quote specification fixture.</summary>
    public class CloseQuoteSpecificationFixture : SpecificationFixtureBase
    {
        /// <summary>Gets the close quote request.</summary>
        public CloseQuoteRequest CloseQuoteRequest { get; private set; }

        /// <summary>Gets the message name.</summary>
        public string MessageName { get; private set; }

        /// <summary>The perform test setup.</summary>
        public void PerformTestSetup()
        {
            MessageName = "Close";

            var quoteEntity = EntityFactory.CreateQuote();

            var quoteClose = new Entity("quoteclose");
            quoteClose["subject"] = "DummyQuoteClose";
            quoteClose["quoteid"] = quoteEntity.ToEntityReference();

            var setStateRequest = new SetStateRequest
            {
                EntityMoniker = quoteEntity.ToEntityReference(),
                State = new OptionSetValue(1),
                Status = new OptionSetValue(2)
            };

            OrganizationService.Execute(setStateRequest);

            CloseQuoteRequest = new CloseQuoteRequest
            {
                QuoteClose = quoteClose,
                Status = new OptionSetValue(5),
            };
        }
    }
}