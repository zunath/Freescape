using System.Collections.Generic;
using System.Linq;
using Freescape.Game.Server.Data;
using Freescape.Game.Server.GameObject;
using Freescape.Game.Server.Service.Contracts;

namespace Freescape.Game.Server.Service
{
    public class BackgroundService: IBackgroundService
    {
        private readonly DataContext _db;

        public BackgroundService(DataContext db)
        {
            _db = db;
        }

        public IEnumerable<Background> GetActiveBackgrounds()
        {
            return _db.Backgrounds.Where(x => x.IsActive);
        }

        public void SetPlayerBackground(NWPlayer player, Background background)
        {
            PlayerCharacter pc = _db.PlayerCharacters.Single(x => x.PlayerID == player.GlobalID);
            pc.BackgroundID = background.BackgroundID;
            _db.SaveChanges();
        }
    }
}
