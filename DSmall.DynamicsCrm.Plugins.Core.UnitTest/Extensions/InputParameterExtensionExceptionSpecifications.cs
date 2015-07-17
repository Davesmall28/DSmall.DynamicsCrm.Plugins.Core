namespace DSmall.DynamicsCrm.Plugins.Core.UnitTest
{
    using DSmall.UnitTest.Core;
    using Microsoft.Xrm.Sdk;
    using NUnit.Framework;

    /// <summary>The input parameter extension exception specifications.</summary>
    [TestFixture]
    public class InputParameterExtensionExceptionSpecifications : SpecificationBase
    {
        private const string ParameterName = "Target";
        private DataCollection<string, object> underTest;
        private EntityReference result;
        private bool isExceptionThrown;

        /// <summary>The should not raise exception.</summary>
        [Test]
        public void ShouldNotRaiseException()
        {
            Assert.IsFalse(isExceptionThrown);
        }

        /// <summary>The should return correct error message.</summary>
        [Test]
        public void ShouldReturnDefaultValue()
        {
            Assert.AreEqual(default(EntityReference), result);
        }

        /// <summary>The because of.</summary>
        protected override void BecauseOf()
        {
            base.BecauseOf();

            try
            {
                result = underTest.GetParameter<EntityReference>(ParameterName);
            }
            catch
            {
                isExceptionThrown = true;
            }
        }

        /// <summary>The context.</summary>
        protected override void Context()
        {
            base.Context();
            underTest = new ParameterCollection();
        }
    }
}