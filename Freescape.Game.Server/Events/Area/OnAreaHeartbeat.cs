using System;
using Freescape.Game.Server.Events.Contracts;
using static NWN.NWScript;
using Object = NWN.Object;

namespace Freescape.Game.Server.Events.Area
{
    internal class OnAreaHeartbeat: IRegisteredEvent
    {
        public void Run()
        {
            Console.WriteLine("Hello from " + GetName(Object.OBJECT_SELF));
        }
    }
}
