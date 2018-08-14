﻿using Freescape.Game.Server.Data.Entities;
using Freescape.Game.Server.Event;
using Freescape.Game.Server.GameObject;
using Freescape.Game.Server.NWNX;
using Freescape.Game.Server.NWNX.Contracts;
using Freescape.Game.Server.Service.Contracts;
using NWN;

namespace Freescape.Game.Server.Placeable.StructureSystem.PersistentStorage
{
    public class OnOpened: IRegisteredEvent
    {
        private readonly INWScript _;
        private readonly IStructureService _structure;
        private readonly ISCORCO _scorco;

        public OnOpened(INWScript script,
            IStructureService structure,
            ISCORCO scorco)
        {
            _ = script;
            _structure = structure;
            _scorco = scorco;
        }

        public bool Run(params object[] args)
        {
            NWPlaceable chest = NWPlaceable.Wrap(Object.OBJECT_SELF);
            int structureID = chest.GetLocalInt("STRUCTURE_TEMP_STRUCTURE_ID");
            PCTerritoryFlagsStructure entity = _structure.GetPCStructureByID(structureID);
            Location location = chest.Location;

            foreach (PCTerritoryFlagsStructuresItem item in entity.PCTerritoryFlagsStructuresItems)
            {
                _scorco.LoadObject(item.ItemObject, location, chest.Object);
            }

            chest.IsUseable = false;
            return true;
        }
    }
}