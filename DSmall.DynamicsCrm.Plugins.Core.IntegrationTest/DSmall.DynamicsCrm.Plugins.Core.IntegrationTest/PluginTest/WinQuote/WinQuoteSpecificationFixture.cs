namespace DSmall.DynamicsCrm.Plugins.Core.IntegrationTest
{
    using Microsoft.Crm.Sdk.Messages;
    using Microsoft.Xrm.Sdk;

    /// <summary>The win quote specification fixture.</summary>
    public class WinQuoteSpecificationFixture : SpecificationFixtureBase
    {
        /// <summary>Gets the win quote request.</summary>
        public WinQuoteRequest WinQuoteRequest { get; private set; }

        /// <summary>Gets the message name.</summary>
        public string MessageName { get; private set; }

        /// <summary>The perform test setup.</summary>
        public void PerformTestSetup()
        {
            MessageName = "Win";

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

            WinQuoteRequest = new WinQuoteRequest
            {
                QuoteClose = quoteClose,
                Status = new OptionSetValue(4),
            };
        }
    }
}