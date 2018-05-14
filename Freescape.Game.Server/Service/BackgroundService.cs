using System;
using System.Collections.Generic;
using System.Linq;
using Freescape.Game.Server.Data;
using Freescape.Game.Server.Data.Contracts;
using Freescape.Game.Server.GameObject.Contracts;
using Freescape.Game.Server.Service.Contracts;

namespace Freescape.Game.Server.Service
{
    public class BackgroundService: IBackgroundService
    {
        private readonly IDataContext _db;

        public BackgroundService(IDataContext db)
        {
            _db = db;
        }

        public IEnumerable<Background> GetActiveBackgrounds()
        {
            return _db.Backgrounds.Where(x => x.IsActive);
        }

        public void SetPlayerBackground(INWPlayer player, Background background)
        {
            if(player == null) throw new ArgumentNullException(nameof(player));
            if(background == null) throw new ArgumentNullException(nameof(background));

            PlayerCharacter pc = _db.PlayerCharacters.Single(x => x.PlayerID == player.GlobalID);
            pc.BackgroundID = background.BackgroundID;
            _db.SaveChanges();
        }
    }
}
