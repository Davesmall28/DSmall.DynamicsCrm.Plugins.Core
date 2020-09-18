namespace Springboard365.Xrm.Plugins.Core.Test
{
    using System;
    using Microsoft.Xrm.Sdk;
    using NUnit.Framework;
    using Springboard365.UnitTest.Core;
    using Springboard365.Xrm.Plugins.Core.Constants;
    using Springboard365.Xrm.Plugins.Core.Extensions;
    using Springboard365.Xrm.Plugins.Core.Test.Entities;

    [TestFixture]
    public class InputParameterExtensionSpecifications : SpecificationBase
    {
        private DataCollection<string, object> underTest;
        private EntityReference expected;
        private EntityReference result;

        protected override void Context()
        {
            expected = new EntityReference(Contact.EntityLogicalName, Guid.NewGuid());
            underTest = new ParameterCollection
            {
                { InputParameterType.Target, expected }
            };
        }

        protected override void BecauseOf()
        {
            result = underTest.GetParameter<EntityReference>(InputParameterType.Target);
        }

        [Test]
        public void ShouldReturnValidParameter()
        {
            Assert.IsNotNull(result);
        }

        [Test]
        public void ShouldReturnValidId()
        {
            Assert.AreEqual(expected.Id, result.Id);
        }
    }
}