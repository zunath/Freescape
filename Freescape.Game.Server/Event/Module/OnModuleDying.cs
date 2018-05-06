namespace Freescape.Game.Server.Event.Module
{
    internal class OnModuleDying : IRegisteredEvent
    {
        public bool Run(params object[] args)
        {
            return true;

        }
    }
}
