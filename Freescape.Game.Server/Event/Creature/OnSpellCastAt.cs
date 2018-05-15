namespace Freescape.Game.Server.Event.Creature
{
    public class OnSpellCastAt: IRegisteredEvent
    {
        public bool Run(params object[] args)
        {
            return true;
        }
    }
}
