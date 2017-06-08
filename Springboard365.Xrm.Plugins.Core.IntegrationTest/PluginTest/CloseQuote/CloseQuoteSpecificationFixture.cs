namespace Springboard365.Xrm.Plugins.Core.IntegrationTest
{
    using Microsoft.Crm.Sdk.Messages;
    using Microsoft.Xrm.Sdk;

    public class CloseQuoteSpecificationFixture : SpecificationFixtureBase
    {
        public CloseQuoteRequest CloseQuoteRequest { get; private set; }

        public CloseQuoteSpecificationFixture()
            : base("Close")
        {
        }

        public void PerformTestSetup()
        {
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