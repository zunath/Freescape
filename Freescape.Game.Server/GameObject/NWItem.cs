using NWN;

namespace Freescape.Game.Server.GameObject
{
    public class NWItem : NWObject
    {
        private readonly INWScript _script;

        public NWItem(INWScript script)
            : base(script)
        {
            _script = script;
        }

        public NWObject Possessor => _script.GetItemPossessor(this) as NWObject;

        public int BaseItemType => _script.GetBaseItemType(this);

        public bool IsDroppable
        {
            get => _script.GetDroppableFlag(this) == 1;
            set => _script.SetDroppableFlag(this, value ? 1 : 0);
        }

        public bool IsCursed
        {
            get => _script.GetItemCursedFlag(this) == 1;
            set => _script.SetItemCursedFlag(this, value ? 1 : 0);
        }

        public bool IsStolen
        {
            get => _script.GetStolenFlag(this) == 1;
            set => _script.SetStolenFlag(this, value ? 1 : 0);
        }

        public int AC => _script.GetItemACValue(this);

        public int Charges
        {
            get => _script.GetItemCharges(this);
            set => _script.SetItemCharges(this, value);
        }

        public int StackSize
        {
            get => _script.GetItemStackSize(this);
            set => _script.SetItemStackSize(this, value);
        }

        public float Weight => _script.GetWeight(this) * 0.1f;
    }
}
