namespace Springboard365.Xrm.Plugins.Core.IntegrationTest
{
    using Microsoft.Xrm.Sdk;

    public interface IEntityFactory
    {
        Entity CreateAccount();

        Entity CreateCampaign();

        Entity CreateCampaignActivity(EntityReference campaignReference);

        Entity CreateCase();

        Entity CreateContact();

        Entity CreateContract();

        Entity CreateContractLine(EntityReference entityReference);

        Entity CreateInvoice();

        Entity CreateLead();

        Entity CreateLetter();

        Entity CreateMarketingList();

        Entity CreateOpportunity();

        Entity CreateQuote();

        Entity CreateSalesOrder();
    }
}