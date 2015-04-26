namespace DSmall.DynamicsCrm.Plugins.Core.IntegrationTest
{
    using DSmall.UnitTest.Core;
    using Microsoft.Xrm.Sdk;
    using NUnit.Framework;

    /// <summary>The qualify lead specification.</summary>
    [TestFixture]
    public class QualifyLeadSpecification : SpecificationBase
    {
        private QualifyLeadSpecificationFixture testFixture;

        /// <summary>The should return input parameter containing eight parameters.</summary>
        [Test]
        public void ShouldReturnInputParameterContainingEightParameters()
        {
            Assert.IsTrue(testFixture.Result.InputParameters.Count == 8);
        }

        /// <summary>The should return input parameter containing lead id.</summary>
        [Test]
        public void ShouldReturnInputParameterContainingLeadId()
        {
            Assert.IsTrue(testFixture.Result.InputParameters.Count("LeadId", typeof(EntityReference)) == 1);
        }

        /// <summary>The should return input parameter containing create account.</summary>
        [Test]
        public void ShouldReturnInputParameterContainingCreateAccount()
        {
            Assert.IsTrue(testFixture.Result.InputParameters.Count("CreateAccount", typeof(bool)) == 1);
        }

        /// <summary>The should return input parameter containing create contact.</summary>
        [Test]
        public void ShouldReturnInputParameterContainingCreateContact()
        {
            Assert.IsTrue(testFixture.Result.InputParameters.Count("CreateContact", typeof(bool)) == 1);
        }

        /// <summary>The should return input parameter containing create opportunity.</summary>
        [Test]
        public void ShouldReturnInputParameterContainingCreateOpportunity()
        {
            Assert.IsTrue(testFixture.Result.InputParameters.Count("CreateOpportunity", typeof(bool)) == 1);
        }

        /// <summary>The should return input parameter containing opportunity currency id.</summary>
        [Test]
        public void ShouldReturnInputParameterContainingOpportunityCurrencyId()
        {
            Assert.IsTrue(testFixture.Result.InputParameters.Count("OpportunityCurrencyId", typeof(EntityReference)) == 1);
        }

        /// <summary>The should return input parameter containing opportunity customer id.</summary>
        [Test]
        public void ShouldReturnInputParameterContainingOpportunityCustomerId()
        {
            Assert.IsTrue(testFixture.Result.InputParameters.Count("OpportunityCustomerId", typeof(EntityReference)) == 1);
        }

        /// <summary>The should return input parameter containing source campaign id.</summary>
        [Test]
        public void ShouldReturnInputParameterContainingSourceCampaignId()
        {
            Assert.IsTrue(testFixture.Result.InputParameters.Count("SourceCampaignId", typeof(EntityReference)) == 1);
        }

        /// <summary>The should return input parameter containing status.</summary>
        [Test]
        public void ShouldReturnInputParameterContainingStatus()
        {
            Assert.IsTrue(testFixture.Result.InputParameters.Count("Status", typeof(OptionSetValue)) == 1);
        }

        /// <summary>The should return no pre entity images.</summary>
        [Test]
        public void ShouldReturnNoPreEntityImages()
        {
            Assert.IsTrue(testFixture.Result.PreEntityImages.Count == 0);
        }

        /// <summary>The should return no post entity images.</summary>
        [Test]
        public void ShouldReturnNoPostEntityImages()
        {
            Assert.IsTrue(testFixture.Result.PostEntityImages.Count == 0);
        }

        /// <summary>The because of.</summary>
        protected override void BecauseOf()
        {
            testFixture.CrmWriter.Execute(testFixture.RequestId, testFixture.QualifyLeadRequest);

            testFixture.Result = Retry.Do(() => testFixture.EntitySerializer.Deserialize(testFixture.RequestId, testFixture.MessageName));
        }

        /// <summary>The context.</summary>
        protected override void Context()
        {
            testFixture = new QualifyLeadSpecificationFixture();
            testFixture.PerformTestSetup();
        }
    }
}