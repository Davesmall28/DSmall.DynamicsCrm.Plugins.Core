namespace DSmall.DynamicsCrm.Plugins.Core.IntegrationTest
{
    using System;
    using DSmall.UnitTest.Core;
    using NUnit.Framework;

    /// <summary>The create contact specification.</summary>
    [TestFixture]
    public class CreateContactSpecification : SpecificationBase
    {
        private CreateContactSpecificationFixture testFixture;

        private Guid result;

        /// <summary>The should return a non empty id.</summary>
        [Test]
        public void ShouldReturnANonEmptyId()
        {
            Assert.AreNotEqual(Guid.Empty, result);
        }

        /// <summary>The because of.</summary>
        protected override void BecauseOf()
        {
            base.BecauseOf();

            result = testFixture.CrmHelper.CreateContact(testFixture.EntityToCreate);
        }

        /// <summary>The context.</summary>
        protected override void Context()
        {
            base.Context();

            testFixture = new CreateContactSpecificationFixture();
            testFixture.PerformTestSetup();
        }

        /// <summary>The clean up.</summary>
        protected override void Cleanup()
        {
            testFixture.CleanUp.DeleteEntity("contact", result);
        }
    }
}