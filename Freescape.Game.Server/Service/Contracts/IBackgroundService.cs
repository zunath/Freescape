using System.Collections.Generic;
using Freescape.Game.Server.Data;
using Freescape.Game.Server.GameObject;

namespace Freescape.Game.Server.Service.Contracts
{
    public interface IBackgroundService
    {
        IEnumerable<Background> GetActiveBackgrounds();
        void SetPlayerBackground(NWPlayer player, Background background);
    }
}
