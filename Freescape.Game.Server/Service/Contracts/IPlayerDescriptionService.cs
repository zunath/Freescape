using Freescape.Game.Server.GameObject;

namespace Freescape.Game.Server.Service.Contracts
{
    public interface IPlayerDescriptionService
    {
        void OnModuleNWNXChat();
        void ChangePlayerDescription(NWPlayer player);
    }
}
