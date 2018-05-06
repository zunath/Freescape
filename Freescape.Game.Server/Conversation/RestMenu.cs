using Freescape.Game.Server.Conversation.Contracts;
using Freescape.Game.Server.GameObject;
using Freescape.Game.Server.ValueObject.Dialog;

namespace Freescape.Game.Server.Conversation
{
    internal class RestMenu: IConversation
    {
        public PlayerDialog SetUp(NWPlayer player)
        {
            return null;
        }

        public void Initialize()
        {
        }

        public void DoAction(NWPlayer player, string pageName, int responseID)
        {
        }

        public void EndDialog()
        {
        }
    }
}
