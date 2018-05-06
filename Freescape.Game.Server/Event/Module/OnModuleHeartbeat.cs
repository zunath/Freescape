using System;
using NWN;

namespace Freescape.Game.Server.Event.Module
{
    internal class OnModuleHeartbeat : IRegisteredEvent
    {
        public bool Run(params object[] args)
        {
            var nwscript = new NWScript();

            Console.WriteLine(nwscript.Random(10)); // todo debug

            return true;

        }
    }
}
