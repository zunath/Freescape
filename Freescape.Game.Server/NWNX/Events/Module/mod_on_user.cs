﻿using Freescape.Game.Server;
using Freescape.Game.Server.Events.Module;


// ReSharper disable once CheckNamespace
namespace NWN.Scripts
{
#pragma warning disable IDE1006 // Naming Styles
    internal class mod_on_user
#pragma warning restore IDE1006 // Naming Styles
    {
        // ReSharper disable once UnusedMember.Local
        private static void Main()
        {
            App.RunEvent<OnModuleUserDefined>();
        }
    }
}
