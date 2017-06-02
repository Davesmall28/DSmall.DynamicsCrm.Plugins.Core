namespace Springboard365.Xrm.Plugins.Core.Test
{
    using NUnit.Framework;
    using Springboard365.Xrm.UnitTest.Core;

    public class WhenExecutingCloneContractPluginSuccessfully : Specification<DummyCloneContractPlugin>
    {
        protected override void Context()
        {
            TestFixture = new CloneContractPluginSpecificationFixture();
            TestFixture.PerformTestSetup();
        }

        protected override void BecauseOf()
        {
            TestFixture.UnderTest.Execute(TestFixture.ServiceProvider.Object);
        }

        [Test]
        public void OrganizationServiceShouldNotBeNull()
        {
            Assert.IsNotNull(TestFixture.UnderTest.OrganizationService);
        }

        [Test]
        public void PluginExecutionContextShouldNotBeNull()
        {
            Assert.IsNotNull(TestFixture.UnderTest.PluginExecutionContext);
        }

        [Test]
        public void TracingServiceShouldNotBeNull()
        {
            Assert.IsNotNull(TestFixture.UnderTest.TracingService);
        }

        [Test]
        public void ContractIdShouldNotBeNull()
        {
            Assert.IsNotNull(TestFixture.UnderTest.ContractId);
        }

        [Test]
        public void IncludeCanceledLinesShouldNotBeNull()
        {
            Assert.IsNotNull(TestFixture.UnderTest.IncludeCanceledLines);
        }
    }
}