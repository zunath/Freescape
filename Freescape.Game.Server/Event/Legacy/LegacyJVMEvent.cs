using Freescape.Game.Server.GameObject;
using NWN;

namespace Freescape.Game.Server.Event.Legacy
{
    public class LegacyJVMEvent: IRegisteredEvent
    {
        public bool Run(params object[] args)
        {
            NWObject self = NWObject.Wrap(Object.OBJECT_SELF);
            string script = self.GetLocalString((string) args[0]);

            return true;
        }
    }
}
