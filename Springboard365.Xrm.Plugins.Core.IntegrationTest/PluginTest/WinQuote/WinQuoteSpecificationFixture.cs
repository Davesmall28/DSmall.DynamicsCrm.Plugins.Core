namespace Springboard365.Xrm.Plugins.Core.IntegrationTest
{
    using Microsoft.Crm.Sdk.Messages;
    using Microsoft.Xrm.Sdk;

    public class WinQuoteSpecificationFixture : SpecificationFixtureBase
    {
        public WinQuoteRequest WinQuoteRequest { get; private set; }

        public WinQuoteSpecificationFixture()
            : base("Win")
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

            WinQuoteRequest = new WinQuoteRequest
            {
                QuoteClose = quoteClose,
                Status = new OptionSetValue(4),
            };
        }
    }
}