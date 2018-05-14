using Freescape.Game.Server.Data;
using Freescape.Game.Server.GameObject;

namespace Freescape.Game.Server.Service.Contracts
{
    public interface IPlayerService
    {
        void InitializePlayer(NWPlayer player);
        PlayerCharacter GetPlayerEntity(NWPlayer player);
        PlayerCharacter GetPlayerEntity(string playerID);
    }
}
