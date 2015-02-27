namespace DSmall.DynamicsCrm.Plugins.Core.UnitTest
{
    using DSmall.UnitTest.Core;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>The when executing merge plugin with valid parameters.</summary>
    [TestClass]
    public class WhenExecutingMergePluginWithValidParameters : SpecificationBase
    {
        private MergePluginTestFixture testFixture;

        /// <summary>The organization service should not be null.</summary>
        [TestMethod]
        public void OrganizationServiceShouldNotBeNull()
        {
            Assert.IsNotNull(testFixture.UnderTest.OrganizationService);
        }

        /// <summary>The plugin execution context should not be null.</summary>
        [TestMethod]
        public void PluginExecutionContextShouldNotBeNull()
        {
            Assert.IsNotNull(testFixture.UnderTest.PluginExecutionContext);
        }

        /// <summary>The tracing service should not be null.</summary>
        [TestMethod]
        public void TracingServiceShouldNotBeNull()
        {
            Assert.IsNotNull(testFixture.UnderTest.TracingService);
        }

        /// <summary>The target entity should not be null.</summary>
        [TestMethod]
        public void TargetEntityShouldNotBeNull()
        {
            Assert.IsNotNull(testFixture.UnderTest.TargetEntity);
        }

        /// <summary>The subordinated id should not be null.</summary>
        [TestMethod]
        public void SubordinatedIdShouldNotBeNull()
        {
            Assert.IsNotNull(testFixture.UnderTest.SubordinateId);
        }

        /// <summary>The update content should not be null.</summary>
        [TestMethod]
        public void UpdateContentShouldNotBeNull()
        {
            Assert.IsNotNull(testFixture.UnderTest.UpdateContent);
        }

        /// <summary>The because of.</summary>
        protected override void BecauseOf()
        {
            base.BecauseOf();

            testFixture.UnderTest.Execute(testFixture.ServiceProvider.Object);
        }

        /// <summary>The context.</summary>
        protected override void Context()
        {
            base.Context();

            testFixture = new MergePluginTestFixture();
            testFixture.PerformTestSetup();
        }
    }
}
