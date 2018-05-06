namespace Freescape.Game.Server.Event.Area
{
    internal class OnAreaEnter: IRegisteredEvent
    {
        public bool Run(params object[] args)
        {
            return true;
        }
    }
}
