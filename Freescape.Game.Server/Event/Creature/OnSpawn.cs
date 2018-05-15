namespace Freescape.Game.Server.Event.Creature
{
    public class OnSpawn: IRegisteredEvent
    {
        public bool Run(params object[] args)
        {
            return true;
        }
    }
}
