using Freescape.Game.Server.Data;

namespace Freescape.Game.Server.Service.Contracts
{
    public interface IOutfitService
    {
        PCOutfit GetPlayerOutfits(string playerID);

        void SaveChanges();
    }
}
