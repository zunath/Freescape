﻿using Freescape.Game.Server.GameObject;

namespace Freescape.Game.Server.Service.Contracts
{
    public interface IFarmingService
    {
        void HarvestPlant(NWPlayer player, NWItem shovel, NWPlaceable plant);
        string OnModuleExamine(string existingDescription, NWObject examinedObject);
    }
}
