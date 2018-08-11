using NWN;

namespace Freescape.Game.Server.NWNX.Contracts
{
    public interface ISCORCO
    {
        Object LoadObject(byte[] gffData, Location toLocation, Object toOwner);
        byte[] SaveObject(Object o);
    }
}