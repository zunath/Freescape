namespace Freescape.Game.Server.Events
{
    internal interface IRegisteredEvent
    {
        void Run(params object[] args);
    }
}
