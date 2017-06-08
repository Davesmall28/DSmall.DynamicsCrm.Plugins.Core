namespace Springboard365.Xrm.Plugins.Core.IntegrationTest
{
    using System;
    using Microsoft.Crm.Sdk.Messages;
    using Microsoft.Xrm.Sdk;

    public class CancelContractSpecificationFixture : SpecificationFixtureBase
    {
        public CancelContractRequest CancelContractRequest { get; private set; }

        public CancelContractSpecificationFixture()
            : base("Cancel")
        {
        }

        public void PerformTestSetup()
        {
            var contractEntity = EntityFactory.CreateContract();
            
            CancelContractRequest = new CancelContractRequest
            {
                ContractId = contractEntity.Id,
                CancelDate = DateTime.Now,
                Status = new OptionSetValue(5)
            };
        }
    }
}