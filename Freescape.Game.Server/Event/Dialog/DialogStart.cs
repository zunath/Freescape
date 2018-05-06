using Freescape.Game.Server.GameObject;
using Freescape.Game.Server.Service.Contracts;
using NWN;

namespace Freescape.Game.Server.Event.Dialog
{
    public class DialogStart: IRegisteredEvent
    {
        private readonly INWScript _;
        private readonly IDialogService _dialog;

        public DialogStart(INWScript script, IDialogService dialogService)
        {
            _ = script;
            _dialog = dialogService;
        }

        public bool Run(params object[] args)
        {
            NWObject npc = NWObject.Wrap(Object.OBJECT_SELF);
            NWPlayer pc = NWPlayer.Wrap(_.GetLastUsedBy());
            if (!pc.IsValid) pc = NWPlayer.Wrap(_.GetPCSpeaker());

            string conversation = npc.GetLocalString("CONVERSATION");

            if (string.IsNullOrWhiteSpace(conversation))
            {
                _dialog.StartConversation(pc, npc, conversation);
            }
            else
            {
                _.ActionStartConversation(pc.Object, "", NWScript.TRUE, NWScript.FALSE);
            }

            return true;
        }
    }
}
