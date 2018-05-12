using System;
using System.Linq;
using Freescape.Game.Server.Data;
using Freescape.Game.Server.GameObject;
using Freescape.Game.Server.Service.Contracts;

namespace Freescape.Game.Server.Service
{
    public class PVPSanctuaryService: IPVPSanctuaryService
    {
        private readonly DataContext _db;

        public PVPSanctuaryService(DataContext db)
        {
            _db = db;
        }

        public bool PlayerHasPVPSanctuary(NWPlayer player)
        {
            PlayerCharacter pc = _db.PlayerCharacters.Single(x => x.PlayerID == player.GlobalID);
            DateTime now = DateTime.UtcNow;

            return !pc.IsSanctuaryOverrideEnabled && now <= pc.DateSanctuaryEnds;
        }

        public void SetPlayerPVPSanctuaryOverride(NWPlayer player, bool overrideStatus)
        {
            PlayerCharacter pc = _db.PlayerCharacters.Single(x => x.PlayerID == player.GlobalID);
            pc.IsSanctuaryOverrideEnabled = overrideStatus;
            _db.SaveChanges();
        }
    }
}
