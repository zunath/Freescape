using System;
using Freescape.Game.Server.GameObject;
using Freescape.Game.Server.Helper;
using NWN;
using Object = NWN.Object;

namespace Freescape.Game.Server.Event.Trigger
{
    public class ExplorationTrigger: IRegisteredEvent
    {
        private readonly INWScript _script;
        private readonly IColorTokenService _colorToken;

        public ExplorationTrigger(INWScript script, IColorTokenService colorTokenService)
        {
            _script = script;
            _colorToken = colorTokenService;
        }

        public bool Run(params object[] args)
        {
            NWCreature oPC = (NWCreature)_script.GetEnteringObject();
            if (!oPC.IsPlayer) return false;

            string triggerID = _script.GetLocalString(Object.OBJECT_SELF, "TRIGGER_ID");
            if (string.IsNullOrWhiteSpace(triggerID))
            {
                triggerID = Guid.NewGuid().ToString();
                _script.SetLocalString(Object.OBJECT_SELF, "TRIGGER_ID", triggerID);
            }

            if (_script.GetLocalInt(oPC, triggerID) == 1) return false;

            string message = _script.GetLocalString(Object.OBJECT_SELF, "DISPLAY_TEXT");
            _script.SendMessageToPC(oPC, _colorToken.Cyan() + message + _colorToken.End());
            _script.SetLocalInt(oPC, triggerID, 1);

            _script.AssignCommand(oPC, () => _script.PlaySound("gui_prompt"));

            return true;
        }
    }
}
