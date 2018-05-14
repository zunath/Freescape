using Freescape.Game.Server.GameObject;
using Freescape.Game.Server.Service.Contracts;
using NWN;

namespace Freescape.Game.Server.Event.Module
{
    internal class OnModuleEnter : IRegisteredEvent
    {
        private readonly INWScript _nw;
        private readonly IPlayerService _initService;

        public OnModuleEnter(INWScript nw,
            IPlayerService initService)
        {
            _nw = nw;
            _initService = initService;
        }

        public bool Run(params object[] args)
        {
            NWPlayer player = NWPlayer.Wrap(_nw.GetEnteringObject());

            _nw.ExecuteScript("x3_mod_def_enter", Object.OBJECT_SELF);
            _initService.InitializePlayer(player);

            return true;
        }
    }
}
