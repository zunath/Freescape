using Freescape.Game.Server.GameObject.Contracts;
using Freescape.Game.Server.NWNX.Contracts;
using NWN;
using static NWN.NWScript;
using Object = NWN.Object;

namespace Freescape.Game.Server.GameObject
{
    public class NWCreature : NWObject, INWCreature
    {
        private readonly INWNXCreature _nwnxCreature;

        public NWCreature(INWScript script,
            INWNXCreature creature)
            : base(script)
        {
            _nwnxCreature = creature;
        }


        public new static NWCreature Wrap(Object @object)
        {
            NWCreature obj = (NWCreature)App.Resolve<INWCreature>();
            obj.Object = @object;

            return obj;
        }

        public virtual int Age => _.GetAge(Object);

        public virtual float ChallengeRating => _.GetChallengeRating(Object);

        public virtual int Class1 => _.GetClassByPosition(1, Object);

        public virtual int Class2 => _.GetClassByPosition(2, Object);

        public virtual int Class3 => _.GetClassByPosition(3, Object);

        public virtual bool IsCommandable
        {
            get => _.GetCommandable(Object) == 1;
            set => _.SetCommandable(value ? 1 : 0, Object);
        }

        public virtual int Size => _.GetCreatureSize(Object);

        public virtual int Phenotype
        {
            get => _.GetPhenoType(Object);
            set => _.SetPhenoType(value, Object);
        }

        public virtual string Deity
        {
            get => _.GetDeity(Object);
            set => _.SetDeity(Object, value);
        }

        public virtual int RacialType => _.GetRacialType(Object);

        public virtual int Gender => _.GetGender(Object);

        public virtual bool IsPlayer => _.GetIsPC(Object) == 1 && _.GetIsDM(Object) == 0 && _.GetIsDMPossessed(Object) == 0;

        public virtual bool IsDM => _.GetIsPC(Object) == 0 && (_.GetIsDM(Object) == 1 || _.GetIsDMPossessed(Object) == 1);

        public virtual bool IsResting => _.GetIsResting(Object) == 1;

        public virtual float Weight => _.GetWeight(Object) * 0.1f;

        public virtual int Strength
        {
            get => _.GetAbilityScore(Object, ABILITY_STRENGTH);
            set => _nwnxCreature.SetRawAbilityScore(this, ABILITY_STRENGTH, value);
        }
        public virtual int Dexterity
        {
            get => _.GetAbilityScore(Object, ABILITY_DEXTERITY);
            set => _nwnxCreature.SetRawAbilityScore(this, ABILITY_DEXTERITY, value);
        }
        public virtual int Constitution
        {
            get => _.GetAbilityScore(Object, ABILITY_CONSTITUTION);
            set => _nwnxCreature.SetRawAbilityScore(this, ABILITY_CONSTITUTION, value);
        }
        public virtual int Wisdom
        {
            get => _.GetAbilityScore(Object, ABILITY_WISDOM);
            set => _nwnxCreature.SetRawAbilityScore(this, ABILITY_WISDOM, value);
        }
        public virtual int Intelligence
        {
            get => _.GetAbilityScore(Object, ABILITY_INTELLIGENCE);
            set => _nwnxCreature.SetRawAbilityScore(this, ABILITY_INTELLIGENCE, value);
        }
        public virtual int Charisma
        {
            get => _.GetAbilityScore(Object, ABILITY_CHARISMA);
            set => _nwnxCreature.SetRawAbilityScore(this, ABILITY_CHARISMA, value);
        }

        public virtual int StrengthModifier => _.GetAbilityModifier(ABILITY_STRENGTH, Object);
        public virtual int DexterityModifier => _.GetAbilityModifier(ABILITY_DEXTERITY, Object);
        public virtual int ConstitutionModifier => _.GetAbilityModifier(ABILITY_CONSTITUTION, Object);
        public virtual int WisdomModifier => _.GetAbilityModifier(ABILITY_WISDOM, Object);
        public virtual int IntelligenceModifier => _.GetAbilityModifier(ABILITY_INTELLIGENCE, Object);
        public virtual int CharismaModifier => _.GetAbilityModifier(ABILITY_CHARISMA, Object);

