using System;
using Freescape.Game.Server.GameObject.Contracts;
using NWN;
using Object = NWN.Object;

namespace Freescape.Game.Server.GameObject
{
    public class NWCreature : NWObject, INWCreature
    {
        private readonly INWScript _;

        public NWCreature(INWScript script)
            : base(script)
        {
            _ = script;
        }


        public new static NWCreature Wrap(Object @object)
        {
            var obj = (NWCreature)App.Resolve<INWObject>();
            obj.Object = @object;

            return obj;
        }

        public int Age => _.GetAge(Object);

        public float ChallengeRating => _.GetChallengeRating(Object);

        public int Class1 => _.GetClassByPosition(1, Object);

        public int Class2 => _.GetClassByPosition(2, Object);

        public int Class3 => _.GetClassByPosition(3, Object);

        public bool IsCommandable
        {
            get => _.GetCommandable(Object) == 1;
            set => _.SetCommandable(value ? 1 : 0, Object);
        }

        public int Size => _.GetCreatureSize(Object);

        public int Phenotype
        {
            get => _.GetPhenoType(Object);
            set => _.SetPhenoType(value, Object);
        }

        public string Deity
        {
            get => _.GetDeity(Object);
            set => _.SetDeity(Object, value);
        }

        public int RacialType => _.GetRacialType(Object);

        public int Gender => _.GetGender(Object);

        public bool IsPlayer => _.GetIsPC(Object) == 1 && _.GetIsDM(Object) == 0 && _.GetIsDMPossessed(Object) == 0;

        public bool IsDM => _.GetIsPC(Object) == 0 && (_.GetIsDM(Object) == 1 || _.GetIsDMPossessed(Object) == 1);

        public bool IsResting => _.GetIsResting(Object) == 1;

        public float Weight => _.GetWeight(Object) * 0.1f;

        public int Strength
        {
            get => _.GetAbilityScore(Object, NWScript.ABILITY_STRENGTH);
            set => throw new NotImplementedException();
        }
        public int Dexterity
        {
            get => _.GetAbilityScore(Object, NWScript.ABILITY_DEXTERITY);
            set => throw new NotImplementedException();
        }
        public int Constitution
        {
            get => _.GetAbilityScore(Object, NWScript.ABILITY_CONSTITUTION);
            set => throw new NotImplementedException();
        }
        public int Wisdom
        {
            get => _.GetAbilityScore(Object, NWScript.ABILITY_WISDOM);
            set => throw new NotImplementedException();
        }
        public int Intelligence
        {
            get => _.GetAbilityScore(Object, NWScript.ABILITY_INTELLIGENCE);
            set => throw new NotImplementedException();
        }
        public int Charisma
        {
            get => _.GetAbilityScore(Object, NWScript.ABILITY_CHARISMA);
            set => throw new NotImplementedException();
        }

        public int XP
        {
            get => _.GetXP(Object);
            set => _.SetXP(Object, value);
        }

        public void AssignCommand(ActionDelegate action)
        {
            _.AssignCommand(Object, action);
        }
    }
}
