using System;
using Freescape.Game.Server.GameObject.Contracts;
using NWN;
using Object = NWN.Object;

namespace Freescape.Game.Server.GameObject
{
    public class NWCreature : NWObject, INWCreature
    {
        private readonly INWScript _script;

        public NWCreature(INWScript script)
            : base(script)
        {
            _script = script;
        }


        public new static NWCreature Wrap(Object @object)
        {
            var obj = (NWCreature)App.Resolve<INWObject>();
            obj.Object = @object;

            return obj;
        }

        public int Age => _script.GetAge(Object);

        public float ChallengeRating => _script.GetChallengeRating(Object);

        public int Class1 => _script.GetClassByPosition(1, Object);

        public int Class2 => _script.GetClassByPosition(2, Object);

        public int Class3 => _script.GetClassByPosition(3, Object);

        public bool IsCommandable
        {
            get => _script.GetCommandable(Object) == 1;
            set => _script.SetCommandable(value ? 1 : 0, Object);
        }

        public int Size => _script.GetCreatureSize(Object);

        public int Phenotype
        {
            get => _script.GetPhenoType(Object);
            set => _script.SetPhenoType(value, Object);
        }

        public string Deity
        {
            get => _script.GetDeity(Object);
            set => _script.SetDeity(Object, value);
        }

        public int RacialType => _script.GetRacialType(Object);

        public int Gender => _script.GetGender(Object);

        public bool IsPlayer => _script.GetIsPC(Object) == 1 && _script.GetIsDM(Object) == 0 && _script.GetIsDMPossessed(Object) == 0;

        public bool IsDM => _script.GetIsPC(Object) == 0 && (_script.GetIsDM(Object) == 1 || _script.GetIsDMPossessed(Object) == 1);

        public bool IsResting => _script.GetIsResting(Object) == 1;

        public float Weight => _script.GetWeight(Object) * 0.1f;

        public int XP
        {
            get => _script.GetXP(Object);
            set => _script.SetXP(Object, value);
        }

        public void AssignCommand(ActionDelegate action)
        {
            _script.AssignCommand(Object, action);
        }
    }
}
