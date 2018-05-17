using Freescape.Game.Server.Data.Entities;
using Freescape.Game.Server.GameObject;

namespace Freescape.Game.Server.Service.Contracts
{
    public interface IPlayerService
    {
        void InitializePlayer(NWPlayer player);
        PlayerCharacter GetPlayerEntity(NWPlayer player);
        PlayerCharacter GetPlayerEntity(string playerID);
        void OnAreaEnter();
        void LoadCharacter(NWPlayer player);
        void ShowMOTD(NWPlayer player);
        void SaveCharacter(NWPlayer player);
    }
}
