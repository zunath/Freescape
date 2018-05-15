using System;
using System.Collections.Generic;
using Freescape.Game.Server.Conversation;
using Freescape.Game.Server.GameObject;
using Freescape.Game.Server.Service.Contracts;
using Freescape.Game.Server.ValueObject.Dialog;
using NWN;
using static NWN.NWScript;

namespace Freescape.Game.Server.Service
{
    public class DialogService: IDialogService
    {
        private readonly INWScript _;
        private readonly IColorTokenService _colorToken;
        private const int NumberOfDialogs = 99;

        private readonly Dictionary<string, PlayerDialog> _playerDialogs;
        private readonly Dictionary<int, bool> _dialogFilesInUse;

        public DialogService(INWScript script, IColorTokenService colorToken)
        {
            _ = script;
            _colorToken = colorToken;
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
                    if (!_dialogFilesInUse[x])
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
            if (string.IsNullOrWhiteSpace(globalID)) throw new ArgumentException(nameof(globalID), nameof(globalID) + " cannot be null, empty, or whitespace.");
            if (!_playerDialogs.ContainsKey(globalID)) throw new Exception(nameof(globalID) + " could not be found. Be sure to call " + nameof(LoadConversation) + " first.");

            return _playerDialogs[globalID];
        }

        public void RemovePlayerDialog(string globalID)
        {
            if (string.IsNullOrWhiteSpace(globalID)) throw new ArgumentException(nameof(globalID), nameof(globalID) + " cannot be null, empty, or whitespace.");

            PlayerDialog dialog = _playerDialogs[globalID];
            _dialogFilesInUse[dialog.DialogNumber] = false;

            _playerDialogs.Remove(globalID);
        }

        public void LoadConversation(NWPlayer player, NWObject talkTo, string @class, int dialogNumber)
        {
            if (player == null) throw new ArgumentNullException(nameof(player));
            if (player.Object == null) throw new ArgumentNullException(nameof(player.Object));
            if (talkTo == null) throw new ArgumentNullException(nameof(talkTo));
            if (talkTo.Object == null) throw new ArgumentNullException(nameof(talkTo.Object));
            if (string.IsNullOrWhiteSpace(@class)) throw new ArgumentException(nameof(@class), nameof(@class) + " cannot be null, empty, or whitespace.");
            if (dialogNumber < 1 || dialogNumber > NumberOfDialogs) throw new ArgumentOutOfRangeException(nameof(dialogNumber), nameof(dialogNumber) + " must be between 1 and " + NumberOfDialogs);

            ConversationBase convo = App.Resolve<ConversationBase>(@class);
            
            PlayerDialog dialog = convo.SetUp(player);
            if (dialog == null)
            {
                throw new NullReferenceException(nameof(dialog) + " cannot be null.");
            }

            if (dialogNumber > 0)
                dialog.DialogNumber = dialogNumber;

            dialog.ActiveDialogName = @class;
            dialog.DialogTarget = talkTo;
            StorePlayerDialog(player.GlobalID, dialog);
        }

        public void StartConversation(NWPlayer player, NWObject talkTo, string @class)
        {
            if (player == null) throw new ArgumentNullException(nameof(player));
            if (player.Object == null) throw new ArgumentNullException(nameof(player.Object));
            if (talkTo == null) throw new ArgumentNullException(nameof(talkTo));
            if (talkTo.Object == null) throw new ArgumentNullException(nameof(talkTo.Object));
            if (string.IsNullOrWhiteSpace(@class)) throw new ArgumentException(nameof(@class), nameof(@class) + " cannot be null, empty, or whitespace.");

            LoadConversation(player, talkTo, @class, -1);
            PlayerDialog dialog = _playerDialogs[player.GlobalID];

            // NPC conversations
            NWCreature talkToCreature = (NWCreature) talkTo;
            if (_.GetObjectType(talkTo.Object) == OBJECT_TYPE_CREATURE &&
                !talkToCreature.IsPlayer &&
                !talkToCreature.IsDM)
            {
                _.BeginConversation("dialog" + dialog.DialogNumber);
            }
            // Everything else
            else
            {
                player.AssignCommand(() => _.ActionStartConversation(talkTo.Object, "dialog" + dialog.DialogNumber));
            }
        }

        public void EndConversation(NWPlayer player)
        {
            if (player == null) throw new ArgumentNullException(nameof(player));

            PlayerDialog playerDialog = LoadPlayerDialog(player.GlobalID);
            playerDialog.IsEnding = true;
            StorePlayerDialog(player.GlobalID, playerDialog);
        }

    }
}
