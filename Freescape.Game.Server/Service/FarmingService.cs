using Freescape.Game.Server.GameObject;
using Freescape.Game.Server.Service.Contracts;

namespace Freescape.Game.Server.Service
{
    public class FarmingService: IFarmingService
    {
        public void HarvestPlant(NWPlayer player, NWItem shovel, NWPlaceable plant)
        {
        }

        public string OnModuleExamine(string existingDescription, NWObject examinedObject)
        {
            return null;
        }

        public void OnModuleLoad()
        {
            
        }
    }
}
