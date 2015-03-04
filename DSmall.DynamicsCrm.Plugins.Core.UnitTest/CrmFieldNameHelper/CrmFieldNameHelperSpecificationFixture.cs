namespace DSmall.DynamicsCrm.Plugins.Core.UnitTest
{
    using DSmall.Core;
    using Microsoft.Xrm.Sdk;
    using Moq;

    /// <summary>The crm field name helper specification fixture.</summary>
    public class CrmFieldNameHelperSpecificationFixture
    {
        /// <summary>Gets or sets the under test.</summary>
        public CrmFieldNameHelper UnderTest { get; set; }

        /// <summary>Gets or sets the attribute utilities.</summary>
        public Mock<IAttributeUtilities> AttributeUtilities { get; set; }

        /// <summary>The perform test setup.</summary>
        public void PerformTestSetup()
        {
            SetupAttributeUtilities();
            UnderTest = new CrmFieldNameHelper(AttributeUtilities.Object);
        }

        private void SetupAttributeUtilities()
        {
            AttributeUtilities = new Mock<IAttributeUtilities>();
            AttributeUtilities
                .Setup(utilities => utilities.GetAttributeFor<AttributeLogicalNameAttribute, DummyEntity>(type => type.CustomerReference))
                .Returns(new AttributeLogicalNameAttribute("customerreference"));
        }
    }
}
