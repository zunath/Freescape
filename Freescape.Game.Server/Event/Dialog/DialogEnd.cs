namespace Freescape.Game.Server.Event.Dialog
{
    public class DialogEnd: IRegisteredEvent
    {
        public bool Run(params object[] args)
        {
            return true;

        }
    }
}
