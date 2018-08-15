using Freescape.Game.Server.ChatCommands.Contracts;
using Freescape.Game.Server.GameObject;
using NWN;

namespace Freescape.Game.Server.ChatCommands
{
    public class Day: IChatCommand
    {
        private readonly INWScript _;

        public Day(INWScript script)
        {
            _ = script;
        }

        public bool CanUse(NWPlayer user)
        {
            return user.IsDM;
        }

        public void DoAction(NWPlayer user, params string[] args)
        {
            _.SetTime(8, 0, 0, 0);
        }
    }
}
