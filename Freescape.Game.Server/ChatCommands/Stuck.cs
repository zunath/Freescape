﻿using System.Linq;
using Freescape.Game.Server.ChatCommands.Contracts;
using Freescape.Game.Server.Data;
using Freescape.Game.Server.GameObject;
using NWN;

namespace Freescape.Game.Server.ChatCommands
{
    public class Stuck: IChatCommand
    {
        private readonly INWScript _;
        private readonly DataContext _db;

        public Stuck(INWScript script, DataContext db)
        {
            _ = script;
            _db = db;
        }

        public bool CanUse(NWPlayer user)
        {
            return true;
        }

        public void DoAction(NWPlayer user)
        {
            PlayerCharacter pc = _db.PlayerCharacters.Single(x => x.PlayerID == user.GlobalID);
            Location location = _.Location(
                _.GetObjectByTag(pc.RespawnAreaTag),
                _.Vector((float)pc.RespawnLocationX, (float)pc.RespawnLocationY, (float)pc.RespawnLocationZ),
                (float)pc.RespawnLocationOrientation
            );
            user.AssignCommand(() => _.ActionJumpToLocation(location));
            _.SendMessageToPC(user.Object, "Alpha feature: Returning to bind point. Please report bugs on Discord/GitHub. And for the love of all that is Zunath, don't abuse this!");
        }
    }
}
