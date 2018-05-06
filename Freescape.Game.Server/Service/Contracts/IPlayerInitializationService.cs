using Freescape.Game.Server.GameObject;

namespace Freescape.Game.Server.Service.Contracts
{
    public interface IPlayerInitializationService
    {
        void InitializePlayer(NWPlayer player);
    }
}
