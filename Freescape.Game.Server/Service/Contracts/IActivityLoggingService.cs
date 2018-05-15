namespace Freescape.Game.Server.Service.Contracts
{
    public interface IActivityLoggingService
    {
        void OnModuleClientEnter();
        void OnModuleClientLeave();
    }
}
