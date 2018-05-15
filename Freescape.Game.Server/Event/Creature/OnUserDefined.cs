namespace Freescape.Game.Server.Event.Creature
{
    public class OnUserDefined: IRegisteredEvent
    {
        public bool Run(params object[] args)
        {
            return true;
        }
    }
}
