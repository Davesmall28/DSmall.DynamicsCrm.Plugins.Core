namespace DSmall.DynamicsCrm.Plugins.Core.IntegrationTest
{
    using System;
    using Microsoft.Xrm.Sdk;

    /// <summary>The entity factory.</summary>
    public class EntityFactory
    {
        private readonly IOrganizationService organizationService;

        /// <summary>Initialises a new instance of the <see cref="EntityFactory"/> class.</summary>
        /// <param name="organizationService">The organization service.</param>
        public EntityFactory(IOrganizationService organizationService)
        {
            this.organizationService = organizationService;
        }

        /// <summary>The create contact.</summary>
        /// <returns>The <see cref="Guid"/>.</returns>
        public Entity CreateContact()
        {
            var entity = new Entity("contact")
            {
                Id = Guid.NewGuid()
            };
            entity["firstname"] = "DummyFirstName";

            organizationService.Create(entity);

            return entity;
        }

        /// <summary>The create letter.</summary>
        /// <returns>The <see cref="Entity"/>.</returns>
        public Entity CreateLetter()
        {
            var entity = new Entity("letter")
            {
                Id = Guid.NewGuid()
            };
            entity["subject"] = "DummySubject";

            organizationService.Create(entity);

            return entity;
        }

        /// <summary>The create campaign.</summary>
        /// <returns>The <see cref="Entity"/>.</returns>
        public Entity CreateCampaign()
        {
            var entity = new Entity("campaign")
            {
                Id = Guid.NewGuid()
            };
            entity["name"] = "DummyCampaign";

            organizationService.Create(entity);

            return entity;
        }

        /// <summary>The create campaign activity.</summary>
        /// <param name="campaignReference">The campaign Reference.</param>
        /// <returns>The <see cref="Entity"/>.</returns>
        public Entity CreateCampaignActivity(EntityReference campaignReference)
        {
            var entity = new Entity("campaignactivity")
            {
                Id = Guid.NewGuid()
            };
            entity["subject"] = "DummyCampaignActivity";
            entity["regardingobjectid"] = campaignReference;

            organizationService.Create(entity);

            return entity;
        }

        /// <summary>The create marketing list.</summary>
        /// <returns>The <see cref="Entity"/>.</returns>
        public Entity CreateMarketingList()
        {
            var entity = new Entity("list")
            {
                Id = Guid.NewGuid()
            };
            entity["listname"] = "DummyMarketingList";
            entity["createdfromcode"] = new OptionSetValue(2);

            organizationService.Create(entity);

            return entity;
        }

        /// <summary>The create quote.</summary>
        /// <returns>The <see cref="Entity"/>.</returns>
        public Entity CreateQuote()
        {
            var entity = new Entity("quote")
            {
                Id = Guid.NewGuid()
            };

            organizationService.Create(entity);

            return entity;
        }

        /// <summary>The create opportunity.</summary>
        /// <returns>The <see cref="Entity"/>.</returns>
        public Entity CreateOpportunity()
        {
            var entity = new Entity("opportunity")
            {
                Id = Guid.NewGuid()
            };
            entity["name"] = "DummyOpportunity";

            organizationService.Create(entity);

            return entity;
        }
    }
}
