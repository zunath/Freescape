using System;
using System.Linq;
using Freescape.Game.Server.GameObject;
using Freescape.Game.Server.Service.Contracts;
using static NWN.NWScript;

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
                BASE_ITEM_ARMOR,
                BASE_ITEM_BASTARDSWORD,
                BASE_ITEM_BATTLEAXE,
                BASE_ITEM_BELT,
                BASE_ITEM_BOOTS,
                BASE_ITEM_BRACER,
                BASE_ITEM_CLOAK,
                BASE_ITEM_CLUB,
                BASE_ITEM_DAGGER,
                BASE_ITEM_DIREMACE,
                BASE_ITEM_DOUBLEAXE,
                BASE_ITEM_DWARVENWARAXE,
                BASE_ITEM_GLOVES,
                BASE_ITEM_GREATAXE,
                BASE_ITEM_GREATSWORD,
                BASE_ITEM_HALBERD,
                BASE_ITEM_HANDAXE,
                BASE_ITEM_HEAVYCROSSBOW,
                BASE_ITEM_HEAVYFLAIL,
                BASE_ITEM_HELMET,
                BASE_ITEM_KAMA,
                BASE_ITEM_KATANA,
                BASE_ITEM_KUKRI,
                BASE_ITEM_LARGESHIELD,
                BASE_ITEM_LIGHTCROSSBOW,
                BASE_ITEM_LIGHTFLAIL,
                BASE_ITEM_LIGHTHAMMER,
                BASE_ITEM_LIGHTMACE,
                BASE_ITEM_LONGBOW,
                BASE_ITEM_LONGSWORD,
                BASE_ITEM_MORNINGSTAR,
                BASE_ITEM_QUARTERSTAFF,
                BASE_ITEM_RAPIER,
                BASE_ITEM_SCIMITAR,
                BASE_ITEM_SCYTHE,
                BASE_ITEM_SHORTBOW,
                BASE_ITEM_SHORTSPEAR,
                BASE_ITEM_SHORTSWORD,
                BASE_ITEM_SICKLE,
                BASE_ITEM_SLING,
                BASE_ITEM_SMALLSHIELD,
                BASE_ITEM_TOWERSHIELD,
                BASE_ITEM_TRIDENT,
                BASE_ITEM_TWOBLADEDSWORD,
                BASE_ITEM_WARHAMMER,
                BASE_ITEM_WHIP
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
            if (value < 0.0f) value = 0.0f;

            if (!IsValidDurabilityType(item)) return;
            InitializeDurability(item);
            item.SetLocalFloat("DURABILITY_CURRENT", value);
        }

        public string OnModuleExamine(string existingDescription, NWObject examinedObject)
        {
            return null;
        }
    }
}
