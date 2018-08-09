using System;
using Freescape.Game.Server.GameObject.Contracts;
using NWN;
using static NWN.NWScript;
using Object = NWN.Object;

namespace Freescape.Game.Server.GameObject
{
    public class NWCreature : NWObject, INWCreature
    {
        public NWCreature(INWScript script)
            : base(script)
        {
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
            set => throw new NotImplementedException();
        }
        public virtual int Dexterity
        {
            get => _.GetAbilityScore(Object, ABILITY_DEXTERITY);
            set => throw new NotImplementedException();
        }
        public virtual int Constitution
        {
            get => _.GetAbilityScore(Object, ABILITY_CONSTITUTION);
            set => throw new NotImplementedException();
        }
        public virtual int Wisdom
        {
            get => _.GetAbilityScore(Object, ABILITY_WISDOM);
            set => throw new NotImplementedException();
        }
        public virtual int Intelligence
        {
            get => _.GetAbilityScore(Object, ABILITY_INTELLIGENCE);
            set => throw new NotImplementedException();
        }
        public virtual int Charisma
        {
            get => _.GetAbilityScore(Object, ABILITY_CHARISMA);
            set => throw new NotImplementedException();
        }

        public virtual int StrengthModifier
        {
            get => _.GetAbilityModifier(ABILITY_STRENGTH, Object);
            set => throw new NotImplementedException();
        }
        public virtual int DexterityModifier
        {
            get => _.GetAbilityModifier(ABILITY_DEXTERITY, Object);
            set => throw new NotImplementedException();
        }
        public virtual int ConstitutionModifier
        {
            get => _.GetAbilityModifier(ABILITY_CONSTITUTION, Object);
            set => throw new NotImplementedException();
        }
        public virtual int WisdomModifier
        {
            get => _.GetAbilityModifier(ABILITY_WISDOM, Object);
            set => throw new NotImplementedException();
        }
        public virtual int IntelligenceModifier
        {
            get => _.GetAbilityModifier(ABILITY_INTELLIGENCE, Object);
            set => throw new NotImplementedException();
        }
        public virtual int CharismaModifier
        {
            get => _.GetAbilityModifier(ABILITY_CHARISMA, Object);
            set => throw new NotImplementedException();
        }
        public virtual int XP
        {
            get => _.GetXP(Object);
            set => _.SetXP(Object, value);
        }

        public virtual NWItem Head
        {
            get => NWItem.Wrap(_.GetItemInSlot(INVENTORY_SLOT_HEAD, Object));
            set => throw new NotImplementedException();
        }

        public virtual NWItem Chest
        {
            get => NWItem.Wrap(_.GetItemInSlot(INVENTORY_SLOT_CHEST, Object));
            set => throw new NotImplementedException();
        }

        public virtual NWItem Boots
        {
            get => NWItem.Wrap(_.GetItemInSlot(INVENTORY_SLOT_BOOTS, Object));
            set => throw new NotImplementedException();
        }

        public virtual NWItem Arms
        {
            get => NWItem.Wrap(_.GetItemInSlot(INVENTORY_SLOT_ARMS, Object));
            set => throw new NotImplementedException();
        }

        public virtual NWItem RightHand
        {
            get => NWItem.Wrap(_.GetItemInSlot(INVENTORY_SLOT_RIGHTHAND, Object));
            set => throw new NotImplementedException();
        }

        public virtual NWItem LeftHand
        {
            get => NWItem.Wrap(_.GetItemInSlot(INVENTORY_SLOT_LEFTHAND, Object));
            set => throw new NotImplementedException();
        }

        public virtual NWItem Cloak
        {
            get => NWItem.Wrap(_.GetItemInSlot(INVENTORY_SLOT_CLOAK, Object));
            set => throw new NotImplementedException();
        }

        public virtual NWItem LeftRing
        {
            get => NWItem.Wrap(_.GetItemInSlot(INVENTORY_SLOT_LEFTRING, Object));
            set => throw new NotImplementedException();
        }

        public virtual NWItem RightRing
        {
            get => NWItem.Wrap(_.GetItemInSlot(INVENTORY_SLOT_RIGHTRING, Object));
            set => throw new NotImplementedException();
        }

        public virtual NWItem Neck
        {
            get => NWItem.Wrap(_.GetItemInSlot(INVENTORY_SLOT_NECK, Object));
            set => throw new NotImplementedException();
        }

        public virtual NWItem Belt
        {
            get => NWItem.Wrap(_.GetItemInSlot(INVENTORY_SLOT_BELT, Object));
            set => throw new NotImplementedException();
        }

        public virtual NWItem Arrows
        {
            get => NWItem.Wrap(_.GetItemInSlot(INVENTORY_SLOT_ARROWS, Object));
            set => throw new NotImplementedException();
        }

        public virtual NWItem Bullets
        {
            get => NWItem.Wrap(_.GetItemInSlot(INVENTORY_SLOT_BULLETS, Object));
            set => throw new NotImplementedException();
        }

        public virtual NWItem Bolts
        {
            get => NWItem.Wrap(_.GetItemInSlot(INVENTORY_SLOT_BOLTS, Object));
            set => throw new NotImplementedException();
        }

        public virtual NWItem CreatureWeaponLeft
        {
            get => NWItem.Wrap(_.GetItemInSlot(INVENTORY_SLOT_CWEAPON_L, Object));
            set => throw new NotImplementedException();
        }

        public virtual NWItem CreatureWeaponRight
        {
            get => NWItem.Wrap(_.GetItemInSlot(INVENTORY_SLOT_CWEAPON_R, Object));
            set => throw new NotImplementedException();
        }

        public virtual NWItem CreatureWeaponBite
        {
            get => NWItem.Wrap(_.GetItemInSlot(INVENTORY_SLOT_CWEAPON_B, Object));
            set => throw new NotImplementedException();
        }

        public virtual NWItem CreatureHide
        {
            get => NWItem.Wrap(_.GetItemInSlot(INVENTORY_SLOT_CARMOUR, Object));
            set => throw new NotImplementedException();
        }

        public virtual void FloatingText(string text, bool displayToFaction = false)
        {
            _.FloatingTextStringOnCreature(text, Object, displayToFaction ? 1 : 0);
        }

        public virtual void SendMessage(string text)
        {
            _.SendMessageToPC(Object, text);
        }

        public virtual bool IsDead => _.GetIsDead(Object) == 1;
    }
}
