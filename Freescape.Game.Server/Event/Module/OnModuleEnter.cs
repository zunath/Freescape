namespace Freescape.Game.Server.Event.Module
{
    internal class OnModuleEnter : IRegisteredEvent
    {
        public bool Run(params object[] args)
        {
            return true;

        }
    }
}
