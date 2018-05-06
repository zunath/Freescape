using System;
using NWN;

namespace Freescape.Game.Server.Event.Module
{
    internal class OnModuleHeartbeat : IRegisteredEvent
    {
        public bool Run(params object[] args)
        {
            return true;

        }
    }
}
