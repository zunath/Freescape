using Freescape.Game.Server.Data.Entities;
using Freescape.Game.Server.GameObject;
using Freescape.Game.Server.Service.Contracts;

namespace Freescape.Game.Server.Service
{
    public class FoodService: IFoodService
    {
        public PlayerCharacter RunHungerCycle(NWPlayer pc, PlayerCharacter entity)
        {
            return null;
        }

        public PlayerCharacter ApplyHungerPenalties(PlayerCharacter entity, NWPlayer pc)
        {
            return null;
        }

        public void IncreaseHungerLevel(NWPlayer oPC, int amount, bool isTainted)
        {
        }

        public PlayerCharacter DecreaseHungerLevel(PlayerCharacter entity, NWPlayer oPC, int amount)
        {
            return null;
        }

        public void DecreaseHungerLevel(NWPlayer oPC, int amount)
        {
        }
    }
}
