using System;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Net;
using System.Reflection;
using Freescape.Game.Server.Data;
using Freescape.Game.Server.Data.Entities;
using NWN.Plugin.Framework;

namespace Freescape.Game.Server
{
    public class Registration : IModuleRegistration
    {
        public void OnRegisterPlugin()
        {

        }

        public void OnShutdown()
        {

        }

        public void OnModuleAcquireItem()
        {

        }

        public void OnModuleActivateItem()
        {

        }

        public void OnModuleChat()
        {

        }

        public void OnModuleCutsceneAbort()
        {

        }

        public void OnModuleDeath()
        {

        }

        public void OnModuleDying()
        {

        }

        public void OnModuleEnter()
        {

        }

        public void OnModuleEquipItem()
        {

        }

        public void OnModuleHeartbeat()
        {

        }

        public void OnModuleLeave()
        {

        }

        public void OnModuleLevelUp()
        {

        }

        public void OnModuleLoad()
        {
            using (DataContext context = new DataContext())
            {
                var record = context
                    .Single<PlayerCharacter>("Player/GetByPlayerID",
                        new SqlParameter("@playerID", "61db91be-7482-40c3-8710-e8995012e509"));

                Console.WriteLine(record.CharacterName);

            }
        }

        public void OnModuleRespawn()
        {

        }

        public void OnModuleRest()
        {

        }

        public void OnModuleUnacquireItem()
        {

        }

        public void OnModuleUnequipItem()
        {

        }

        public void OnModuleUserDefined()
        {

        }
    }
}
