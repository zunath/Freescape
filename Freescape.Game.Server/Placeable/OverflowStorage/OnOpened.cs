using System.Collections.Generic;
using System.Linq;
using Freescape.Game.Server.Data.Contracts;
using Freescape.Game.Server.Data.Entities;
using Freescape.Game.Server.Event;
using Freescape.Game.Server.GameObject;
using Freescape.Game.Server.NWNX;
using Freescape.Game.Server.NWNX.Contracts;
using NWN;

namespace Freescape.Game.Server.Placeable.OverflowStorage
{
    public class OnOpened: IRegisteredEvent
    {
        private readonly INWScript _;
        private readonly IDataContext _db;
        private readonly ISCORCO _scorco;

        public OnOpened(INWScript script,
            IDataContext db,
            ISCORCO scorco)
        {
            _ = script;
            _db = db;
            _scorco = scorco;
        }

        public bool Run(params object[] args)
        {
            NWPlaceable container = NWPlaceable.Wrap(Object.OBJECT_SELF);
            NWPlayer oPC = NWPlayer.Wrap(_.GetLastOpenedBy());
            var items = _db.PCOverflowItems.Where(x => x.PlayerID == oPC.GlobalID);
            foreach (PCOverflowItem item in items)
            {
                NWItem oItem = NWItem.Wrap(_scorco.LoadObject(item.ItemObject, container.Location, container.Object));
                oItem.SetLocalInt("TEMP_OVERFLOW_ITEM_ID", (int)item.PCOverflowItemID);
            }

            container.IsUseable = false;
            return true;
        }
    }
}
