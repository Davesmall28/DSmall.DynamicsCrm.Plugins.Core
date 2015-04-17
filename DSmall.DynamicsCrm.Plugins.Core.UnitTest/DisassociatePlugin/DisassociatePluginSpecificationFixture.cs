namespace DSmall.DynamicsCrm.Plugins.Core.UnitTest
{
    using System;
    using DSmall.DynamicsCrm.UnitTest.Core;
    using Microsoft.Xrm.Sdk;

    /// <summary>The disassociate plugin specification fixture.</summary>
    public class DisassociatePluginSpecificationFixture : SpecificationFixture<DummyDisassociatePlugin>
    {
        /// <summary>The perform test setup.</summary>
        public override void PerformTestSetup()
        {
            ServiceProvider = ServiceProviderInitializer.Setup().WithInputParameters(GetDummyInputParameters());
        }

        private ParameterCollection GetDummyInputParameters()
        {
            return new ParameterCollection
            {
                { "Target", new EntityReference("letter", Guid.NewGuid()) },
                { "Relationship", new Relationship() },
                { "RelatedEntities", GetDummyEntityReferenceCollection() }
            };
        }

        private EntityReferenceCollection GetDummyEntityReferenceCollection()
        {
            return new EntityReferenceCollection
            {
                new EntityReference("contact", Guid.NewGuid())
            };
        }
    }
}