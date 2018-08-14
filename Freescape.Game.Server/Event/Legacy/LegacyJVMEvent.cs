using System;
using Freescape.Game.Server.GameObject;
using Freescape.Game.Server.Service.Contracts;
using Object = NWN.Object;

namespace Freescape.Game.Server.Event.Legacy
{
    public class LegacyJVMEvent: IRegisteredEvent
    {
        public bool Run(params object[] args)
        {
            NWObject self = NWObject.Wrap(Object.OBJECT_SELF);
            string script = self.GetLocalString((string) args[0]);

            Type type = Type.GetType(script);

            if (type == null)
            {
                Console.WriteLine("Unable to locate type for LegacyJVMEvent: " + script);
                return false;
            }

            App.RunEvent(type);

            return true;
        }
    }
}
