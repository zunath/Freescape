using Freescape.Game.Server.GameObject;

namespace Freescape.Game.Server.Service.Contracts
{
    public interface IDurabilityService
    {
        bool IsValidDurabilityType(NWItem item);
        float GetMaxDurability(NWItem item);
        void SetMaxDurability(NWItem item, float value);
        float GetDurability(NWItem item);
        void SetDurability(NWItem item, float value);
        string OnModuleExamine(string existingDescription, NWObject examinedObject);
        void RunItemDecay(NWPlayer oPC, NWItem oItem, float reduceAmount);
    }
}