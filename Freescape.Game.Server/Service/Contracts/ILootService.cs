using Freescape.Game.Server.GameObject;

namespace Freescape.Game.Server.Service.Contracts
{
    public interface ILootService
    {
        void OnCreatureDeath(NWCreature creature);
    }
}
