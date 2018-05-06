using NWN;

namespace Freescape.Game.Server.GameObject
{
    public class NWItem : NWObject
    {
        public NWObject Possessor => NWScript.GetItemPossessor(this) as NWObject;

        public int BaseItemType => NWScript.GetBaseItemType(this);

        public bool IsDroppable
        {
            get => NWScript.GetDroppableFlag(this) == 1;
            set => NWScript.SetDroppableFlag(this, value ? 1 : 0);
        }

        public bool IsCursed
        {
            get => NWScript.GetItemCursedFlag(this) == 1;
            set => NWScript.SetItemCursedFlag(this, value ? 1 : 0);
        }

        public bool IsStolen
        {
            get => NWScript.GetStolenFlag(this) == 1;
            set => NWScript.SetStolenFlag(this, value ? 1 : 0);
        }

        public int AC => NWScript.GetItemACValue(this);

        public int Charges
        {
            get => NWScript.GetItemCharges(this);
            set => NWScript.SetItemCharges(this, value);
        }

        public int StackSize
        {
            get => NWScript.GetItemStackSize(this);
            set => NWScript.SetItemStackSize(this, value);
        }

        public float Weight => NWScript.GetWeight(this) * 0.1f;
    }
}
