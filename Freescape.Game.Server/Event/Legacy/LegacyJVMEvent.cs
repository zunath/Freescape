using System;
using Freescape.Game.Server.GameObject;
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
            App.RunEvent(type);

            return true;
        }
    }
}
