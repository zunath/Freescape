namespace Freescape.Game.Server.Event.Creature
{
    public class OnDamaged: IRegisteredEvent
    {
        public bool Run(params object[] args)
        {
            return true;
        }
    }
}
