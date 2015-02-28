namespace DSmall.DynamicsCrm.Plugins.Core.UnitTest
{
    using System;
    using DSmall.UnitTest.Core;
    using Microsoft.Xrm.Sdk;
    using NUnit.Framework;

    /// <summary>The input parameter extension specifications.</summary>
    [TestFixture]
    public class InputParameterExtensionSpecifications : SpecificationBase
    {
        private DataCollection<string, object> underTest;
        private EntityReference expected;
        private EntityReference result;

        /// <summary>The should return valid parameter.</summary>
        [Test]
        public void ShouldReturnValidParameter()
        {
            Assert.IsNotNull(result);
        }

        /// <summary>The should return valid id.</summary>
        [Test]
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