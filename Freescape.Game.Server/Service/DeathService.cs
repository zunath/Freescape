using System;
using System.Linq;
using Freescape.Game.Server.Data.Contracts;
using Freescape.Game.Server.Data.Entities;
using Freescape.Game.Server.GameObject;
using Freescape.Game.Server.Service.Contracts;
using NWN;
using static NWN.NWScript;

namespace Freescape.Game.Server.Service
{
    public class DeathService: IDeathService
    {
        private readonly IDataContext _db;
        private readonly INWScript _;

        public DeathService(IDataContext db, INWScript script)
        {
            _db = db;
            _ = script;
        }

        public void BindPlayerSoul(NWPlayer player, bool showMessage)
        {
            if (player == null) throw new ArgumentNullException(nameof(player), nameof(player) + " cannot be null.");
            if (player.Object == null) throw new ArgumentNullException(nameof(player.Object), nameof(player.Object) + " cannot be null.");

            PlayerCharacter pc = _db.PlayerCharacters.Single(x => x.PlayerID == player.GlobalID);
            pc.RespawnLocationX = player.Position.m_X;
            pc.RespawnLocationY = player.Position.m_Y;
            pc.RespawnLocationZ = player.Position.m_Z;
            pc.RespawnLocationOrientation = player.Facing;
            pc.RespawnAreaTag = player.Area.Tag;

            _db.SaveChanges();
            
            if (showMessage)
            {
                _.FloatingTextStringOnCreature("Your soul has been bound to this location.", player.Object, FALSE);
            }
        }
    }
}
