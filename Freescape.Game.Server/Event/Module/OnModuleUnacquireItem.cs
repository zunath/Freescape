namespace Freescape.Game.Server.Event.Module
{
    internal class OnModuleUnacquireItem : IRegisteredEvent
    {
        public bool Run(params object[] args)
        {
            return true;

        }
    }
}
