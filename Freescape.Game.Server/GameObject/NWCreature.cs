using NWN;

namespace Freescape.Game.Server.GameObject
{
    public class NWCreature : NWObject
    {
        private readonly INWScript _script;

        public NWCreature(INWScript script)
            : base(script)
        {
            _script = script;
        }

        public int Age => _script.GetAge(this);

        public float ChallengeRating => _script.GetChallengeRating(this);

        public int Class1 => _script.GetClassByPosition(1, this);

        public int Class2 => _script.GetClassByPosition(2, this);

        public int Class3 => _script.GetClassByPosition(3, this);

        public bool IsCommandable
        {
            get => _script.GetCommandable(this) == 1;
            set => _script.SetCommandable(value ? 1 : 0, this);
        }

        public int Size => _script.GetCreatureSize(this);

        public int Phenotype
        {
            get => _script.GetPhenoType(this);
            set => _script.SetPhenoType(value, this);
        }

        public string Deity
        {
            get => _script.GetDeity(this);
            set => _script.SetDeity(this, value);
        }

        public int RacialType => _script.GetRacialType(this);

        public int Gender => _script.GetGender(this);

        public bool IsPlayer => _script.GetIsPC(this) == 1 && _script.GetIsDM(this) == 0 && _script.GetIsDMPossessed(this) == 0;

        public bool IsDM => _script.GetIsPC(this) == 0 && (_script.GetIsDM(this) == 1 || _script.GetIsDMPossessed(this) == 1);

        public bool IsResting => _script.GetIsResting(this) == 1;

        public float Weight => _script.GetWeight(this) * 0.1f;

        public int XP
        {
            get => _script.GetXP(this);
            set => _script.SetXP(this, value);
        }
    }
}
