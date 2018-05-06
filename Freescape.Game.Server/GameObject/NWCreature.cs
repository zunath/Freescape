using NWN;

namespace Freescape.Game.Server.GameObject
{
    public class NWCreature : NWObject
    {
        public int Age => NWScript.GetAge(this);

        public float ChallengeRating => NWScript.GetChallengeRating(this);

        public int Class1 => NWScript.GetClassByPosition(1, this);

        public int Class2 => NWScript.GetClassByPosition(2, this);

        public int Class3 => NWScript.GetClassByPosition(3, this);

        public bool IsCommandable
        {
            get => NWScript.GetCommandable(this) == 1;
            set => NWScript.SetCommandable(value ? 1 : 0, this);
        }

        public int Size => NWScript.GetCreatureSize(this);

        public int Phenotype
        {
            get => NWScript.GetPhenoType(this);
            set => NWScript.SetPhenoType(value, this);
        }

        public string Deity
        {
            get => NWScript.GetDeity(this);
            set => NWScript.SetDeity(this, value);
        }

        public int RacialType => NWScript.GetRacialType(this);

        public int Gender => NWScript.GetGender(this);

        public bool IsPlayer => NWScript.GetIsPC(this) == 1 && NWScript.GetIsDM(this) == 0 && NWScript.GetIsDMPossessed(this) == 0;

        public bool IsDM => NWScript.GetIsPC(this) == 0 && (NWScript.GetIsDM(this) == 1 || NWScript.GetIsDMPossessed(this) == 1);

        public bool IsResting => NWScript.GetIsResting(this) == 1;

        public float Weight => NWScript.GetWeight(this) * 0.1f;

        public int XP
        {
            get => NWScript.GetXP(this);
            set => NWScript.SetXP(this, value);
        }
    }
}
