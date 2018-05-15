namespace Freescape.Game.Server.Event.Creature
{
    public class OnBlocked: IRegisteredEvent
    {
        public bool Run(params object[] args)
        {
            return true;
        }
    }
}
