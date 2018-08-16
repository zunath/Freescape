using Freescape.Game.Server.ChatCommands.Contracts;
using Freescape.Game.Server.GameObject;
using Freescape.Game.Server.Service.Contracts;
using NWN;

namespace Freescape.Game.Server.ChatCommands
{
    public class SpawnItem: IChatCommand
    {
        private readonly INWScript _;
        private readonly IAuthorizationService _auth;
        private readonly IColorTokenService _color;

        public SpawnItem(
            INWScript script,
            IAuthorizationService auth,
            IColorTokenService color)
        {
            _ = script;
            _auth = auth;
            _color = color;
        }

        public bool CanUse(NWPlayer user)
        {
            return user.IsDM || _auth.IsPCRegisteredAsDM(user);
        }

        public void DoAction(NWPlayer user, params string[] args)
        {
            if (args.Length <= 0)
            {
                user.SendMessage(_color.Red("Please specify a resref and optionally a quantity. Example: /" + nameof(SpawnItem) + " my_resref 20"));
                return;
            }
            string resref = args[0];
            int quantity = 1;

            if (args.Length > 1)
            {
                if (!int.TryParse(args[1], out quantity))
                {
                    return;
                }
            }

            var item = NWItem.Wrap(_.CreateItemOnObject(resref, user.Object, quantity));
            item.IsIdentified = true;
        }
    }
}
