using Freescape.Game.Server.GameObject.Contracts;
using NWN;

namespace Freescape.Game.Server.GameObject
{
    public class NWArea: NWObject
    {
        public NWArea(INWScript script) : base(script)
        {
        }

        public new static NWArea Wrap(Object @object)
        {
            var obj = (NWArea)App.Resolve<INWObject>();
            obj.Object = @object;

            return obj;
        }
    }
}
