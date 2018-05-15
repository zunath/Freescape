using System.Collections.Generic;
using Freescape.Game.Server.Data;
using Freescape.Game.Server.GameObject.Contracts;

namespace Freescape.Game.Server.Service.Contracts
{
    public interface IBackgroundService
    {
        IEnumerable<Background> GetActiveBackgrounds();
        void SetPlayerBackground(INWPlayer player, Background background);
        void OnModuleClientEnter();
    }
}
