namespace Freescape.Game.Server.GameObject.Contracts
{
    public interface INWPlayer
    {
        string GlobalID { get; }
        bool IsBusy { get; set; }
        bool IsInitialized { get; }

        void Initialize();
    }
}