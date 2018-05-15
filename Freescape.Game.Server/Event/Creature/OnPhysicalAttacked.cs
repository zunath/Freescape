namespace Freescape.Game.Server.Event.Creature
{
    public class OnPhysicalAttacked: IRegisteredEvent
    {
        public bool Run(params object[] args)
        {
            return true;
        }
    }
}
