using Freescape.Game.Server.GameObject;
using NWN;

namespace Freescape.Game.Server.Perk
{
    public abstract class PerkBase: IPerk
    {
        protected INWScript _;

        protected PerkBase(INWScript script)
        {
            _ = script;
        }

        public abstract bool CanCastSpell(NWPlayer oPC, NWObject oTarget);
        public abstract string CannotCastSpellMessage();
        public abstract int ManaCost(NWPlayer oPC, int baseManaCost);
        public abstract float CastingTime(NWPlayer oPC, float baseCastingTime);
        public abstract float CooldownTime(NWPlayer oPC, float baseCooldownTime);
        public abstract void OnImpact(NWPlayer oPC, NWObject oTarget);
        public abstract void OnPurchased(NWPlayer oPC, int newLevel);
        public abstract void OnRemoved(NWPlayer oPC);
        public abstract void OnItemEquipped(NWPlayer oPC, NWItem oItem);
        public abstract void OnItemUnequipped(NWPlayer oPC, NWItem oItem);
        public abstract bool IsHostile();
    }
}
