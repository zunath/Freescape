namespace Freescape.Game.Server.Event.Module
{
    internal class OnModuleLeave : IRegisteredEvent
    {
        public bool Run(params object[] args)
        {
            return true;

        }
    }
}
