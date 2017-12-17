namespace Springboard365.Xrm.Plugins.Core.IntegrationTest
{
    using Microsoft.Xrm.Sdk;
    using NUnit.Framework;
    using Springboard365.UnitTest.Core;

    [TestFixture]
    public class QualifyLeadSpecification : SpecificationBase
    {
        private QualifyLeadSpecificationFixture testFixture;

        protected override void Context()
        {
            testFixture = new QualifyLeadSpecificationFixture();
            testFixture.PerformTestSetup();
        }

        protected override void BecauseOf()
        {
            testFixture.CrmWriter.Execute(testFixture.RequestId, testFixture.QualifyLeadRequest);

            testFixture.Result = Retry.Do(() => testFixture.EntitySerializer.Deserialize(testFixture.RequestId, testFixture.MessageName));
        }

        [Test]
        public void ShouldReturnInputParameterContainingNineParameters()
        {
            Assert.AreEqual(9, testFixture.Result.InputParameters.Count);
        }

        [Test]
        public void ShouldReturnInputParameterContainingLeadId()
        {
            Assert.IsTrue(testFixture.Result.InputParameters.OneOf<EntityReference>("LeadId"));
        }

        [Test]
        public void ShouldReturnInputParameterContainingCreateAccount()
        {
            Assert.IsTrue(testFixture.Result.InputParameters.OneOf<bool>("CreateAccount"));
        }

        [Test]
        public void ShouldReturnInputParameterContainingCreateContact()
        {
            Assert.IsTrue(testFixture.Result.InputParameters.OneOf<bool>("CreateContact"));
        }

        [Test]
        public void ShouldReturnInputParameterContainingCreateOpportunity()
        {
            Assert.IsTrue(testFixture.Result.InputParameters.OneOf<bool>("CreateOpportunity"));
        }

        [Test]
        public void ShouldReturnInputParameterContainingOpportunityCurrencyId()
        {
            Assert.IsTrue(testFixture.Result.InputParameters.OneOf<EntityReference>("OpportunityCurrencyId"));
        }

        [Test]
        public void ShouldReturnInputParameterContainingOpportunityCustomerId()
        {
            Assert.IsTrue(testFixture.Result.InputParameters.OneOf<EntityReference>("OpportunityCustomerId"));
        }

        [Test]
        public void ShouldReturnInputParameterContainingSourceCampaignId()
        {
            Assert.IsTrue(testFixture.Result.InputParameters.OneOf<EntityReference>("SourceCampaignId"));
        }

        [Test]
        public void ShouldReturnInputParameterContainingStatus()
        {
            Assert.IsTrue(testFixture.Result.InputParameters.OneOf<OptionSetValue>("Status"));
        }

        [Test]
        [Ignore("New in Dynamics 365.")]
        public void ShouldReturnInputParameterContainingProcessInstanceId()
        {
            Assert.IsTrue(testFixture.Result.InputParameters.OneOf<EntityReference>("ProcessInstanceId"));
        }

        [Test]
        public void ShouldReturnNoPreEntityImages()
        {
            Assert.IsTrue(testFixture.Result.PreEntityImages.NoParameters());
        }

        [Test]
        public void ShouldReturnNoPostEntityImages()
        {
            Assert.IsTrue(testFixture.Result.PostEntityImages.NoParameters());
        }
    }
}