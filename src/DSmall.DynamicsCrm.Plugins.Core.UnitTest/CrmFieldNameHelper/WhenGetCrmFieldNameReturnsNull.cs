﻿namespace DSmall.DynamicsCrm.Plugins.Core.UnitTest
{
    using System;
    using System.IO;
    using DSmall.UnitTest.Core;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>The when get crm field name returns null.</summary>
    [TestClass]
    public class WhenGetCrmFieldNameReturnsNull : SpecificationBase
    {
        private CrmFieldNameHelperSpecificationFixture testFixture;
        private bool isExceptionThrown;
        private Exception exceptionThrown;

        /// <summary>The should not swallow exceptions.</summary>
        [TestMethod]
        public void ShouldNotSwallowExceptions()
        {
            Assert.IsTrue(isExceptionThrown);
        }

        /// <summary>The should throw invalid data exception.</summary>
        /// <exception cref="Exception">Invalid data exception</exception>
        [TestMethod]
        [ExpectedException(typeof(InvalidDataException))]
        public void ShouldThrowInvalidDataException()
        {
            throw exceptionThrown;
        }

        /// <summary>The because of.</summary>
        protected override void BecauseOf()
        {
            base.BecauseOf();

            try
            {
                testFixture.UnderTest.GetCrmFieldName<DummyEntity>(entity => entity.FirstName);
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

            testFixture = new CrmFieldNameHelperSpecificationFixture();
            testFixture.PerformTestSetup();
        }
    }
}
