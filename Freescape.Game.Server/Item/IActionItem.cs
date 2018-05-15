using Freescape.Game.Server.GameObject;
using Freescape.Game.Server.ValueObject;

namespace Freescape.Game.Server.Item
{
    public interface IActionItem
    {
        CustomData StartUseItem(NWCreature user, NWItem item, NWObject target);
        void ApplyEffects(NWCreature user, NWItem item, NWObject target, CustomData customData);
        float Seconds(NWCreature user, NWItem item, NWObject target, CustomData customData);
        bool FaceTarget();
        int AnimationID();
        float MaxDistance();
        bool ReducesItemCharge(NWCreature user, NWItem item, NWObject target, CustomData customData);
        string IsValidTarget(NWCreature user, NWItem item, NWObject target);
    }
}
