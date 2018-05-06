using System;
using System.Collections.Generic;
using Freescape.Game.Server.Conversation.Contracts;
using Freescape.Game.Server.GameObject;
using Freescape.Game.Server.Helper;
using Freescape.Game.Server.Service.Contracts;
using Freescape.Game.Server.ValueObject.Dialog;
using static NWN.NWScript;

namespace Freescape.Game.Server.Service
{
    public class DialogService: IDialogService
    {
        
        private const int NumberOfDialogs = 99;

        private readonly Dictionary<string, PlayerDialog> _playerDialogs;
        private readonly Dictionary<int, bool> _dialogFilesInUse;

        public DialogService()
        {
            _playerDialogs = new Dictionary<string, PlayerDialog>();
            _dialogFilesInUse = new Dictionary<int, bool>();

            for (int x = 1; x <= NumberOfDialogs; x++)
            {
                _dialogFilesInUse.Add(x, false);
            }
        }

        private void StorePlayerDialog(string globalID, PlayerDialog dialog)
        {
            if (dialog.DialogNumber <= 0)
            {
                for (int x = 1; x <= NumberOfDialogs; x++)
                {
                    if (!_dialogFilesInUse.ContainsKey(x))
                    {
                        _dialogFilesInUse[x] = true;
                        dialog.DialogNumber = x;
                        break;
                    }
                }
            }

            // Couldn't find an open dialog file. Throw error.
            if (dialog.DialogNumber <= 0)
            {
                Console.WriteLine("ERROR: Unable to locate a free dialog. Add more dialog files, update their custom tokens, and update DialogManager.java");
                return;
            }

            _playerDialogs[globalID] = dialog;
        }

        public int NumberOfResponsesPerPage => 12;

        public PlayerDialog LoadPlayerDialog(string globalID)
        {
            return _playerDialogs[globalID];
        }

        public void RemovePlayerDialog(string globalID)
        {
            PlayerDialog dialog = _playerDialogs[globalID];
            _dialogFilesInUse[dialog.DialogNumber] = false;

            _playerDialogs.Remove(globalID);
        }

        public void LoadConversation(NWPlayer player, NWObject talkTo, string @class, int dialogNumber)
        {
            Type type = Type.GetType("Conversation." + @class);
            IConversation convo = App.Get<IConversation>(type);

            PlayerDialog dialog = convo.SetUp(player);
            if (dialogNumber > 0)
                dialog.DialogNumber = dialogNumber;

            dialog.ActiveDialogName = @class;
            dialog.DialogTarget = talkTo;
            StorePlayerDialog(player.GlobalID, dialog);
        }

        public void StartConversation(NWPlayer player, NWObject talkTo, string @class)
        {
            LoadConversation(player, talkTo, @class, -1);
            PlayerDialog dialog = _playerDialogs[player.GlobalID];

            if (dialog.DialogNumber <= 0)
            {
                FloatingTextStringOnCreature(ColorToken.Red() + "ERROR: No dialog files are available for use." + ColorToken.End(), player, FALSE);
                return;
            }

            // NPC conversations
            NWCreature talkToCreature = (NWCreature) talkTo;
            if (GetObjectType(talkTo) == OBJECT_TYPE_CREATURE &&
                !talkToCreature.IsPlayer &&
                !talkToCreature.IsDM)
            {
                BeginConversation("dialog" + dialog.DialogNumber);
            }
            // Everything else
            else
            {
                AssignCommand(player, () => ActionStartConversation(talkTo, "dialog" + dialog.DialogNumber, TRUE, FALSE));
            }
        }

        public void EndConversation(NWPlayer player)
        {
            PlayerDialog playerDialog = LoadPlayerDialog(player.GlobalID);
            playerDialog.IsEnding = true;
            StorePlayerDialog(player.GlobalID, playerDialog);
        }

    }
}
