using NWN;
using static NWN.NWScript;

namespace Freescape.Game.Server.Events.Dialog
{
    public class DialogStart: IRegisteredEvent
    {
        public void Run(params object[] args)
        {
            Object npc = Object.OBJECT_SELF;
            Object pc = GetLastUsedBy();
            if (GetIsObjectValid(pc) == 0) pc = GetPCSpeaker();

            string conversation = GetLocalString(npc, "CONVERSATION");

            if (string.IsNullOrWhiteSpace(conversation))
            {
                // todo: DialogManager.startConversation(pc, npc, conversation);
            }
            else
            {
                ActionStartConversation(pc, "", TRUE, FALSE);
            }

        }
    }
}
