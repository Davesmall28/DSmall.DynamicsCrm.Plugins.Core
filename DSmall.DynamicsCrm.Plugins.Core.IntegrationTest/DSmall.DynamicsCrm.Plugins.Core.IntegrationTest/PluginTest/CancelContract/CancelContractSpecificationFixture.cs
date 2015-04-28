namespace DSmall.DynamicsCrm.Plugins.Core.IntegrationTest
{
    using System;
    using Microsoft.Crm.Sdk.Messages;
    using Microsoft.Xrm.Sdk;

    /// <summary>The cancel contract specification fixture.</summary>
    public class CancelContractSpecificationFixture : SpecificationFixtureBase
    {
        /// <summary>Gets the cancel contract request.</summary>
        public CancelContractRequest CancelContractRequest { get; private set; }

        /// <summary>Gets the message name.</summary>
        public string MessageName { get; private set; }

        /// <summary>The perform test setup.</summary>
        public void PerformTestSetup()
        {
            MessageName = "Cancel";

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