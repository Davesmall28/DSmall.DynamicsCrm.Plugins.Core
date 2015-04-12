namespace DSmall.DynamicsCrm.Plugins.Core.UnitTest
{
    using System;
    using Microsoft.Xrm.Sdk;

    /// <summary>The associate specification fixture.</summary>
    public class AssociateSpecificationFixture : SpecificationFixture<DummyAssociatePlugin>
    {
        /// <summary>The perform test setup.</summary>
        public override void PerformTestSetup()
        {
            ServiceProvider = new ServiceProviderInitializer().Setup().WithInputParameters(GetDummyInputParameters());
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