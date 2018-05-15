namespace Freescape.Game.Server.Event.Creature
{
    public class OnHeartbeat: IRegisteredEvent
    {
        public bool Run(params object[] args)
        {
            return true;
        }
    }
}
