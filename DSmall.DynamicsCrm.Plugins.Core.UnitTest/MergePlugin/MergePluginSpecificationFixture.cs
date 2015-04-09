namespace DSmall.DynamicsCrm.Plugins.Core.UnitTest
{
    using System;
    using Microsoft.Xrm.Sdk;

    /// <summary>The merge plugin specification fixture.</summary>
    public class MergePluginSpecificationFixture : SpecificationFixture<DummyMergePlugin>
    {
        /// <summary>The perform test setup.</summary>
        public override void PerformTestSetup()
        {
            var serviceProviderInitializer = new ServiceProviderInitializer();
            ServiceProvider = serviceProviderInitializer.Setup().WithInputParameters(GetDummyEntityCollection());
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
