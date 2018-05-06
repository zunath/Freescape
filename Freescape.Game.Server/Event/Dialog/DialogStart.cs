using NWN;

namespace Freescape.Game.Server.Event.Dialog
{
    public class DialogStart: IRegisteredEvent
    {
        public bool Run(params object[] args)
        {
            Object npc = Object.OBJECT_SELF;
            Object pc = NWScript.GetLastUsedBy();
            if (NWScript.GetIsObjectValid(pc) == 0) pc = NWScript.GetPCSpeaker();

            string conversation = NWScript.GetLocalString(npc, "CONVERSATION");

            if (string.IsNullOrWhiteSpace(conversation))
            {
                // todo: DialogManager.startConversation(pc, npc, conversation);
            }
            else
            {
                NWScript.ActionStartConversation(pc, "", NWScript.TRUE, NWScript.FALSE);
            }

            return true;
        }
    }
}
