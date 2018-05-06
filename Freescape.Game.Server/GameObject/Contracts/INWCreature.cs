using NWN;

namespace Freescape.Game.Server.GameObject.Contracts
{
    public interface INWCreature
    {
        int Age { get; }
        float ChallengeRating { get; }
        int Class1 { get; }
        int Class2 { get; }
        int Class3 { get; }
        string Deity { get; set; }
        int Gender { get; }
        bool IsCommandable { get; set; }
        bool IsDM { get; }
        bool IsPlayer { get; }
        bool IsResting { get; }
        int Phenotype { get; set; }
        int RacialType { get; }
        int Size { get; }
        float Weight { get; }
        int XP { get; set; }

        void AssignCommand(ActionDelegate action);
    }
}