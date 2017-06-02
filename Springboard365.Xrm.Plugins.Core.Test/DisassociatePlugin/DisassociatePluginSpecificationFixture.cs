﻿namespace Springboard365.Xrm.Plugins.Core.Test
{
    using System;
    using Microsoft.Xrm.Sdk;
    using Springboard365.Xrm.UnitTest.Core;

    public class DisassociatePluginSpecificationFixture : SpecificationFixture<DummyDisassociatePlugin>
    {
        public override void PerformTestSetup()
        {
            ServiceProvider = ServiceProviderInitializer.Setup().WithInputParameters(() => new ParameterCollection
            {
                { InputParameterType.Target, new EntityReference("letter", Guid.NewGuid()) },
                { InputParameterType.Relationship, new Relationship() },
                { InputParameterType.RelatedEntities, GetDummyEntityReferenceCollection() }
            });
        }

        private static EntityReferenceCollection GetDummyEntityReferenceCollection()
        {
            return new EntityReferenceCollection
            {
                new EntityReference("contact", Guid.NewGuid())
            };
        }
    }
}