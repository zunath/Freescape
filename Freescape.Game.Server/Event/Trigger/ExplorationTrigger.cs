using System;
using Freescape.Game.Server.GameObject;
using Freescape.Game.Server.Helper;
using NWN;
using Object = NWN.Object;

namespace Freescape.Game.Server.Event.Trigger
{
    public class ExplorationTrigger: IRegisteredEvent
    {
        public bool Run(params object[] args)
        {
            NWCreature oPC = (NWCreature)NWScript.GetEnteringObject();
            if (!oPC.IsPlayer) return false;

            string triggerID = NWScript.GetLocalString(Object.OBJECT_SELF, "TRIGGER_ID");
            if (string.IsNullOrWhiteSpace(triggerID))
            {
                triggerID = Guid.NewGuid().ToString();
                NWScript.SetLocalString(Object.OBJECT_SELF, "TRIGGER_ID", triggerID);
            }

            if (NWScript.GetLocalInt(oPC, triggerID) == 1) return false;

            string message = NWScript.GetLocalString(Object.OBJECT_SELF, "DISPLAY_TEXT");
            NWScript.SendMessageToPC(oPC, ColorToken.Cyan() + message + ColorToken.End());
            NWScript.SetLocalInt(oPC, triggerID, 1);

            NWScript.AssignCommand(oPC, () => NWScript.PlaySound("gui_prompt"));

            return true;
        }
    }
}
