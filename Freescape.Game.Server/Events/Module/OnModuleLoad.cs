using Freescape.Game.Server.Events.Contracts;
using NWN;
using static NWN.NWScript;

namespace Freescape.Game.Server.Events.Module
{
    internal class OnModuleLoad: IRegisteredEvent
    {
        public void Run()
        {
            SetModuleEventScripts();
            SetAreaEventScripts();
        }

        private static void SetAreaEventScripts()
        {
            Object area = GetFirstArea();
            while (GetIsObjectValid(area) == TRUE)
            {
                SetEventScript(area, EVENT_SCRIPT_AREA_ON_ENTER, "area_on_enter");
                SetEventScript(area, EVENT_SCRIPT_AREA_ON_EXIT, "area_on_exit");
                SetEventScript(area, EVENT_SCRIPT_AREA_ON_HEARTBEAT, "area_on_hb");
                SetEventScript(area, EVENT_SCRIPT_AREA_ON_USER_DEFINED_EVENT, "area_on_user");

                area = GetNextArea();
            }
        }

        private static void SetModuleEventScripts()
        {
            SetEventScript(GetModule(), EVENT_SCRIPT_MODULE_ON_ACQUIRE_ITEM, "mod_on_acquire");
            SetEventScript(GetModule(), EVENT_SCRIPT_MODULE_ON_ACTIVATE_ITEM, "mod_on_activate");
            SetEventScript(GetModule(), EVENT_SCRIPT_MODULE_ON_CLIENT_ENTER, "mod_on_enter");
            SetEventScript(GetModule(), EVENT_SCRIPT_MODULE_ON_CLIENT_EXIT, "mod_on_leave");
            SetEventScript(GetModule(), EVENT_SCRIPT_MODULE_ON_PLAYER_CANCEL_CUTSCENE, "mod_on_csabort");
            SetEventScript(GetModule(), EVENT_SCRIPT_MODULE_ON_HEARTBEAT, "mod_on_heartbeat");
            SetEventScript(GetModule(), EVENT_SCRIPT_MODULE_ON_PLAYER_CHAT, "mod_on_chat");
            SetEventScript(GetModule(), EVENT_SCRIPT_MODULE_ON_PLAYER_DEATH, "mod_on_death");
            SetEventScript(GetModule(), EVENT_SCRIPT_MODULE_ON_PLAYER_DYING, "mod_on_dying");
            SetEventScript(GetModule(), EVENT_SCRIPT_MODULE_ON_EQUIP_ITEM, "mod_on_equip");
            SetEventScript(GetModule(), EVENT_SCRIPT_MODULE_ON_PLAYER_LEVEL_UP, "mod_on_levelup");
            SetEventScript(GetModule(), EVENT_SCRIPT_MODULE_ON_RESPAWN_BUTTON_PRESSED, "mod_on_respawn");
            SetEventScript(GetModule(), EVENT_SCRIPT_MODULE_ON_PLAYER_REST, "mod_on_rest");
            SetEventScript(GetModule(), EVENT_SCRIPT_MODULE_ON_UNEQUIP_ITEM, "mod_on_unequip");
            SetEventScript(GetModule(), EVENT_SCRIPT_MODULE_ON_LOSE_ITEM, "mod_on_unacquire");
            SetEventScript(GetModule(), EVENT_SCRIPT_MODULE_ON_USER_DEFINED_EVENT, "mod_on_user");
        }
    }
}
