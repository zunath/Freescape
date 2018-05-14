using System;
using Freescape.Game.Server.Data;
using Freescape.Game.Server.GameObject.Contracts;
using NWN;
using Object = NWN.Object;

namespace Freescape.Game.Server.GameObject
{
    public class NWPlayer : NWCreature, INWPlayer
    {
        public NWPlayer(INWScript script)
            : base(script)
        {
        }

        public new static NWPlayer Wrap(Object @object)
        {
            var obj = (NWPlayer)App.Resolve<INWPlayer>();
            obj.Object = @object;

            return obj;
        }

        public virtual bool IsInitialized
        {
            get
            {
                NWItem database = NWItem.Wrap(_.GetItemPossessedBy(Object, "database"));
                string globalID = database.GetLocalString("PC_ID_NUMBER");
                return database.IsValid && !string.IsNullOrWhiteSpace(globalID);
            }
        }

        public virtual void Initialize()
        {
            if (IsInitialized) return;
            
            NWItem database = NWItem.Wrap(_.GetItemPossessedBy(Object, "database"));
            if (!database.IsValid)
            {
                database = NWItem.Wrap(_.CreateItemOnObject("database", Object));
            }
            
            string guid = Guid.NewGuid().ToString();
            database.SetLocalString("PC_ID_NUMBER", guid);
        }

        public virtual string GlobalID
        {
            get
            {
                if (!IsInitialized)
                {
                    throw new Exception("Must call Initialize() before getting GlobalID");
                }

                NWItem database = NWItem.Wrap(_.GetItemPossessedBy(Object, "database"));
                return database.GetLocalString("PC_ID_NUMBER");
            }
        }

        public virtual bool IsBusy
        {
            get => GetLocalInt("IS_BUSY") == 1;
            set => SetLocalInt("IS_BUSY", value ? 1 : 0);
        }

        public virtual PlayerCharacter ToEntity()
        {
            PlayerCharacter entity = new PlayerCharacter
            {
                PlayerID = GlobalID,
                CharacterName = Name,
                HitPoints = CurrentHP,
                LocationAreaTag = _.GetTag(_.GetAreaFromLocation(Location)),
                LocationX = Position.m_X,
                LocationY = Position.m_Y,
                LocationZ = Position.m_Z,
                LocationOrientation = Facing,
                CreateTimestamp = DateTime.UtcNow,
                MaxHunger = 150,
                CurrentHunger = 150,
                CurrentHungerTick = 300,
                UnallocatedSP = 5,
                NextSPResetDate = null,
                ResetTokens = 3,
                NextResetTokenReceiveDate = null,
                HPRegenerationAmount = 1,
                RegenerationTick = 20,
                RegenerationRate = 0,
                VersionNumber = 1,
                MaxMana = 0,
                CurrentMana = 0,
                CurrentManaTick = 20,
                RevivalStoneCount = 3,
                RespawnAreaTag = string.Empty,
                RespawnLocationX = 0.0f,
                RespawnLocationY = 0.0f,
                RespawnLocationZ = 0.0f,
                RespawnLocationOrientation = 0.0f,
                DateLastForcedSPReset = null,
                DateSanctuaryEnds = DateTime.UtcNow + TimeSpan.FromDays(3),
                IsSanctuaryOverrideEnabled = false,
                STRBase = Strength, // Todo: Get raw strength
                DEXBase = Dexterity, // todo: get raw dex
                CONBase = Constitution, // todo: get raw con
                INTBase = Intelligence, // todo: get raw int
                WISBase = Wisdom, // todo: get raw wis
                CHABase = Charisma, // todo: get raw cha
                TotalSPAcquired = 0,
                DisplayHelmet = true
            };
            
            return entity;
        }

    }
}
