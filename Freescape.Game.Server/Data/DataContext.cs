using System;
using System.Data.Entity;
using Freescape.Game.Server.Data.Entities;
using Attribute = Freescape.Game.Server.Data.Entities.Attribute;

namespace Freescape.Game.Server.Data
{
    public partial class DataContext : DbContext
    {
        public DataContext()
            : base(BuildConnectionString())
        {
        }

        private static string BuildConnectionString()
        {
            var ipAddress = Environment.GetEnvironmentVariable("SQL_SERVER_IP_ADDRESS");
            var username = Environment.GetEnvironmentVariable("SQL_SERVER_USERNAME");
            var password = Environment.GetEnvironmentVariable("SQL_SERVER_PASSWORD");
            var database = Environment.GetEnvironmentVariable("SQL_SERVER_DATABASE");

            return $"server={ipAddress};database={database};user id={username};password={password};Integrated Security=False;MultipleActiveResultSets=True;TrustServerCertificate=True;Encrypt=False";
        }

        public virtual DbSet<Attribute> Attributes { get; set; }
        public virtual DbSet<AuthorizedDM> AuthorizedDMs { get; set; }
        public virtual DbSet<BaseItemType> BaseItemTypes { get; set; }
        public virtual DbSet<BuildPrivacyDomain> BuildPrivacyDomains { get; set; }
        public virtual DbSet<ChatChannelsDomain> ChatChannelsDomains { get; set; }
        public virtual DbSet<ChatLog> ChatLogs { get; set; }
        public virtual DbSet<ClientLogEvent> ClientLogEvents { get; set; }
        public virtual DbSet<ClientLogEventTypesDomain> ClientLogEventTypesDomains { get; set; }
        public virtual DbSet<ConstructionSiteComponent> ConstructionSiteComponents { get; set; }
        public virtual DbSet<ConstructionSite> ConstructionSites { get; set; }
        public virtual DbSet<CooldownCategory> CooldownCategories { get; set; }
        public virtual DbSet<CraftBlueprintCategory> CraftBlueprintCategories { get; set; }
        public virtual DbSet<CraftBlueprintComponent> CraftBlueprintComponents { get; set; }
        public virtual DbSet<CraftBlueprint> CraftBlueprints { get; set; }
        public virtual DbSet<CraftDevice> CraftDevices { get; set; }
        public virtual DbSet<CustomEffect> CustomEffects { get; set; }
        public virtual DbSet<DMRoleDomain> DMRoleDomains { get; set; }
        public virtual DbSet<Download> Downloads { get; set; }
        public virtual DbSet<FameRegion> FameRegions { get; set; }
        public virtual DbSet<GameTopicCategory> GameTopicCategories { get; set; }
        public virtual DbSet<GameTopic> GameTopics { get; set; }
        public virtual DbSet<GrowingPlant> GrowingPlants { get; set; }
        public virtual DbSet<Item> Items { get; set; }
        public virtual DbSet<ItemType> ItemTypes { get; set; }
        public virtual DbSet<KeyItemCategory> KeyItemCategories { get; set; }
        public virtual DbSet<KeyItem> KeyItems { get; set; }
        public virtual DbSet<LootTableItem> LootTableItems { get; set; }
        public virtual DbSet<LootTable> LootTables { get; set; }
        public virtual DbSet<NPCGroup> NPCGroups { get; set; }
        public virtual DbSet<PCCooldown> PCCooldowns { get; set; }
        public virtual DbSet<PCCorpseItem> PCCorpseItems { get; set; }
        public virtual DbSet<PCCorps> PCCorpses { get; set; }
        public virtual DbSet<PCCustomEffect> PCCustomEffects { get; set; }
        public virtual DbSet<PCKeyItem> PCKeyItems { get; set; }
        public virtual DbSet<PCMapPin> PCMapPins { get; set; }
        public virtual DbSet<PCMigrationItem> PCMigrationItems { get; set; }
        public virtual DbSet<PCMigration> PCMigrations { get; set; }
        public virtual DbSet<PCOutfit> PCOutfits { get; set; }
        public virtual DbSet<PCOverflowItem> PCOverflowItems { get; set; }
        public virtual DbSet<PCPerk> PCPerks { get; set; }
        public virtual DbSet<PCQuestKillTargetProgress> PCQuestKillTargetProgresses { get; set; }
        public virtual DbSet<PCQuestStatu> PCQuestStatus { get; set; }
        public virtual DbSet<PCRegionalFame> PCRegionalFames { get; set; }
        public virtual DbSet<PCSearchSiteItem> PCSearchSiteItems { get; set; }
        public virtual DbSet<PCSearchSite> PCSearchSites { get; set; }
        public virtual DbSet<PCSkill> PCSkills { get; set; }
        public virtual DbSet<PCTerritoryFlag> PCTerritoryFlags { get; set; }
        public virtual DbSet<PCTerritoryFlagsPermission> PCTerritoryFlagsPermissions { get; set; }
        public virtual DbSet<PCTerritoryFlagsStructure> PCTerritoryFlagsStructures { get; set; }
        public virtual DbSet<PCTerritoryFlagsStructuresItem> PCTerritoryFlagsStructuresItems { get; set; }
        public virtual DbSet<PerkCategory> PerkCategories { get; set; }
        public virtual DbSet<PerkExecutionType> PerkExecutionTypes { get; set; }
        public virtual DbSet<PerkLevel> PerkLevels { get; set; }
        public virtual DbSet<PerkLevelSkillRequirement> PerkLevelSkillRequirements { get; set; }
        public virtual DbSet<Perk> Perks { get; set; }
        public virtual DbSet<Plant> Plants { get; set; }
        public virtual DbSet<PlayerCharacter> PlayerCharacters { get; set; }
        public virtual DbSet<QuestKillTargetList> QuestKillTargetLists { get; set; }
        public virtual DbSet<QuestPrerequisite> QuestPrerequisites { get; set; }
        public virtual DbSet<QuestRequiredItemList> QuestRequiredItemLists { get; set; }
        public virtual DbSet<QuestRequiredKeyItemList> QuestRequiredKeyItemLists { get; set; }
        public virtual DbSet<QuestRewardItem> QuestRewardItems { get; set; }
        public virtual DbSet<Quest> Quests { get; set; }
        public virtual DbSet<QuestState> QuestStates { get; set; }
        public virtual DbSet<QuestTypeDomain> QuestTypeDomains { get; set; }
        public virtual DbSet<ServerConfiguration> ServerConfigurations { get; set; }
        public virtual DbSet<SkillCategory> SkillCategories { get; set; }
        public virtual DbSet<Skill> Skills { get; set; }
        public virtual DbSet<SkillXPRequirement> SkillXPRequirements { get; set; }
        public virtual DbSet<StorageContainer> StorageContainers { get; set; }
        public virtual DbSet<StorageItem> StorageItems { get; set; }
        public virtual DbSet<StructureBlueprint> StructureBlueprints { get; set; }
        public virtual DbSet<StructureCategory> StructureCategories { get; set; }
        public virtual DbSet<StructureComponent> StructureComponents { get; set; }
        public virtual DbSet<StructureQuickBuildAudit> StructureQuickBuildAudits { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<TerritoryFlagPermission> TerritoryFlagPermissions { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Attribute>()
                .HasMany(e => e.Skills)
                .WithRequired(e => e.Attribute)
                .HasForeignKey(e => e.Primary)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Attribute>()
                .HasMany(e => e.Skills1)
                .WithRequired(e => e.Attribute1)
                .HasForeignKey(e => e.Secondary)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Attribute>()
                .HasMany(e => e.Skills2)
                .WithRequired(e => e.Attribute2)
                .HasForeignKey(e => e.Tertiary)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<BaseItemType>()
                .HasMany(e => e.PCMigrationItems)
                .WithRequired(e => e.BaseItemType)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<BuildPrivacyDomain>()
                .HasMany(e => e.PCTerritoryFlags)
                .WithRequired(e => e.BuildPrivacyDomain)
                .HasForeignKey(e => e.BuildPrivacySettingID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ChatChannelsDomain>()
                .HasMany(e => e.ChatLogs)
                .WithRequired(e => e.ChatChannelsDomain)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ClientLogEventTypesDomain>()
                .HasMany(e => e.ClientLogEvents)
                .WithRequired(e => e.ClientLogEventTypesDomain)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ConstructionSite>()
                .HasMany(e => e.ConstructionSiteComponents)
                .WithRequired(e => e.ConstructionSite)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CooldownCategory>()
                .HasMany(e => e.PCCooldowns)
                .WithRequired(e => e.CooldownCategory)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CraftBlueprintCategory>()
                .HasMany(e => e.CraftBlueprints)
                .WithRequired(e => e.CraftBlueprintCategory)
                .HasForeignKey(e => e.CraftCategoryID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CraftBlueprint>()
                .HasMany(e => e.CraftBlueprintComponents)
                .WithRequired(e => e.CraftBlueprint)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CraftDevice>()
                .HasMany(e => e.CraftBlueprints)
                .WithRequired(e => e.CraftDevice)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CustomEffect>()
                .HasMany(e => e.PCCustomEffects)
                .WithRequired(e => e.CustomEffect)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DMRoleDomain>()
                .HasMany(e => e.Users)
                .WithRequired(e => e.DMRoleDomain)
                .HasForeignKey(e => e.RoleID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<FameRegion>()
                .HasMany(e => e.PCRegionalFames)
                .WithRequired(e => e.FameRegion)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<FameRegion>()
                .HasMany(e => e.Quests)
                .WithRequired(e => e.FameRegion)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<GameTopicCategory>()
                .HasMany(e => e.GameTopics)
                .WithRequired(e => e.GameTopicCategory)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ItemType>()
                .HasMany(e => e.Items)
                .WithRequired(e => e.ItemType)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<KeyItemCategory>()
                .HasMany(e => e.KeyItems)
                .WithRequired(e => e.KeyItemCategory)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<KeyItem>()
                .HasMany(e => e.PCKeyItems)
                .WithRequired(e => e.KeyItem)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<KeyItem>()
                .HasMany(e => e.QuestRequiredKeyItemLists)
                .WithRequired(e => e.KeyItem)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<KeyItem>()
                .HasMany(e => e.Quests)
                .WithOptional(e => e.KeyItem)
                .HasForeignKey(e => e.RewardKeyItemID);

            modelBuilder.Entity<KeyItem>()
                .HasMany(e => e.Quests1)
                .WithOptional(e => e.KeyItem1)
                .HasForeignKey(e => e.StartKeyItemID);

            modelBuilder.Entity<LootTableItem>()
                .Property(e => e.Resref)
                .IsUnicode(false);

            modelBuilder.Entity<LootTable>()
                .HasMany(e => e.LootTableItems)
                .WithRequired(e => e.LootTable)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NPCGroup>()
                .HasMany(e => e.PCQuestKillTargetProgresses)
                .WithRequired(e => e.NPCGroup)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NPCGroup>()
                .HasMany(e => e.QuestKillTargetLists)
                .WithRequired(e => e.NPCGroup)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PCCorps>()
                .HasMany(e => e.PCCorpseItems)
                .WithRequired(e => e.PCCorps)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PCKeyItem>()
                .Property(e => e.AcquiredDate)
                .HasPrecision(0);

            modelBuilder.Entity<PCMigration>()
                .HasMany(e => e.PCMigrationItems)
                .WithRequired(e => e.PCMigration)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PCQuestStatu>()
                .HasMany(e => e.PCQuestKillTargetProgresses)
                .WithRequired(e => e.PCQuestStatu)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PCTerritoryFlag>()
                .HasMany(e => e.PCTerritoryFlagsPermissions)
                .WithRequired(e => e.PCTerritoryFlag)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PCTerritoryFlag>()
                .HasMany(e => e.PCTerritoryFlagsStructures)
                .WithRequired(e => e.PCTerritoryFlag)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PCTerritoryFlagsStructure>()
                .Property(e => e.CreateDate)
                .HasPrecision(0);

            modelBuilder.Entity<PCTerritoryFlagsStructure>()
                .HasMany(e => e.PCTerritoryFlagsStructuresItems)
                .WithRequired(e => e.PCTerritoryFlagsStructure)
                .HasForeignKey(e => e.PCStructureID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PerkCategory>()
                .HasMany(e => e.Perks)
                .WithRequired(e => e.PerkCategory)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PerkExecutionType>()
                .HasMany(e => e.Perks)
                .WithRequired(e => e.PerkExecutionType)
                .HasForeignKey(e => e.ExecutionTypeID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PerkLevel>()
                .HasMany(e => e.PerkLevelSkillRequirements)
                .WithRequired(e => e.PerkLevel)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Perk>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Perk>()
                .Property(e => e.JavaScriptName)
                .IsUnicode(false);

            modelBuilder.Entity<Perk>()
                .HasMany(e => e.PCPerks)
                .WithRequired(e => e.Perk)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Perk>()
                .HasMany(e => e.PerkLevels)
                .WithRequired(e => e.Perk)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Plant>()
                .HasMany(e => e.GrowingPlants)
                .WithRequired(e => e.Plant)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PlayerCharacter>()
                .Property(e => e.CreateTimestamp)
                .HasPrecision(0);

            modelBuilder.Entity<PlayerCharacter>()
                .Property(e => e.NextSPResetDate)
                .HasPrecision(0);

            modelBuilder.Entity<PlayerCharacter>()
                .Property(e => e.NextResetTokenReceiveDate)
                .HasPrecision(0);

            modelBuilder.Entity<PlayerCharacter>()
                .HasMany(e => e.ChatLogs)
                .WithOptional(e => e.PlayerCharacter)
                .HasForeignKey(e => e.ReceiverPlayerID);

            modelBuilder.Entity<PlayerCharacter>()
                .HasMany(e => e.ChatLogs1)
                .WithOptional(e => e.PlayerCharacter1)
                .HasForeignKey(e => e.SenderPlayerID);

            modelBuilder.Entity<PlayerCharacter>()
                .HasMany(e => e.ConstructionSites)
                .WithRequired(e => e.PlayerCharacter)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PlayerCharacter>()
                .HasMany(e => e.PCCooldowns)
                .WithRequired(e => e.PlayerCharacter)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PlayerCharacter>()
                .HasMany(e => e.PCCustomEffects)
                .WithRequired(e => e.PlayerCharacter)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PlayerCharacter>()
                .HasMany(e => e.PCKeyItems)
                .WithRequired(e => e.PlayerCharacter)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PlayerCharacter>()
                .HasMany(e => e.PCMapPins)
                .WithRequired(e => e.PlayerCharacter)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PlayerCharacter>()
                .HasOptional(e => e.PCOutfit)
                .WithRequired(e => e.PlayerCharacter);

            modelBuilder.Entity<PlayerCharacter>()
                .HasMany(e => e.PCOverflowItems)
                .WithRequired(e => e.PlayerCharacter)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PlayerCharacter>()
                .HasMany(e => e.PCPerks)
                .WithRequired(e => e.PlayerCharacter)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PlayerCharacter>()
                .HasMany(e => e.PCQuestKillTargetProgresses)
                .WithRequired(e => e.PlayerCharacter)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PlayerCharacter>()
                .HasMany(e => e.PCQuestStatus)
                .WithRequired(e => e.PlayerCharacter)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PlayerCharacter>()
                .HasMany(e => e.PCRegionalFames)
                .WithRequired(e => e.PlayerCharacter)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PlayerCharacter>()
                .HasMany(e => e.PCSearchSiteItems)
                .WithRequired(e => e.PlayerCharacter)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PlayerCharacter>()
                .HasMany(e => e.PCSearchSites)
                .WithRequired(e => e.PlayerCharacter)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PlayerCharacter>()
                .HasMany(e => e.PCSkills)
                .WithRequired(e => e.PlayerCharacter)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PlayerCharacter>()
                .HasMany(e => e.PCTerritoryFlags)
                .WithRequired(e => e.PlayerCharacter)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PlayerCharacter>()
                .HasMany(e => e.PCTerritoryFlagsPermissions)
                .WithRequired(e => e.PlayerCharacter)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<QuestRewardItem>()
                .HasMany(e => e.PCQuestStatus)
                .WithOptional(e => e.QuestRewardItem)
                .HasForeignKey(e => e.SelectedItemRewardID);

            modelBuilder.Entity<Quest>()
                .HasMany(e => e.PCQuestStatus)
                .WithRequired(e => e.Quest)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Quest>()
                .HasMany(e => e.QuestKillTargetLists)
                .WithRequired(e => e.Quest)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Quest>()
                .HasMany(e => e.QuestPrerequisites)
                .WithRequired(e => e.Quest)
                .HasForeignKey(e => e.QuestID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Quest>()
                .HasMany(e => e.QuestPrerequisites1)
                .WithRequired(e => e.Quest1)
                .HasForeignKey(e => e.RequiredQuestID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Quest>()
                .HasMany(e => e.QuestRequiredItemLists)
                .WithRequired(e => e.Quest)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Quest>()
                .HasMany(e => e.QuestRequiredKeyItemLists)
                .WithRequired(e => e.Quest)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Quest>()
                .HasMany(e => e.QuestRewardItems)
                .WithRequired(e => e.Quest)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Quest>()
                .HasMany(e => e.QuestStates)
                .WithRequired(e => e.Quest)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<QuestState>()
                .HasMany(e => e.PCQuestStatus)
                .WithRequired(e => e.QuestState)
                .HasForeignKey(e => e.CurrentQuestStateID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<QuestState>()
                .HasMany(e => e.QuestKillTargetLists)
                .WithRequired(e => e.QuestState)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<QuestState>()
                .HasMany(e => e.QuestRequiredItemLists)
                .WithRequired(e => e.QuestState)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<QuestState>()
                .HasMany(e => e.QuestRequiredKeyItemLists)
                .WithRequired(e => e.QuestState)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<QuestTypeDomain>()
                .HasMany(e => e.QuestStates)
                .WithRequired(e => e.QuestTypeDomain)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ServerConfiguration>()
                .Property(e => e.ServerName)
                .IsUnicode(false);

            modelBuilder.Entity<ServerConfiguration>()
                .Property(e => e.MessageOfTheDay)
                .IsUnicode(false);

            modelBuilder.Entity<SkillCategory>()
                .HasMany(e => e.Skills)
                .WithRequired(e => e.SkillCategory)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Skill>()
                .HasMany(e => e.CraftBlueprints)
                .WithRequired(e => e.Skill)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Skill>()
                .HasMany(e => e.Items)
                .WithRequired(e => e.Skill)
                .HasForeignKey(e => e.AssociatedSkillID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Skill>()
                .HasMany(e => e.PCSkills)
                .WithRequired(e => e.Skill)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Skill>()
                .HasMany(e => e.PerkLevelSkillRequirements)
                .WithRequired(e => e.Skill)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Skill>()
                .HasMany(e => e.SkillXPRequirements)
                .WithRequired(e => e.Skill)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<StorageContainer>()
                .HasMany(e => e.StorageItems)
                .WithRequired(e => e.StorageContainer)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<StructureBlueprint>()
                .HasMany(e => e.ConstructionSites)
                .WithRequired(e => e.StructureBlueprint)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<StructureBlueprint>()
                .HasMany(e => e.PCTerritoryFlags)
                .WithRequired(e => e.StructureBlueprint)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<StructureBlueprint>()
                .HasMany(e => e.PCTerritoryFlagsStructures)
                .WithRequired(e => e.StructureBlueprint)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<StructureBlueprint>()
                .HasMany(e => e.StructureComponents)
                .WithRequired(e => e.StructureBlueprint)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<StructureCategory>()
                .HasMany(e => e.StructureBlueprints)
                .WithRequired(e => e.StructureCategory)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<StructureComponent>()
                .HasMany(e => e.ConstructionSiteComponents)
                .WithRequired(e => e.StructureComponent)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TerritoryFlagPermission>()
                .HasMany(e => e.PCTerritoryFlagsPermissions)
                .WithRequired(e => e.TerritoryFlagPermission)
                .WillCascadeOnDelete(false);
        }
    }
}
