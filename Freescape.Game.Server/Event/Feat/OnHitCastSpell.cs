namespace Freescape.Game.Server.Event.Feat
{
    public class OnHitCastSpell: IRegisteredEvent
    {
        public bool Run(params object[] args)
        {
            return true;
        }
    }
}
