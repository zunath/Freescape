namespace Freescape.Game.Server.Event.Module
{
    internal class OnModuleUnequipItem : IRegisteredEvent
    {
        public bool Run(params object[] args)
        {
            return true;

        }
    }
}
