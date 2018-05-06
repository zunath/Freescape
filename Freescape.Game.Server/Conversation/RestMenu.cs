using Freescape.Game.Server.Conversation.Contracts;
using Freescape.Game.Server.GameObject;
using Freescape.Game.Server.ValueObject.Dialog;

namespace Freescape.Game.Server.Conversation
{
    internal class RestMenu: IConversation
    {
        public PlayerDialog SetUp(NWPlayer player)
        {
            PlayerDialog dialog = new PlayerDialog("MainPage");
            
            DialogPage page = new DialogPage("This is a test", 
                "Option 1",
                "Option 2");

            dialog.AddPage("MainPage", page);
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
