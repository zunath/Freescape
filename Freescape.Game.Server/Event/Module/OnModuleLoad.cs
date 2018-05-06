using NWN;

namespace Freescape.Game.Server.Event.Module
{
    internal class OnModuleLoad: IRegisteredEvent
    {
        public bool Run(params object[] args)
        {
            SetModuleEventScripts();
            SetAreaEventScripts();
            return true;
        }

        private static void SetAreaEventScripts()
        {
            Object area = NWScript.GetFirstArea();
            while (NWScript.GetIsObjectValid(area) == NWScript.TRUE)
            {
                NWScript.SetEventScript(area, NWScript.EVENT_SCRIPT_AREA_ON_ENTER, "area_on_enter");
                NWScript.SetEventScript(area, NWScript.EVENT_SCRIPT_AREA_ON_EXIT, "area_on_exit");
                NWScript.SetEventScript(area, NWScript.EVENT_SCRIPT_AREA_ON_HEARTBEAT, "area_on_hb");
                NWScript.SetEventScript(area, NWScript.EVENT_SCRIPT_AREA_ON_USER_DEFINED_EVENT, "area_on_user");

                area = NWScript.GetNextArea();
            }
        }

        private static void SetModuleEventScripts()
        {
            NWScript.SetEventScript(NWScript.GetModule(), NWScript.EVENT_SCRIPT_MODULE_ON_ACQUIRE_ITEM, "mod_on_acquire");
            NWScript.SetEventScript(NWScript.GetModule(), NWScript.EVENT_SCRIPT_MODULE_ON_ACTIVATE_ITEM, "mod_on_activate");
            NWScript.SetEventScript(NWScript.GetModule(), NWScript.EVENT_SCRIPT_MODULE_ON_CLIENT_ENTER, "mod_on_enter");
            NWScript.SetEventScript(NWScript.GetModule(), NWScript.EVENT_SCRIPT_MODULE_ON_CLIENT_EXIT, "mod_on_leave");
            NWScript.SetEventScript(NWScript.GetModule(), NWScript.EVENT_SCRIPT_MODULE_ON_PLAYER_CANCEL_CUTSCENE, "mod_on_csabort");
            NWScript.SetEventScript(NWScript.GetModule(), NWScript.EVENT_SCRIPT_MODULE_ON_HEARTBEAT, "mod_on_heartbeat");
            NWScript.SetEventScript(NWScript.GetModule(), NWScript.EVENT_SCRIPT_MODULE_ON_PLAYER_CHAT, "mod_on_chat");
            NWScript.SetEventScript(NWScript.GetModule(), NWScript.EVENT_SCRIPT_MODULE_ON_PLAYER_DEATH, "mod_on_death");
            NWScript.SetEventScript(NWScript.GetModule(), NWScript.EVENT_SCRIPT_MODULE_ON_PLAYER_DYING, "mod_on_dying");
            NWScript.SetEventScript(NWScript.GetModule(), NWScript.EVENT_SCRIPT_MODULE_ON_EQUIP_ITEM, "mod_on_equip");
            NWScript.SetEventScript(NWScript.GetModule(), NWScript.EVENT_SCRIPT_MODULE_ON_PLAYER_LEVEL_UP, "mod_on_levelup");
            NWScript.SetEventScript(NWScript.GetModule(), NWScript.EVENT_SCRIPT_MODULE_ON_RESPAWN_BUTTON_PRESSED, "mod_on_respawn");
            NWScript.SetEventScript(NWScript.GetModule(), NWScript.EVENT_SCRIPT_MODULE_ON_PLAYER_REST, "mod_on_rest");
            NWScript.SetEventScript(NWScript.GetModule(), NWScript.EVENT_SCRIPT_MODULE_ON_UNEQUIP_ITEM, "mod_on_unequip");
            NWScript.SetEventScript(NWScript.GetModule(), NWScript.EVENT_SCRIPT_MODULE_ON_LOSE_ITEM, "mod_on_unacquire");
            NWScript.SetEventScript(NWScript.GetModule(), NWScript.EVENT_SCRIPT_MODULE_ON_USER_DEFINED_EVENT, "mod_on_user");
        }
    }
}
