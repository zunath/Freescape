namespace Freescape.Game.Server.Event.Module
{
    internal class OnModuleChat : IRegisteredEvent
    {
        public bool Run(params object[] args)
        {
            return true;

        }
    }
}
