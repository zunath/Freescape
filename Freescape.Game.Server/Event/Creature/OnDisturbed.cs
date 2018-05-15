namespace Freescape.Game.Server.Event.Creature
{
    public class OnDisturbed: IRegisteredEvent
    {
        public bool Run(params object[] args)
        {
            return true;
        }
    }
}
