namespace Springboard365.Xrm.Plugins.Core.Test
{
    using System;
    using NUnit.Framework;
    using Springboard365.UnitTest.Xrm.Core;

    [TestFixture]
    public class WhenExecutingStandardPluginWithInvalidParameters : Specification<DummyPlugin>
    {
        private bool isExceptionThrown;
        private Exception exceptionThrown;

        protected override void Context()
        {
            TestFixture = new PluginSpecificationFixture();
            TestFixture.PerformTestSetup();
        }

        protected override void BecauseOf()
        {
            try
            {
                TestFixture.UnderTest.Execute(null);
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