using System.Linq;
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

            // If it is double slash (//) treat it as a normal message (this is used by role-players to denote OOC speech)
            if (message.Substring(0, 2) == "//") return;

            if (message.Substring(0, 1) != "/")
            {
                return;
            }

            var split = message.Split(' ').ToList();

            // Commands with no arguments won't be split, so if we didn't split anything then add the command to the split list manually.
            if (split.Count <= 0)
                split.Add(message);
            
            string command = split[0].Substring(1, split[0].Length-1);
            _nwnxChat.SkipMessage();

            if (!App.IsInterfaceKeyRegistered<IChatCommand>("ChatCommands." + command))
            {
                sender.SendMessage(_color.Red("Invalid chat command."));
                return;
            }

            IChatCommand chatCommand = App.ResolveByInterface<IChatCommand>("ChatCommands." + command);
            if (!chatCommand.CanUse(sender))
            {
                sender.SendMessage(_color.Red("Invalid chat command."));
                return;
            }

            split.RemoveAt(0);
            chatCommand.DoAction(sender, split.ToArray());
        }
    }
}
