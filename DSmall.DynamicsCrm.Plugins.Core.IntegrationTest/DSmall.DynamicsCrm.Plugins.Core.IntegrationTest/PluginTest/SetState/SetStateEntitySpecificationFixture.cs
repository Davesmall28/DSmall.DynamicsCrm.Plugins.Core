namespace DSmall.DynamicsCrm.Plugins.Core.IntegrationTest
{
    using System;
    using Microsoft.Crm.Sdk.Messages;
    using Microsoft.Xrm.Sdk;

    /// <summary>The set state entity specification fixture.</summary>
    public class SetStateEntitySpecificationFixture : SpecificationFixtureBase
    {
        /// <summary>Gets the set state request.</summary>
        public SetStateRequest SetStateRequest { get; private set; }

        /// <summary>Gets the message name.</summary>
        public string MessageName { get; private set; }

        /// <summary>The perform test setup.</summary>
        public void PerformTestSetup()
        {
            MessageName = "SetStateDynamicEntity";

            var targetEntity = new Entity("contact")
            {
                Id = Guid.NewGuid()
            };
            targetEntity["firstname"] = "DummyFirstName";
            OrganizationService.Create(targetEntity);
            
            SetStateRequest = new SetStateRequest
            {
                EntityMoniker = targetEntity.ToEntityReference(),
                State = new OptionSetValue(1),
                Status = new OptionSetValue(2)
            };
        }
    }
}