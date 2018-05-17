using Freescape.Game.Server.Data;
using Freescape.Game.Server.GameObject;
using Freescape.Game.Server.Service.Contracts;
using Freescape.Game.Server.ValueObject.GameObject;

namespace Freescape.Game.Server.Service
{
    public class QuestService: IQuestService
    {
        public Quest GetQuestByID(int questID)
        {
            return null;
        }

        public ItemVO GetTempItemInformation(string resref, int quantity)
        {
            return null;
        }

        public void CompleteQuest(NWPlayer player, int questID, ItemVO selectedItem)
        {
        }

        public void OnModuleItemAcquired()
        {
        }

        public void OnClientEnter()
        {
        }
    }
}
