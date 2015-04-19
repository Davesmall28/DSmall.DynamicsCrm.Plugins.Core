﻿namespace DSmall.DynamicsCrm.Plugins.Core.IntegrationTest
{
    using Microsoft.Xrm.Sdk;

    /// <summary>The create contact specification fixture.</summary>
    public class CreateContactSpecificationFixture : SpecificationFixtureBase
    {
        /// <summary>Gets the entity to create.</summary>
        public Entity EntityToCreate { get; private set; }

        /// <summary>Gets the message name.</summary>
        public string MessageName { get; private set; }

        /// <summary>The perform test setup.</summary>
        public void PerformTestSetup()
        {
            MessageName = "Create";

            EntityToCreate = new Entity("contact");
            EntityToCreate.Attributes.Add("firstname", "DummFirstName");
        }
    }
}