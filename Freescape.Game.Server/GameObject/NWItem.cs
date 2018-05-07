using System;
using Freescape.Game.Server.GameObject.Contracts;
using Freescape.Game.Server.Service.Contracts;
using NWN;
using Object = NWN.Object;

namespace Freescape.Game.Server.GameObject
{
    public class NWItem : NWObject, INWItem
    {
        private readonly INWScript _;
        private readonly IDurabilityService _durability;

        public NWItem(INWScript script,
            IDurabilityService durability)
            : base(script)
        {
            _ = script;
            _durability = durability;
        }

        public new static NWItem Wrap(Object @object)
        {
            var obj = (NWItem)App.Resolve<INWItem>();
            obj.Object = @object;
            
            return obj;
        }

        public NWCreature Possessor => NWCreature.Wrap(_.GetItemPossessor(Object));

        public int BaseItemType => _.GetBaseItemType(Object);

        public bool IsDroppable
        {
            get => _.GetDroppableFlag(Object) == 1;
            set => _.SetDroppableFlag(Object, value ? 1 : 0);
        }

        public bool IsCursed
        {
            get => _.GetItemCursedFlag(Object) == 1;
            set => _.SetItemCursedFlag(Object, value ? 1 : 0);
        }

        public bool IsStolen
        {
            get => _.GetStolenFlag(Object) == 1;
            set => _.SetStolenFlag(Object, value ? 1 : 0);
        }

        public int AC => _.GetItemACValue(Object);

        public int Charges
        {
            get => _.GetItemCharges(Object);
            set => _.SetItemCharges(Object, value);
        }

        public int StackSize
        {
            get => _.GetItemStackSize(Object);
            set => _.SetItemStackSize(Object, value);
        }

        public float Weight => _.GetWeight(Object) * 0.1f;
        
        public float MaxDurability
        {
            get => _durability.GetMaxDurability(this);
            set => _durability.SetMaxDurability(this, value);
        }

        public float Durability
        {
            get => _durability.GetDurability(this);
            set => _durability.SetDurability(this, value);
        }
    }
}
