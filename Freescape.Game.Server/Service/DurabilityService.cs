using System;
using System.Linq;
using Freescape.Game.Server.GameObject;
using Freescape.Game.Server.Service.Contracts;
using NWN;

namespace Freescape.Game.Server.Service
{
    public class DurabilityService: IDurabilityService
    {
        private const float DefaultDurability = 30.0f;
        
        public bool IsValidDurabilityType(NWItem item)
        {
            if (item == null) throw new ArgumentNullException(nameof(item));

            int[] validTypes =
            {
                NWScript.BASE_ITEM_ARMOR,
                NWScript.BASE_ITEM_BASTARDSWORD,
                NWScript.BASE_ITEM_BATTLEAXE,
                NWScript.BASE_ITEM_BELT,
                NWScript.BASE_ITEM_BOOTS,
                NWScript.BASE_ITEM_BRACER,
                NWScript.BASE_ITEM_CLOAK,
                NWScript.BASE_ITEM_CLUB,
                NWScript.BASE_ITEM_DAGGER,
                NWScript.BASE_ITEM_DIREMACE,
                NWScript.BASE_ITEM_DOUBLEAXE,
                NWScript.BASE_ITEM_DWARVENWARAXE,
                NWScript.BASE_ITEM_GLOVES,
                NWScript.BASE_ITEM_GREATAXE,
                NWScript.BASE_ITEM_GREATSWORD,
                NWScript.BASE_ITEM_HALBERD,
                NWScript.BASE_ITEM_HANDAXE,
                NWScript.BASE_ITEM_HEAVYCROSSBOW,
                NWScript.BASE_ITEM_HEAVYFLAIL,
                NWScript.BASE_ITEM_HELMET,
                NWScript.BASE_ITEM_KAMA,
                NWScript.BASE_ITEM_KATANA,
                NWScript.BASE_ITEM_KUKRI,
                NWScript.BASE_ITEM_LARGESHIELD,
                NWScript.BASE_ITEM_LIGHTCROSSBOW,
                NWScript.BASE_ITEM_LIGHTFLAIL,
                NWScript.BASE_ITEM_LIGHTHAMMER,
                NWScript.BASE_ITEM_LIGHTMACE,
                NWScript.BASE_ITEM_LONGBOW,
                NWScript.BASE_ITEM_LONGSWORD,
                NWScript.BASE_ITEM_MORNINGSTAR,
                NWScript.BASE_ITEM_QUARTERSTAFF,
                NWScript.BASE_ITEM_RAPIER,
                NWScript.BASE_ITEM_SCIMITAR,
                NWScript.BASE_ITEM_SCYTHE,
                NWScript.BASE_ITEM_SHORTBOW,
                NWScript.BASE_ITEM_SHORTSPEAR,
                NWScript.BASE_ITEM_SHORTSWORD,
                NWScript.BASE_ITEM_SHURIKEN,
                NWScript.BASE_ITEM_SICKLE,
                NWScript.BASE_ITEM_SLING,
                NWScript.BASE_ITEM_SMALLSHIELD,
                NWScript.BASE_ITEM_TOWERSHIELD,
                NWScript.BASE_ITEM_TRIDENT,
                NWScript.BASE_ITEM_TWOBLADEDSWORD,
                NWScript.BASE_ITEM_WARHAMMER,
                NWScript.BASE_ITEM_WHIP
            };

            return validTypes.Contains(item.BaseItemType);
        }

        private void InitializeDurability(NWItem item)
        {
            if (item == null) throw new ArgumentNullException(nameof(item));

            if (!IsValidDurabilityType(item)) return;

            if (item.GetLocalInt("DURABILITY_INITIALIZE") <= 0 &&
                item.GetLocalFloat("DURABILITY_CURRENT") <= 0.0f)
            {
                float durability = GetMaxDurability(item) <= 0 ? DefaultDurability : GetMaxDurability(item);
                item.SetLocalFloat("DURABILITY_CURRENT", durability);
            }
            item.SetLocalInt("DURABILITY_INITIALIZED", 1);
        }

        public float GetMaxDurability(NWItem item)
        {
            if (item == null) throw new ArgumentNullException(nameof(item));

            if (!IsValidDurabilityType(item)) return -1.0f;
            return item.GetLocalInt("DURABILITY_MAX") <= 0 ? DefaultDurability : item.GetLocalInt("DURABILITY_MAX");
        }

        public void SetMaxDurability(NWItem item, float value)
        {
            if (item == null) throw new ArgumentNullException(nameof(item));

            if (!IsValidDurabilityType(item)) return;
            if (value <= 0) value = DefaultDurability;

            item.SetLocalFloat("DURABILITY_MAX", value);
            InitializeDurability(item);
        }

        public float GetDurability(NWItem item)
        {
            if (item == null) throw new ArgumentNullException(nameof(item));

            if (!IsValidDurabilityType(item)) return -1.0f;
            InitializeDurability(item);
            return item.GetLocalFloat("DURABILITY_CURRENT");
        }

        public void SetDurability(NWItem item, float value)
        {
            if (item == null) throw new ArgumentNullException(nameof(item));

            if (!IsValidDurabilityType(item)) return;
            InitializeDurability(item);
            item.SetLocalFloat("DURABILITY_CURRENT", value);
        }
    }
}
