namespace DSmall.DynamicsCrm.Plugins.Core.IntegrationTest
{
    using Microsoft.Crm.Sdk.Messages;

    /// <summary>The clone contract specification fixture.</summary>
    public class CloneContractSpecificationFixture : SpecificationFixtureBase
    {
        /// <summary>Gets the clone contract request.</summary>
        public CloneContractRequest CloneContractRequest { get; private set; }

        /// <summary>Gets the message name.</summary>
        public string MessageName { get; private set; }

        /// <summary>The perform test setup.</summary>
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