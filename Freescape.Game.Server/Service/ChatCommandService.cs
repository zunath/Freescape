using System;
using Freescape.Game.Server.ChatCommands.Contracts;
using Freescape.Game.Server.GameObject;
using Freescape.Game.Server.NWNX.Contracts;
using Freescape.Game.Server.Service.Contracts;

namespace Freescape.Game.Server.Service
{
    public class ChatCommandService: IChatCommandService
    {
        private readonly INWNXChat _nwnxChat;
        private readonly IColorTokenService _color;

        public ChatCommandService(INWNXChat nwnxChat, IColorTokenService color)
        {
            _nwnxChat = nwnxChat;
            _color = color;
        }

        public void OnModuleNWNXChat(NWPlayer sender)
        {
            if (!sender.IsPlayer || sender.IsDM) return;

            string message = _nwnxChat.GetMessage().Trim().ToLower();

            // If is double slash (//) treat it as a normal message (this is used by role-players to denote OOC speech)
            if (message.Substring(0, 2) == "//") return;

            if (message.Substring(0, 1) != "/")
            {
                return;
            }

            string command = message.Substring(1, message.Length);
            command = command.Substring(0, 1).ToUpper() + command.Substring(1);
            _nwnxChat.SkipMessage();

            IChatCommand chatCommand = App.Resolve<IChatCommand>(command);
            if (chatCommand == null || !chatCommand.CanUse(sender))
            {
                sender.SendMessage(_color.Red("Command not found."));
                return;
            }

            chatCommand.DoAction(sender);
        }
    }
}