        public virtual int XP
        {
            get => _.GetXP(Object);
            set => _.SetXP(Object, value);
        }

        public virtual NWItem Head => NWItem.Wrap(_.GetItemInSlot(INVENTORY_SLOT_HEAD, Object));
        public virtual NWItem Chest => NWItem.Wrap(_.GetItemInSlot(INVENTORY_SLOT_CHEST, Object));
        public virtual NWItem Boots => NWItem.Wrap(_.GetItemInSlot(INVENTORY_SLOT_BOOTS, Object));
        public virtual NWItem Arms => NWItem.Wrap(_.GetItemInSlot(INVENTORY_SLOT_ARMS, Object));
        public virtual NWItem RightHand => NWItem.Wrap(_.GetItemInSlot(INVENTORY_SLOT_RIGHTHAND, Object));
        public virtual NWItem LeftHand => NWItem.Wrap(_.GetItemInSlot(INVENTORY_SLOT_LEFTHAND, Object));
        public virtual NWItem Cloak => NWItem.Wrap(_.GetItemInSlot(INVENTORY_SLOT_CLOAK, Object));
        public virtual NWItem LeftRing => NWItem.Wrap(_.GetItemInSlot(INVENTORY_SLOT_LEFTRING, Object));
        public virtual NWItem RightRing => NWItem.Wrap(_.GetItemInSlot(INVENTORY_SLOT_RIGHTRING, Object));
        public virtual NWItem Neck => NWItem.Wrap(_.GetItemInSlot(INVENTORY_SLOT_NECK, Object));
        public virtual NWItem Belt => NWItem.Wrap(_.GetItemInSlot(INVENTORY_SLOT_BELT, Object));
        public virtual NWItem Arrows => NWItem.Wrap(_.GetItemInSlot(INVENTORY_SLOT_ARROWS, Object));
        public virtual NWItem Bullets => NWItem.Wrap(_.GetItemInSlot(INVENTORY_SLOT_BULLETS, Object));
        public virtual NWItem Bolts => NWItem.Wrap(_.GetItemInSlot(INVENTORY_SLOT_BOLTS, Object));
        public virtual NWItem CreatureWeaponLeft => NWItem.Wrap(_.GetItemInSlot(INVENTORY_SLOT_CWEAPON_L, Object));
        public virtual NWItem CreatureWeaponRight => NWItem.Wrap(_.GetItemInSlot(INVENTORY_SLOT_CWEAPON_R, Object));
        public virtual NWItem CreatureWeaponBite => NWItem.Wrap(_.GetItemInSlot(INVENTORY_SLOT_CWEAPON_B, Object));
        public virtual NWItem CreatureHide => NWItem.Wrap(_.GetItemInSlot(INVENTORY_SLOT_CARMOUR, Object));

        public virtual void FloatingText(string text, bool displayToFaction = false)
        {
            _.FloatingTextStringOnCreature(text, Object, displayToFaction ? 1 : 0);
        }

        public virtual void SendMessage(string text)
        {
            _.SendMessageToPC(Object, text);
        }

        public virtual bool IsDead => _.GetIsDead(Object) == 1;

        public virtual int CastingSpeed
        {
            get
            {
                int castingSpeed = 0;

                for (int itemSlot = 0; itemSlot < NUM_INVENTORY_SLOTS; itemSlot++)
                {
                    NWItem item = NWItem.Wrap(_.GetItemInSlot(itemSlot, Object));
                    castingSpeed = castingSpeed + item.CastingSpeed;
                }

                if (castingSpeed < -99)
                    castingSpeed = -99;
                else if (castingSpeed > 99)
                    castingSpeed = 99;

                return castingSpeed;
            }
        }
    }
}
