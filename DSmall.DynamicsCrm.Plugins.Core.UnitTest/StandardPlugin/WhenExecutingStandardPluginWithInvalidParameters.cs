namespace DSmall.DynamicsCrm.Plugins.Core.UnitTest
{
    using System;
    using DSmall.DynamicsCrm.UnitTest.Core;
    using DSmall.UnitTest.Core;
    using NUnit.Framework;

    /// <summary>The when executing standard plugin with invalid parameters.</summary>
    [TestFixture]
    public class WhenExecutingStandardPluginWithInvalidParameters : SpecificationBase
    {
        private SpecificationFixture<DummyPlugin> testFixture;
        private bool isExceptionThrown;
        private Exception exceptionThrown;

        /// <summary>The exception should not be swallowed.</summary>
        [Test]
        public void ExceptionShouldNotBeSwallowed()
        {
            Assert.IsTrue(isExceptionThrown);
        }

        /// <summary>The argument null exception should be thrown.</summary>
        /// <exception cref="Exception">Argument Null Exception</exception>
        [Test]
        public void ArgumentNullExceptionShouldBeThrown()
        {
            Assert.Throws<ArgumentNullException>(ThrowException);
        }

        /// <summary>The because of.</summary>
        protected override void BecauseOf()
        {
            base.BecauseOf();

            try
            {
                testFixture.UnderTest.Execute(null);
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

            testFixture = new SpecificationFixture<DummyPlugin>();
            testFixture.PerformTestSetup();
        }

        private void ThrowException()
        {
            throw exceptionThrown;
        }
    }
}
