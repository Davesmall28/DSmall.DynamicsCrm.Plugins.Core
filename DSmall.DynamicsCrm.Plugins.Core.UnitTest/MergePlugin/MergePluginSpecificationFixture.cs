namespace DSmall.DynamicsCrm.Plugins.Core.UnitTest
{
    using System;
    using DSmall.DynamicsCrm.UnitTest.Core;
    using Microsoft.Xrm.Sdk;

    /// <summary>The merge plugin specification fixture.</summary>
    public class MergePluginSpecificationFixture : SpecificationFixture<DummyMergePlugin>
    {
        /// <summary>The perform test setup.</summary>
        public override void PerformTestSetup()
        {
            ServiceProvider = ServiceProviderInitializer.Setup().WithInputParameters(GetDummyEntityCollection());
        }

        private static ParameterCollection GetDummyEntityCollection()
        {
            return new ParameterCollection
            {
                { "Target", new EntityReference("contact", Guid.NewGuid()) },
                { "SubordinateId", Guid.NewGuid() },
                { "UpdateContent", new Entity("contact") { Id = Guid.NewGuid() } }
            };
        }
    }
}
