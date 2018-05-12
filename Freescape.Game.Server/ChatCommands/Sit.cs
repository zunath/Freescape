using Freescape.Game.Server.ChatCommands.Contracts;
using Freescape.Game.Server.GameObject;
using NWN;

namespace Freescape.Game.Server.ChatCommands
{
    public class Sit: IChatCommand
    {
        private readonly INWScript _;

        public Sit(INWScript script)
        {
            _ = script;
        }

        public bool CanUse(NWPlayer user)
        {
            return true;
        }

        public void DoAction(NWPlayer user)
        {
            user.AssignCommand(() => _.ActionPlayAnimation(NWScript.ANIMATION_LOOPING_SIT_CROSS, 1.0f, 9999));
        }
    }
}
