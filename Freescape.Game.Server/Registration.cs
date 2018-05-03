using Freescape.Game.Server.Events;
using NWN.Plugin.Framework;

namespace Freescape.Game.Server
{
    public class Registration : IModuleRegistration
    {
        private App _app;
        
        public void OnRegisterPlugin()
        {
            _app = new App();
        }

        public void OnShutdown()
        {

        }

        public void OnModuleAcquireItem()
        {
            _app.RunEvent<OnModuleAcquireItem>();
        }

        public void OnModuleActivateItem()
        {
            _app.RunEvent<OnModuleActivateItem>();
        }

        public void OnModuleChat()
        {
            _app.RunEvent<OnModuleChat>();
        }

        public void OnModuleCutsceneAbort()
        {
            _app.RunEvent<OnModuleCutsceneAbort>();
        }

        public void OnModuleDeath()
        {
            _app.RunEvent<OnModuleDeath>();
        }

        public void OnModuleDying()
        {
            _app.RunEvent<OnModuleDying>();
        }

        public void OnModuleEnter()
        {
            _app.RunEvent<OnModuleEnter>();
        }

        public void OnModuleEquipItem()
        {
            _app.RunEvent<OnModuleEquipItem>();
        }

        public void OnModuleHeartbeat()
        {
            _app.RunEvent<OnModuleHeartbeat>();
        }

        public void OnModuleLeave()
        {
            _app.RunEvent<OnModuleLeave>();
        }

        public void OnModuleLevelUp()
        {
            _app.RunEvent<OnModuleLevelUp>();
        }

        public void OnModuleLoad()
        {
            _app.RunEvent<OnModuleLoad>();
        }

        public void OnModuleRespawn()
        {
            _app.RunEvent<OnModuleRespawn>();
        }

        public void OnModuleRest()
        {
            _app.RunEvent<OnModuleRest>();
        }

        public void OnModuleUnacquireItem()
        {
            _app.RunEvent<OnModuleUnacquireItem>();
        }

        public void OnModuleUnequipItem()
        {
            _app.RunEvent<OnModuleUnequipItem>();
        }

        public void OnModuleUserDefined()
        {
            _app.RunEvent<OnModuleUserDefined>();
        }
    }
}
