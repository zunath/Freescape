using System;
using NWN;
using Object = NWN.Object;

namespace Freescape.Game.Server.GameObject
{
    public class NWPlayer: NWCreature
    {
        private readonly INWScript _script;

        private NWPlayer(INWScript script)
            : base(script)
        {
            _script = script;
        }
        
        public bool IsInitialized
        {
            get
            {
                NWItem database = _script.GetItemPossessedBy(this, "database") as NWItem;
                return _script.GetIsObjectValid(database) != 0 && !string.IsNullOrWhiteSpace(GetLocalString("PC_ID_NUMBER"));
            }
        }

        public void Initialize()
        {
            if (IsInitialized) return;

            NWItem database = (NWItem)_script.GetItemPossessedBy(this, "database");
            if (_script.GetIsObjectValid(database) == 0)
            {
                database = (NWItem)_script.CreateItemOnObject("database", this);
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

                NWItem database = (NWItem)_script.GetItemPossessedBy(this, "database");
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
