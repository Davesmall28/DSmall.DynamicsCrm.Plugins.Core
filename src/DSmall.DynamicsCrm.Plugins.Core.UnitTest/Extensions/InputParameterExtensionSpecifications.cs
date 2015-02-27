namespace DSmall.DynamicsCrm.Plugins.Core.UnitTest
{
    using System;
    using DSmall.UnitTest.Core;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Microsoft.Xrm.Sdk;

    /// <summary>The input parameter extension specifications.</summary>
    [TestClass]
    public class InputParameterExtensionSpecifications : SpecificationBase
    {
        private DataCollection<string, object> underTest;
        private EntityReference expected;
        private EntityReference result;

        /// <summary>The should return valid parameter.</summary>
        [TestMethod]
        public void ShouldReturnValidParameter()
        {
            Assert.IsNotNull(result);
        }

        /// <summary>The should return valid id.</summary>
        [TestMethod]
        public void ShouldReturnValidId()
        {
            Assert.AreEqual(expected.Id, result.Id);
        }

        /// <summary>The because of.</summary>
        protected override void BecauseOf()
        {
            base.BecauseOf();

            result = underTest.GetParameter<EntityReference>("Target");
        }

        /// <summary>The context.</summary>
        protected override void Context()
        {
            base.Context();

            expected = new EntityReference("contact", Guid.NewGuid());
            underTest = new ParameterCollection
            {
                { "Target", expected }
            };
        }
    }
}