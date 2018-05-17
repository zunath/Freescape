using Freescape.Game.Server.GameObject;
using Freescape.Game.Server.Service.Contracts;
using NWN;

namespace Freescape.Game.Server.Service
{
    public class SerializationService: ISerializationService
    {
        public byte[] Serialize(NWObject @object)
        {
            return new byte[] { };
        }

        public NWObject Deserialize(byte[] data, Location location, NWObject container)
        {
            return null;
        }
    }
}
