namespace Freescape.Game.Server.Event.Creature
{
    public class OnRested: IRegisteredEvent
    {
        public bool Run(params object[] args)
        {
            return true;
        }
    }
}
