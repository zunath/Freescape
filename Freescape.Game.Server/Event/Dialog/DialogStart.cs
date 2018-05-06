using Freescape.Game.Server.GameObject;
using Freescape.Game.Server.Service.Contracts;
using NWN;

namespace Freescape.Game.Server.Event.Dialog
{
    public class DialogStart: IRegisteredEvent
    {
        private readonly INWScript _script;
        private readonly IDialogService _dialog;

        public DialogStart(INWScript script, IDialogService dialogService)
        {
            _script = script;
            _dialog = dialogService;
        }

        public bool Run(params object[] args)
        {
            NWObject npc = NWObject.Wrap(Object.OBJECT_SELF);
            NWPlayer pc = NWPlayer.Wrap(_script.GetLastUsedBy());
            if (!pc.IsValid) pc = NWPlayer.Wrap(_script.GetPCSpeaker());

            string conversation = npc.GetLocalString("CONVERSATION");

            if (string.IsNullOrWhiteSpace(conversation))
            {
                _dialog.StartConversation(pc, npc, conversation);
            }
            else
            {
                _script.ActionStartConversation(pc.Object, "", NWScript.TRUE, NWScript.FALSE);
            }

            return true;
        }
    }
}
