using Freescape.Game.Server.GameObject;

namespace Freescape.Game.Server.NWNX.Contracts
{
    public interface INWNXPlayer
    {
        void ForcePlaceableExamineWindow(NWPlayer player, NWPlaceable placeable);
        void StopGuiTimingBar(NWObject player, string script, int id);
        void StartGuiTimingBar(NWObject player, float seconds, string script);
        void StopGuiTimingBar(NWObject player, string script);
        void SetAlwaysWalk(NWObject player, int bWalk);
        QuickBarSlot NWNX_Player_GetQuickBarSlot(NWObject player, int slot);
        void SetQuickBarSlot(NWObject player, int slot, QuickBarSlot qbs);
    }
}