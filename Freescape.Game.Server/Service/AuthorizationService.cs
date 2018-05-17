using Freescape.Game.Server.GameObject;
using Freescape.Game.Server.Service.Contracts;

namespace Freescape.Game.Server.Service
{
    public class AuthorizationService: IAuthorizationService
    {
        public bool IsPCRegisteredAsDM(NWPlayer player)
        {
            return false;
        }
    }
}
