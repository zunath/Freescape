using System;
using System.Linq;
using Freescape.Game.Server.Data.Contracts;
using Freescape.Game.Server.Data.Entities;
using Freescape.Game.Server.GameObject;
using Freescape.Game.Server.Service.Contracts;

namespace Freescape.Game.Server.Service
{
    public class PVPSanctuaryService: IPVPSanctuaryService
    {
        private readonly IDataContext _db;

        public PVPSanctuaryService(IDataContext db)
        {
            _db = db;
        }

        public bool PlayerHasPVPSanctuary(NWPlayer player)
        {
            if (player == null) throw new ArgumentNullException(nameof(player));
            if (player.Object == null) throw new ArgumentNullException(nameof(player.Object));

            PlayerCharacter pc = _db.PlayerCharacters.Single(x => x.PlayerID == player.GlobalID);
            DateTime now = DateTime.UtcNow;

            return !pc.IsSanctuaryOverrideEnabled && now <= pc.DateSanctuaryEnds;
        }

        public void SetPlayerPVPSanctuaryOverride(NWPlayer player, bool overrideStatus)
        {
            if (player == null) throw new ArgumentNullException(nameof(player));
            if (player.Object == null) throw new ArgumentNullException(nameof(player.Object));

            PlayerCharacter pc = _db.PlayerCharacters.Single(x => x.PlayerID == player.GlobalID);
            pc.IsSanctuaryOverrideEnabled = overrideStatus;
            _db.SaveChanges();
        }
    }
}
