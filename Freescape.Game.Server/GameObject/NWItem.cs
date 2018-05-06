using Freescape.Game.Server.GameObject.Contracts;
using NWN;

namespace Freescape.Game.Server.GameObject
{
    public class NWItem : NWObject, INWItem
    {
        private readonly INWScript _script;

        public NWItem(INWScript script)
            : base(script)
        {
            _script = script;
        }

        public new static NWItem Wrap(Object @object)
        {
            var obj = (NWItem)App.Resolve<INWItem>();
            obj.Object = @object;

            return obj;
        }

        public NWCreature Possessor => GameObject.NWCreature.Wrap(_script.GetItemPossessor(Object));

        public int BaseItemType => _script.GetBaseItemType(Object);

        public bool IsDroppable
        {
            get => _script.GetDroppableFlag(Object) == 1;
            set => _script.SetDroppableFlag(Object, value ? 1 : 0);
        }

        public bool IsCursed
        {
            get => _script.GetItemCursedFlag(Object) == 1;
            set => _script.SetItemCursedFlag(Object, value ? 1 : 0);
        }

        public bool IsStolen
        {
            get => _script.GetStolenFlag(Object) == 1;
            set => _script.SetStolenFlag(Object, value ? 1 : 0);
        }

        public int AC => _script.GetItemACValue(Object);

        public int Charges
        {
            get => _script.GetItemCharges(Object);
            set => _script.SetItemCharges(Object, value);
        }

        public int StackSize
        {
            get => _script.GetItemStackSize(Object);
            set => _script.SetItemStackSize(Object, value);
        }

        public float Weight => _script.GetWeight(Object) * 0.1f;
    }
}
