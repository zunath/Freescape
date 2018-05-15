namespace Freescape.Game.Server.Event.Creature
{
    public class OnPerception: IRegisteredEvent
    {
        public bool Run(params object[] args)
        {
            return true;
        }
    }
}
