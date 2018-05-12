using Freescape.Game.Server.GameObject;

namespace Freescape.Game.Server.ChatCommands.Contracts
{
    public interface IChatCommand
    {
        bool CanUse(NWPlayer user);
        void DoAction(NWPlayer user);
    }
}
