using System;
using System.Linq;
using Freescape.Game.Server.Conversation.Contracts;
using Freescape.Game.Server.GameObject;
using Freescape.Game.Server.Service.Contracts;
using Freescape.Game.Server.ValueObject.Dialog;
using NWN;
using Object = NWN.Object;

namespace Freescape.Game.Server.Event.Dialog
{
    public class AppearsWhen: IRegisteredEvent
    {
        private readonly INWScript _nw;
        private readonly IDialogService _dialog;

        public AppearsWhen(INWScript nw, IDialogService dialogService)
        {
            _nw = nw;
            _dialog = dialogService;
        }

        public bool Run(params object[] args)
        {
            int nodeType = (int)args[0];
            int nodeID = (int)args[1];

            NWObject target = NWObject.Wrap(Object.OBJECT_SELF);
            NWPlayer player = NWPlayer.Wrap(_nw.GetPCSpeaker());
            PlayerDialog dialog = _dialog.LoadPlayerDialog(player.GlobalID);
            DialogPage page = dialog.CurrentPage;
            int currentSelectionNumber = nodeID + 1;
            bool displayNode = false;
            string newNodeText = string.Empty;
            int dialogOffset = (_dialog.NumberOfResponsesPerPage + 1) * (dialog.DialogNumber - 1);

            if (currentSelectionNumber == _dialog.NumberOfResponsesPerPage + 1) // Next page
            {
                int displayCount = page.NumberOfResponses - (_dialog.NumberOfResponsesPerPage * dialog.PageOffset);

                if (displayCount > _dialog.NumberOfResponsesPerPage)
                {
                    displayNode = true;
                }
            }
            else if (currentSelectionNumber == _dialog.NumberOfResponsesPerPage + 2) // Previous Page
            {
                if (dialog.PageOffset > 0)
                {
                    displayNode = true;
                }
            }
            else if (nodeType == 2)
            {
                int responseID = (dialog.PageOffset * _dialog.NumberOfResponsesPerPage) + nodeID;
                if (responseID + 1 <= page.NumberOfResponses)
                {
                    DialogResponse response = page.Responses[responseID];

                    if (response != null)
                    {
                        newNodeText = response.Text;
                        displayNode = response.IsActive;
                    }
                }
            }
            else if (nodeType == 1)
            {
                Type type = Type.GetType("Conversation." + dialog.ActiveDialogName);
                IConversation convo = App.ResolveByInterface<IConversation>(type);
                if (player.GetLocalInt("DIALOG_SYSTEM_INITIALIZE_RAN") != 1)
                {
                    convo.Initialize();
                    player.SetLocalInt("DIALOG_SYSTEM_INITIALIZE_RAN", 1);
                }

                if (dialog.IsEnding)
                {
                    convo.EndDialog();
                    _dialog.RemovePlayerDialog(player.GlobalID);
                    player.DeleteLocalInt("DIALOG_SYSTEM_INITIALIZE_RAN");
                    target.SetLocalInt("CONVERSATION_SHOW_NODE", 0);
                }

                page = dialog.CurrentPage;
                newNodeText = page.Header;

                _nw.SetCustomToken(90000 + dialogOffset, newNodeText);
                target.SetLocalInt("CONVERSATION_SHOW_NODE", 1);
                return true;
            }

            _nw.SetCustomToken(90001 + nodeID + dialogOffset, newNodeText);
            target.SetLocalInt("CONVERSATION_SHOW_NODE", displayNode ? 1 : 0);
            return true;

        }
    }
}
