using System;
using Freescape.Game.Server.CustomEffect.Contracts;
using Freescape.Game.Server.GameObject;
using NWN;
using static NWN.NWScript;

namespace Freescape.Game.Server.CustomEffect
{
    public class FoodDiseaseEffect: ICustomEffect
    {
        private readonly INWScript _;

        public FoodDiseaseEffect(INWScript script)
        {
            _ = script;
        }

        public void Apply(NWCreature oCaster, NWObject oTarget)
        {
            Random random = new Random();

            Effect effect = _.EffectAbilityDecrease(ABILITY_STRENGTH, random.Next(1, 5));
            effect = _.EffectLinkEffects(effect, _.EffectAbilityDecrease(ABILITY_CONSTITUTION, random.Next(1, 5)));
            effect = _.EffectLinkEffects(effect, _.EffectAbilityDecrease(ABILITY_DEXTERITY,    random.Next(1, 5)));
            effect = _.EffectLinkEffects(effect, _.EffectAbilityDecrease(ABILITY_INTELLIGENCE, random.Next(1, 5)));
            effect = _.EffectLinkEffects(effect, _.EffectAbilityDecrease(ABILITY_WISDOM,       random.Next(1, 5)));
            effect = _.EffectLinkEffects(effect, _.EffectAbilityDecrease(ABILITY_CHARISMA,     random.Next(1, 5)));

            effect = _.TagEffect(effect, "FOOD_DISEASE_EFFECT");
            _.ApplyEffectToObject(DURATION_TYPE_PERMANENT, effect, oTarget.Object);
        }

        public void Tick(NWCreature oCaster, NWObject oTarget)
        {
        }

        public void WearOff(NWCreature oCaster, NWObject oTarget)
        {
            foreach (Effect effect in oTarget.Effects)
            {
                if (_.GetEffectTag(effect) == "FOOD_DISEASE_EFFECT")
                {
                    _.RemoveEffect(oTarget.Object, effect);
                }
            }
        }
    }
}
