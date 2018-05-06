namespace Freescape.Game.Server.Event.Module
{
    internal class OnModuleActivateItem : IRegisteredEvent
    {
        public bool Run(params object[] args)
        {
            return true;

        }
    }
}
