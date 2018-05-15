namespace Freescape.Game.Server.Event.Creature
{
    public class OnCombatRoundEnd: IRegisteredEvent
    {
        public bool Run(params object[] args)
        {
            return true;
        }
    }
}
