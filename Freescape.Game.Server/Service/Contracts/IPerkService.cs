using Freescape.Game.Server.Enumeration;
using Freescape.Game.Server.GameObject;

namespace Freescape.Game.Server.Service.Contracts
{
    public interface IPerkService
    {
        int GetPCPerkLevel(NWPlayer player, PerkType perkType);
    }
}
