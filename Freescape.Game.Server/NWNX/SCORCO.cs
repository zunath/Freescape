using System;
using Freescape.Game.Server.NWNX.Contracts;
using NWN;
using Object = NWN.Object;

namespace Freescape.Game.Server.NWNX
{
    public class SCORCO : ISCORCO
    {
        public string KEY_RCO = typeof(SCORCO).ToString();
        public string KEY_SCO = typeof(SCORCO).ToString();

        private readonly INWScript _;

        public SCORCO(INWScript script)
        {
            _ = script;
        }

        private static volatile byte[] rcoData;
        private static volatile byte[] scoData;

        /**
         * Loads a Item or Creature via SCO/RCO into the game. Needs NWN context.
         *
         * @param data the raw GFF data.
         * @param toLocation the location to create the object at
         * @param toOwner the inventory to create the object in (if item)
         * @return the object, or null on failure
         */
        public Object LoadObject(byte[] gffData, Location toLocation, Object toOwner)
        {
            rcoData = gffData;
            return _.RetrieveCampaignObject("NWNX", KEY_RCO, toLocation, toOwner);
        }
        
        /**
         * Retrieves the raw GFF data of a Item or Creature. Needs NWN context.
         *
         * @param o the Item or Creature to serialize
         * @return a byte array containing valid GFF data, or null on failure
         */
        public byte[] SaveObject(Object o)
        {
            _.StoreCampaignObject("NWNX", KEY_SCO, o, null);
            byte[] ret = scoData;
            scoData = null;
            return ret;
        }
    }
}
