namespace Freescape.Game.Server.Events.Dialog
{
    public class ActionTaken: IRegisteredEvent
    {
        public void Run(params object[] args)
        {
            int nodeID = (int)args[0];



        }
    }
}
