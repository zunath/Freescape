﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Freescape.Game.Server.Data
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class DataContext : DbContext
    {
        public DataContext()
            : base("name=DataContext")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual IDbSet<Attribute> Attributes { get; set; }
        public virtual IDbSet<AuthorizedDM> AuthorizedDMs { get; set; }
        public virtual IDbSet<Background> Backgrounds { get; set; }
        public virtual IDbSet<BaseItemType> BaseItemTypes { get; set; }
        public virtual IDbSet<BuildingCategory> BuildingCategories { get; set; }
        public virtual IDbSet<BuildingInterior> BuildingInteriors { get; set; }
        public virtual IDbSet<BuildPrivacyDomain> BuildPrivacyDomains { get; set; }
        public virtual IDbSet<ChatChannelsDomain> ChatChannelsDomains { get; set; }
        public virtual IDbSet<ChatLog> ChatLogs { get; set; }
        public virtual IDbSet<ClientLogEvent> ClientLogEvents { get; set; }
        public virtual IDbSet<ClientLogEventTypesDomain> ClientLogEventTypesDomains { get; set; }
        public virtual IDbSet<ConstructionSiteComponent> ConstructionSiteComponents { get; set; }
        public virtual IDbSet<ConstructionSite> ConstructionSites { get; set; }
        public virtual IDbSet<CooldownCategory> CooldownCategories { get; set; }
        public virtual IDbSet<CraftBlueprintCategory> CraftBlueprintCategories { get; set; }
        public virtual IDbSet<CraftBlueprintComponent> CraftBlueprintComponents { get; set; }
        public virtual IDbSet<CraftBlueprint> CraftBlueprints { get; set; }
        public virtual IDbSet<CraftDevice> CraftDevices { get; set; }
        public virtual IDbSet<CustomEffect> CustomEffects { get; set; }
        public virtual IDbSet<DMRoleDomain> DMRoleDomains { get; set; }
        public virtual IDbSet<Download> Downloads { get; set; }
        public virtual IDbSet<FameRegion> FameRegions { get; set; }
        public virtual IDbSet<GameTopicCategory> GameTopicCategories { get; set; }
        public virtual IDbSet<GameTopic> GameTopics { get; set; }
        public virtual IDbSet<GrowingPlant> GrowingPlants { get; set; }
        public virtual IDbSet<Item> Items { get; set; }
        public virtual IDbSet<ItemType> ItemTypes { get; set; }
        public virtual IDbSet<KeyItemCategory> KeyItemCategories { get; set; }
        public virtual IDbSet<KeyItem> KeyItems { get; set; }
        public virtual IDbSet<LootTableItem> LootTableItems { get; set; }
        public virtual IDbSet<LootTable> LootTables { get; set; }
        public virtual IDbSet<NPCGroup> NPCGroups { get; set; }
        public virtual IDbSet<PCCooldown> PCCooldowns { get; set; }
        public virtual IDbSet<PCCorpseItem> PCCorpseItems { get; set; }
        public virtual IDbSet<PCCorps> PCCorpses { get; set; }
        public virtual IDbSet<PCCustomEffect> PCCustomEffects { get; set; }
        public virtual IDbSet<PCKeyItem> PCKeyItems { get; set; }
        public virtual IDbSet<PCMapPin> PCMapPins { get; set; }
        public virtual IDbSet<PCMigrationItem> PCMigrationItems { get; set; }
        public virtual IDbSet<PCMigration> PCMigrations { get; set; }
        public virtual IDbSet<PCOutfit> PCOutfits { get; set; }
        public virtual IDbSet<PCOverflowItem> PCOverflowItems { get; set; }
        public virtual IDbSet<PCPerk> PCPerks { get; set; }
        public virtual IDbSet<PCQuestKillTargetProgress> PCQuestKillTargetProgresses { get; set; }
        public virtual IDbSet<PCQuestStatu> PCQuestStatus { get; set; }
        public virtual IDbSet<PCRegionalFame> PCRegionalFames { get; set; }
        public virtual IDbSet<PCSearchSiteItem> PCSearchSiteItems { get; set; }
        public virtual IDbSet<PCSearchSite> PCSearchSites { get; set; }
        public virtual IDbSet<PCSkill> PCSkills { get; set; }
        public virtual IDbSet<PCTerritoryFlag> PCTerritoryFlags { get; set; }
        public virtual IDbSet<PCTerritoryFlagsPermission> PCTerritoryFlagsPermissions { get; set; }
        public virtual IDbSet<PCTerritoryFlagsStructure> PCTerritoryFlagsStructures { get; set; }
        public virtual IDbSet<PCTerritoryFlagsStructuresItem> PCTerritoryFlagsStructuresItems { get; set; }
        public virtual IDbSet<PerkCategory> PerkCategories { get; set; }
        public virtual IDbSet<PerkExecutionType> PerkExecutionTypes { get; set; }
        public virtual IDbSet<PerkLevel> PerkLevels { get; set; }
        public virtual IDbSet<PerkLevelSkillRequirement> PerkLevelSkillRequirements { get; set; }
        public virtual IDbSet<Perk> Perks { get; set; }
        public virtual IDbSet<Plant> Plants { get; set; }
        public virtual IDbSet<PlayerCharacter> PlayerCharacters { get; set; }
        public virtual IDbSet<QuestKillTargetList> QuestKillTargetLists { get; set; }
        public virtual IDbSet<QuestPrerequisite> QuestPrerequisites { get; set; }
        public virtual IDbSet<QuestRequiredItemList> QuestRequiredItemLists { get; set; }
        public virtual IDbSet<QuestRequiredKeyItemList> QuestRequiredKeyItemLists { get; set; }
        public virtual IDbSet<QuestRewardItem> QuestRewardItems { get; set; }
        public virtual IDbSet<Quest> Quests { get; set; }
        public virtual IDbSet<QuestState> QuestStates { get; set; }
        public virtual IDbSet<QuestTypeDomain> QuestTypeDomains { get; set; }
        public virtual IDbSet<ServerConfiguration> ServerConfigurations { get; set; }
        public virtual IDbSet<SkillCategory> SkillCategories { get; set; }
        public virtual IDbSet<Skill> Skills { get; set; }
        public virtual IDbSet<SkillXPRequirement> SkillXPRequirements { get; set; }
        public virtual IDbSet<StorageContainer> StorageContainers { get; set; }
        public virtual IDbSet<StorageItem> StorageItems { get; set; }
        public virtual IDbSet<StructureBlueprint> StructureBlueprints { get; set; }
        public virtual IDbSet<StructureCategory> StructureCategories { get; set; }
        public virtual IDbSet<StructureComponent> StructureComponents { get; set; }
        public virtual IDbSet<StructureQuickBuildAudit> StructureQuickBuildAudits { get; set; }
        public virtual IDbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual IDbSet<TerritoryFlagPermission> TerritoryFlagPermissions { get; set; }
        public virtual IDbSet<User> Users { get; set; }
    
        [DbFunction("DataContext", "fn_GetPlayerEffectivePerkLevel")]
        public virtual IQueryable<fn_GetPlayerEffectivePerkLevel_Result> fn_GetPlayerEffectivePerkLevel(string playerID, Nullable<int> perkID, Nullable<int> skillLevel)
        {
            var playerIDParameter = playerID != null ?
                new ObjectParameter("PlayerID", playerID) :
                new ObjectParameter("PlayerID", typeof(string));
    
            var perkIDParameter = perkID.HasValue ?
                new ObjectParameter("PerkID", perkID) :
                new ObjectParameter("PerkID", typeof(int));
    
            var skillLevelParameter = skillLevel.HasValue ?
                new ObjectParameter("SkillLevel", skillLevel) :
                new ObjectParameter("SkillLevel", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.CreateQuery<fn_GetPlayerEffectivePerkLevel_Result>("[DataContext].[fn_GetPlayerEffectivePerkLevel](@PlayerID, @PerkID, @SkillLevel)", playerIDParameter, perkIDParameter, skillLevelParameter);
        }
    
        public virtual int sp_alterdiagram(string diagramname, Nullable<int> owner_id, Nullable<int> version, byte[] definition)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var versionParameter = version.HasValue ?
                new ObjectParameter("version", version) :
                new ObjectParameter("version", typeof(int));
    
            var definitionParameter = definition != null ?
                new ObjectParameter("definition", definition) :
                new ObjectParameter("definition", typeof(byte[]));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_alterdiagram", diagramnameParameter, owner_idParameter, versionParameter, definitionParameter);
        }
    
        public virtual int sp_creatediagram(string diagramname, Nullable<int> owner_id, Nullable<int> version, byte[] definition)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var versionParameter = version.HasValue ?
                new ObjectParameter("version", version) :
                new ObjectParameter("version", typeof(int));
    
            var definitionParameter = definition != null ?
                new ObjectParameter("definition", definition) :
                new ObjectParameter("definition", typeof(byte[]));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_creatediagram", diagramnameParameter, owner_idParameter, versionParameter, definitionParameter);
        }
    
        public virtual int sp_dropdiagram(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_dropdiagram", diagramnameParameter, owner_idParameter);
        }
    
        public virtual ObjectResult<sp_helpdiagramdefinition_Result> sp_helpdiagramdefinition(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_helpdiagramdefinition_Result>("sp_helpdiagramdefinition", diagramnameParameter, owner_idParameter);
        }
    
        public virtual ObjectResult<sp_helpdiagrams_Result> sp_helpdiagrams(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_helpdiagrams_Result>("sp_helpdiagrams", diagramnameParameter, owner_idParameter);
        }
    
        public virtual int sp_renamediagram(string diagramname, Nullable<int> owner_id, string new_diagramname)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var new_diagramnameParameter = new_diagramname != null ?
                new ObjectParameter("new_diagramname", new_diagramname) :
                new ObjectParameter("new_diagramname", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_renamediagram", diagramnameParameter, owner_idParameter, new_diagramnameParameter);
        }
    
        public virtual int sp_upgraddiagrams()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_upgraddiagrams");
        }
    }
}