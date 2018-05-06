using System;
using NWN;

namespace Freescape.Game.Server.GameObject
{
    public class NWPlayer: NWCreature
    {
        public bool IsInitialized
        {
            get
            {
                NWItem database = NWScript.GetItemPossessedBy(this, "database") as NWItem;
                return NWScript.GetIsObjectValid(database) != 0 && !string.IsNullOrWhiteSpace(GetLocalString("PC_ID_NUMBER"));
            }
        }

        public void Initialize()
        {
            if (IsInitialized) return;

            NWItem database = (NWItem)NWScript.GetItemPossessedBy(this, "database");
            if (NWScript.GetIsObjectValid(database) == 0)
            {
                database = (NWItem)NWScript.CreateItemOnObject("database", this);
            }

            string guid = Guid.NewGuid().ToString();
            database.SetLocalString("PC_ID_NUMBER", guid);
        }

        public string GlobalID
        {
            get
            {
                if (!IsInitialized)
                {
                    throw new Exception("Must call Initialize() before getting GlobalID");
                }

                NWItem database = (NWItem)NWScript.GetItemPossessedBy(this, "database");
                return database.GetLocalString("PC_ID_NUMBER");
            }
        }

        public bool IsBusy
        {
            get => GetLocalInt("IS_BUSY") == 1;
            set => SetLocalInt("IS_BUSY", value ? 1 : 0);
        }

    }
}
