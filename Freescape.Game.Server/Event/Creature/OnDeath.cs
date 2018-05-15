using Freescape.Game.Server.GameObject;
using Freescape.Game.Server.Service.Contracts;
using NWN;

namespace Freescape.Game.Server.Event.Creature
{
    public class OnDeath: IRegisteredEvent
    {
        private readonly ISkillService _skill;
        private readonly ILootService _loot;

        public OnDeath(ILootService loot, ISkillService skill)
        {
            _skill = skill;
            _loot = loot;
        }

        public bool Run(params object[] args)
        {
            NWCreature creature = NWCreature.Wrap(Object.OBJECT_SELF);

            _skill.OnCreatureDeath(creature);
            _loot.OnCreatureDeath(creature);
            return true;
        }
    }
}
