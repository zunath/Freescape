using Freescape.Game.Server.GameObject;

namespace Freescape.Game.Server.Service.Contracts
{
    public interface IDeathService
    {
        void BindPlayerSoul(NWPlayer player, bool showMessage);
    }
}
