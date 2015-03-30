namespace DSmall.DynamicsCrm.Plugins.Core.IntegrationTest
{
    using Microsoft.Xrm.Client.Services;
    using Microsoft.Xrm.Sdk;
    using NUnit.Framework;

    /// <summary>The crm integration specification base.</summary>
    public abstract class CrmIntegrationSpecificationBase
    {
        /// <summary>Gets or sets the test context.</summary>
        public TestContext TestContext { get; set; }

        /// <summary>Gets or sets the organization service.</summary>
        public IOrganizationService OrganizationService { get; set; }

        /// <summary>The test initialize.</summary>
        [SetUp]
        public void TestInitialize()
        {
            OrganizationService = new OrganizationService("CrmConnection");

            Context();

            BecauseOf();
        }

        /// <summary>The test clean up.</summary>
        [TearDown]
        public void TestCleanup()
        {
            Cleanup();
        }

        /// <summary>The context.</summary>
        protected virtual void Context()
        {
        }

        /// <summary>The because of.</summary>
        protected virtual void BecauseOf()
        {
        }

        /// <summary>The clean up.</summary>
        protected virtual void Cleanup()
        {
        }
    }
}
