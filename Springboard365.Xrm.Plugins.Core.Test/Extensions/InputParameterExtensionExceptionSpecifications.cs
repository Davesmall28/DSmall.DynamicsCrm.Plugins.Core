namespace Springboard365.Xrm.Plugins.Core.Test
{
    using Microsoft.Xrm.Sdk;
    using NUnit.Framework;
    using Springboard365.UnitTest.Core;
    using Springboard365.Xrm.Plugins.Core.Constants;
    using Springboard365.Xrm.Plugins.Core.Extensions;

    [TestFixture]
    public class InputParameterExtensionExceptionSpecifications : SpecificationBase
    {
        private const string ParameterName = InputParameterType.Target;
        private DataCollection<string, object> underTest;
        private EntityReference result;
        private bool isExceptionThrown;

        protected override void Context()
        {
            underTest = new ParameterCollection();
        }

        protected override void BecauseOf()
        {
            try
            {
                result = underTest.GetParameter<EntityReference>(ParameterName);
            }
            catch
            {
                isExceptionThrown = true;
            }
        }

        [Test]
        public void ShouldNotRaiseException()
        {
            Assert.IsFalse(isExceptionThrown);
        }

        [Test]
        public void ShouldReturnDefaultValue()
        {
            Assert.AreEqual(default(EntityReference), result);
        }
    }
}