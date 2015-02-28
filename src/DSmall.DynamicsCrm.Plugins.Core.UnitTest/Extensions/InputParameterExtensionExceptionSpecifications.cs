namespace DSmall.DynamicsCrm.Plugins.Core.UnitTest
{
    using System;
    using DSmall.UnitTest.Core;
    using Microsoft.Xrm.Sdk;
    using NUnit.Framework;

    /// <summary>The input parameter extension exception specifications.</summary>
    [TestFixture]
    public class InputParameterExtensionExceptionSpecifications : SpecificationBase
    {
        private const string ParameterName = "Target";
        private DataCollection<string, object> underTest;
        private bool isExceptionThrown;
        private Exception exceptionThrown;

        /// <summary>The should not swallow exception.</summary>
        [Test]
        public void ShouldNotSwallowException()
        {
            Assert.IsTrue(isExceptionThrown);
        }

        /// <summary>The should return correct error message.</summary>
        [Test]
        public void ShouldReturnCorrectErrorMessage()
        {
            var exceptionMessage = string.Format("Cannot find parameter name '{0}' in input parameter collection.", ParameterName);
            Assert.AreEqual(exceptionMessage, exceptionThrown.Message);
        }

        /// <summary>The should return argument exception.</summary>
        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void ShouldReturnArgumentException()
        {
            throw exceptionThrown;
        }

        /// <summary>The because of.</summary>
        protected override void BecauseOf()
        {
            base.BecauseOf();

            try
            {
                underTest.GetParameter<EntityReference>(ParameterName);
            }
            catch (Exception exception)
            {
                isExceptionThrown = true;
                exceptionThrown = exception;
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