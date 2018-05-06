using NWN;

namespace Freescape.Game.Server.Event.Module
{
    internal class OnModuleLoad: IRegisteredEvent
    {
        private readonly INWScript _script;

        public OnModuleLoad(INWScript script)
        {
            _script = script;
        }

        public bool Run(params object[] args)
        {
            SetModuleEventScripts();
            SetAreaEventScripts();
            return true;
        }

        private void SetAreaEventScripts()
        {
            Object area = _script.GetFirstArea();
            while (_script.GetIsObjectValid(area) == NWScript.TRUE)
            {
                _script.SetEventScript(area, NWScript.EVENT_SCRIPT_AREA_ON_ENTER, "area_on_enter");
                _script.SetEventScript(area, NWScript.EVENT_SCRIPT_AREA_ON_EXIT, "area_on_exit");
                _script.SetEventScript(area, NWScript.EVENT_SCRIPT_AREA_ON_HEARTBEAT, "area_on_hb");
                _script.SetEventScript(area, NWScript.EVENT_SCRIPT_AREA_ON_USER_DEFINED_EVENT, "area_on_user");

                area = _script.GetNextArea();
            }
        }

        private void SetModuleEventScripts()
        {
            _script.SetEventScript(_script.GetModule(), NWScript.EVENT_SCRIPT_MODULE_ON_ACQUIRE_ITEM, "mod_on_acquire");
            _script.SetEventScript(_script.GetModule(), NWScript.EVENT_SCRIPT_MODULE_ON_ACTIVATE_ITEM, "mod_on_activate");
            _script.SetEventScript(_script.GetModule(), NWScript.EVENT_SCRIPT_MODULE_ON_CLIENT_ENTER, "mod_on_enter");
            _script.SetEventScript(_script.GetModule(), NWScript.EVENT_SCRIPT_MODULE_ON_CLIENT_EXIT, "mod_on_leave");
            _script.SetEventScript(_script.GetModule(), NWScript.EVENT_SCRIPT_MODULE_ON_PLAYER_CANCEL_CUTSCENE, "mod_on_csabort");
            _script.SetEventScript(_script.GetModule(), NWScript.EVENT_SCRIPT_MODULE_ON_HEARTBEAT, "mod_on_heartbeat");
            _script.SetEventScript(_script.GetModule(), NWScript.EVENT_SCRIPT_MODULE_ON_PLAYER_CHAT, "mod_on_chat");
            _script.SetEventScript(_script.GetModule(), NWScript.EVENT_SCRIPT_MODULE_ON_PLAYER_DEATH, "mod_on_death");
            _script.SetEventScript(_script.GetModule(), NWScript.EVENT_SCRIPT_MODULE_ON_PLAYER_DYING, "mod_on_dying");
            _script.SetEventScript(_script.GetModule(), NWScript.EVENT_SCRIPT_MODULE_ON_EQUIP_ITEM, "mod_on_equip");
            _script.SetEventScript(_script.GetModule(), NWScript.EVENT_SCRIPT_MODULE_ON_PLAYER_LEVEL_UP, "mod_on_levelup");
            _script.SetEventScript(_script.GetModule(), NWScript.EVENT_SCRIPT_MODULE_ON_RESPAWN_BUTTON_PRESSED, "mod_on_respawn");
            _script.SetEventScript(_script.GetModule(), NWScript.EVENT_SCRIPT_MODULE_ON_PLAYER_REST, "mod_on_rest");
            _script.SetEventScript(_script.GetModule(), NWScript.EVENT_SCRIPT_MODULE_ON_UNEQUIP_ITEM, "mod_on_unequip");
            _script.SetEventScript(_script.GetModule(), NWScript.EVENT_SCRIPT_MODULE_ON_LOSE_ITEM, "mod_on_unacquire");
            _script.SetEventScript(_script.GetModule(), NWScript.EVENT_SCRIPT_MODULE_ON_USER_DEFINED_EVENT, "mod_on_user");
        }
    }
}
