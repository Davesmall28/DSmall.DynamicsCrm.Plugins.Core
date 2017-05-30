namespace Springboard365.Xrm.Plugins.Core.IntegrationTest
{
    using Microsoft.Crm.Sdk.Messages;

    public class CloneContractSpecificationFixture : SpecificationFixtureBase
    {
        public CloneContractRequest CloneContractRequest { get; private set; }

        public string MessageName { get; private set; }

        public void PerformTestSetup()
        {
            MessageName = "Clone";

            var contractEntity = EntityFactory.CreateContract();

            CloneContractRequest = new CloneContractRequest
            {
                ContractId = contractEntity.Id,
                IncludeCanceledLines = true
            };
        }
    }
}