namespace Freescape.Game.Server.GameObject.Contracts
{
    public interface INWCreature
    {
        int Age { get; }
        NWItem Arms { get; }
        NWItem Arrows { get; }
        NWItem Belt { get; }
        NWItem Bolts { get; }
        NWItem Boots { get; }
        NWItem Bullets { get; }
        int CastingSpeed { get; }
        float ChallengeRating { get; }
        int Charisma { get; set; }
        int CharismaModifier { get; }
        NWItem Chest { get; }
        int Class1 { get; }
        int Class2 { get; }
        int Class3 { get; }
        NWItem Cloak { get; }
        int Constitution { get; set; }
        int ConstitutionModifier { get; }
        NWItem CreatureHide { get; }
        NWItem CreatureWeaponBite { get; }
        NWItem CreatureWeaponLeft { get; }
        NWItem CreatureWeaponRight { get; }
        string Deity { get; set; }
        int Dexterity { get; set; }
        int DexterityModifier { get; }
        int Gender { get; }
        NWItem Head { get; }
        int Intelligence { get; set; }
        int IntelligenceModifier { get; }
        bool IsCommandable { get; set; }
        bool IsDead { get; }
        bool IsDM { get; }
        bool IsPlayer { get; }
        bool IsResting { get; }
        NWItem LeftHand { get; }
        NWItem LeftRing { get; }
        NWItem Neck { get; }
        int Phenotype { get; set; }
        int RacialType { get; }
        NWItem RightHand { get; }
        NWItem RightRing { get; }
        int Size { get; }
        int Strength { get; set; }
        int StrengthModifier { get; }
        float Weight { get; }
        int Wisdom { get; set; }
        int WisdomModifier { get; }
        int XP { get; set; }

        void FloatingText(string text, bool displayToFaction = false);
        void SendMessage(string text);
    }
}