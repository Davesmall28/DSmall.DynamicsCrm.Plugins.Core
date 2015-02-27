namespace DSmall.DynamicsCrm.Plugins.Core.UnitTest
{
    using DSmall.UnitTest.Core;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>The entity plugin tests.</summary>
    public class EntityPluginTests
    {
        /// <summary>The when executing with valid parameters.</summary>
        [TestClass]
        public class WhenExecutingWithValidParameters : SpecificationBase
        {
            private EntityPluginTestFixture testFixture;

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

                testFixture = new EntityPluginTestFixture();
                testFixture.PerformTestSetup();
            }
        }
    }
}