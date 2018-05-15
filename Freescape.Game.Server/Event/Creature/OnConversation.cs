namespace Freescape.Game.Server.Event.Creature
{
    public class OnConversation: IRegisteredEvent
    {
        public bool Run(params object[] args)
        {
            return true;
        }
    }
}
