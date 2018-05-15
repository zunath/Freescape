using Freescape.Game.Server.GameObject;
using NWN;

namespace Freescape.Game.Server.Service.Contracts
{
    public interface ISerializationService
    {
        byte[] Serialize(NWObject @object);
        NWObject Deserialize(byte[] data, Location location, NWObject container);
    }
}
