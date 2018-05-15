using System;
using Freescape.Game.Server.GameObject;
using NWN;

namespace Freescape.Game.Server.Event.Module
{
    public class OnModuleExamine: IRegisteredEvent
    {
        private readonly INWScript _;

        public OnModuleExamine(
            INWScript script)
        {
            _ = script;
        }

        public bool Run(params object[] args)
        {
            // TODO: Set up NWNX 
            /*
            NWObject examinedObject = NWNX_Events.OnExamineObject_GetTarget();
            if (ExaminationSystem.OnModuleExamine(examiner, examinedObject)) return;

            String description = NWScript.getDescription(examinedObject, true, true) + "\n\n";
            description = ItemSystem.OnModuleExamine(description, examiner, examinedObject);
            description = PerkSystem.OnModuleExamine(description, examiner, examinedObject);
            description = DurabilitySystem.OnModuleExamine(description, examinedObject);
            description = FarmingSystem.OnModuleExamine(description, examinedObject);

            if (description.equals("")) return;
            NWScript.setDescription(examinedObject, description, false);
            NWScript.setDescription(examinedObject, description, true);
            */
            return true;
        }
    }
}
