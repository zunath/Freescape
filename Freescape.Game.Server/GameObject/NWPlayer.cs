using System;
using Freescape.Game.Server.GameObject.Contracts;
using NWN;
using Object = NWN.Object;

namespace Freescape.Game.Server.GameObject
{
    public class NWPlayer : NWCreature, INWPlayer
    {
        private readonly INWScript _script;

        public NWPlayer(INWScript script)
            : base(script)
        {
            _script = script;
        }

        public new static NWPlayer Wrap(Object @object)
        {
            var obj = (NWPlayer)App.Resolve<INWPlayer>();
            obj.Object = @object;

            return obj;
        }

        public bool IsInitialized
        {
            get
            {
                NWItem database = NWItem.Wrap(_script.GetItemPossessedBy(Object, "database"));
                return !database.IsValid && !string.IsNullOrWhiteSpace(GetLocalString("PC_ID_NUMBER"));
            }
        }

        public void Initialize()
        {
            if (IsInitialized) return;

            NWItem database = NWItem.Wrap(_script.GetItemPossessedBy(Object, "database"));
            if (!database.IsValid)
            {
                database = NWItem.Wrap(_script.CreateItemOnObject("database", Object));
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

                NWItem database = NWItem.Wrap(_script.GetItemPossessedBy(Object, "database"));
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
