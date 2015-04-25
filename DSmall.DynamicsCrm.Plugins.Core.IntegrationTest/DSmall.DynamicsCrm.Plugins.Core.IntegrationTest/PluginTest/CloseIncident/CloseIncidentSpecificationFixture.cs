namespace DSmall.DynamicsCrm.Plugins.Core.IntegrationTest
{
    using System;
    using Microsoft.Crm.Sdk.Messages;
    using Microsoft.Xrm.Sdk;

    /// <summary>The close incident specification fixture.</summary>
    public class CloseIncidentSpecificationFixture : SpecificationFixtureBase
    {
        /// <summary>Gets the close incident request.</summary>
        public CloseIncidentRequest CloseIncidentRequest { get; private set; }

        /// <summary>Gets the message name.</summary>
        public string MessageName { get; private set; }

        /// <summary>The perform test setup.</summary>
        public void PerformTestSetup()
        {
            MessageName = "Close";

            var caseEntity = EntityFactory.CreateCase();

            var caseResolutionEntity = new Entity("incidentresolution")
            {
                Id = Guid.NewGuid()
            };
            caseResolutionEntity["incidentid"] = caseEntity.ToEntityReference();

            CloseIncidentRequest = new CloseIncidentRequest
            {
                IncidentResolution = caseResolutionEntity,
                Status = new OptionSetValue(5),
            };
        }
    }
}