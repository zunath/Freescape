using Freescape.Game.Server.Data.Entities;
using Freescape.Game.Server.GameObject;
using Freescape.Game.Server.ValueObject.GameObject;

namespace Freescape.Game.Server.Service.Contracts
{
    public interface IQuestService
    {
        Quest GetQuestByID(int questID);
        ItemVO GetTempItemInformation(string resref, int quantity);
        void CompleteQuest(NWPlayer player, int questID, ItemVO selectedItem);
        void OnModuleItemAcquired();
        void OnClientEnter();
    }
}
