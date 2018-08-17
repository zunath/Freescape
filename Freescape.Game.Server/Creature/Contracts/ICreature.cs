using FluentBehaviourTree;

namespace Freescape.Game.Server.Creature.Contracts
{
    public interface ICreature
    {
        IBehaviourTreeNode Behaviour { get; }
        bool IgnoreNWNEvents { get; }

        void OnBlocked();
        void OnCombatRoundEnd();
        void OnConversation();
        void OnDamaged();
        void OnDeath();
        void OnDisturbed();
        void OnHeartbeat();
        void OnPerception();
        void OnPhysicalAttacked();
        void OnRested();
        void OnSpawn();
        void OnSpellCastAt();
        void OnUserDefined();

    }
}
