namespace Freescape.Game.Server.Event.Module
{
    internal class OnModuleDeath : IRegisteredEvent
    {
        public bool Run(params object[] args)
        {
            return true;

        }
    }
}
