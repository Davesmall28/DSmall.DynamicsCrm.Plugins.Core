namespace Springboard365.Xrm.Plugins.Core.Test
{
    using System;
    using NUnit.Framework;
    using Springboard365.UnitTest.Core;
    using Springboard365.Xrm.UnitTest.Core;

    [TestFixture]
    public class WhenExecutingStandardPluginWithInvalidParameters : SpecificationBase
    {
        private SpecificationFixture<DummyPlugin> testFixture;
        private bool isExceptionThrown;
        private Exception exceptionThrown;

        protected override void Context()
        {
            testFixture = new SpecificationFixture<DummyPlugin>();
            testFixture.PerformTestSetup();
        }

        protected override void BecauseOf()
        {
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

        [Test]
        public void ExceptionShouldNotBeSwallowed()
        {
            Assert.IsTrue(isExceptionThrown);
        }

        [Test]
        public void ArgumentNullExceptionShouldBeThrown()
        {
            Assert.Throws<ArgumentNullException>(ThrowException);
        }

        private void ThrowException()
        {
            throw exceptionThrown;
        }
    }
}