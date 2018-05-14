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
            var obj = (NWCreature)App.Resolve<INWObject>();
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

        public virtual void AssignCommand(ActionDelegate action, float delay = 0.0f)
        {
            if (delay <= 0.0f)
            {
                _.AssignCommand(Object, action);
            }
            else
            {
                _.DelayCommand(delay, action);
            }
            
        }
        
    }
}
