using NWN;

namespace Freescape.Game.Server.Event.Dialog
{
    public class DialogStart: IRegisteredEvent
    {
        private readonly INWScript _script;

        public DialogStart(INWScript script)
        {
            _script = script;
        }

        public bool Run(params object[] args)
        {
            Object npc = Object.OBJECT_SELF;
            Object pc = _script.GetLastUsedBy();
            if (_script.GetIsObjectValid(pc) == 0) pc = _script.GetPCSpeaker();

            string conversation = _script.GetLocalString(npc, "CONVERSATION");

            if (string.IsNullOrWhiteSpace(conversation))
            {
                // todo: DialogManager.startConversation(pc, npc, conversation);
            }
            else
            {
                _script.ActionStartConversation(pc, "", NWScript.TRUE, NWScript.FALSE);
            }

            return true;
        }
    }
}
