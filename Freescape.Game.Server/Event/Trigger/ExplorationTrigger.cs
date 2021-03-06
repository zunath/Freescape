﻿using System;
using Freescape.Game.Server.GameObject;
using Freescape.Game.Server.Service.Contracts;
using NWN;
using Object = NWN.Object;

namespace Freescape.Game.Server.Event.Trigger
{
    public class ExplorationTrigger: IRegisteredEvent
    {
        private readonly INWScript _;
        private readonly IColorTokenService _colorToken;

        public ExplorationTrigger(INWScript script, IColorTokenService colorTokenService)
        {
            _ = script;
            _colorToken = colorTokenService;
        }

        public bool Run(params object[] args)
        {
            NWCreature oPC = NWCreature.Wrap(_.GetEnteringObject());
            if (!oPC.IsPlayer) return false;

            string triggerID = _.GetLocalString(Object.OBJECT_SELF, "TRIGGER_ID");
            if (string.IsNullOrWhiteSpace(triggerID))
            {
                triggerID = Guid.NewGuid().ToString();
                _.SetLocalString(Object.OBJECT_SELF, "TRIGGER_ID", triggerID);
            }

            if (_.GetLocalInt(oPC.Object, triggerID) == 1) return false;

            string message = _.GetLocalString(Object.OBJECT_SELF, "DISPLAY_TEXT");
            _.SendMessageToPC(oPC.Object, _colorToken.Cyan(message));
            _.SetLocalInt(oPC.Object, triggerID, 1);

            _.AssignCommand(oPC.Object, () => _.PlaySound("gui_prompt"));

            return true;
        }
    }
}
