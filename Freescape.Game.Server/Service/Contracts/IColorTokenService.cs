using Freescape.Game.Server.GameObject;

namespace Freescape.Game.Server.Helper
{
    public interface IColorTokenService
    {
        string Custom(int nRed, int nGreen, int nBlue);
        string End();
        string Black();
        string Blue();
        string Gray();
        string Green();
        string LightPurple();
        string Orange();
        string Pink();
        string Purple();
        string Red();
        string White();
        string Yellow();
        string Cyan();
        string Combat();
        string Dialog();
        string DialogAction();
        string DialogCheck();
        string DialogHighlight();
        string DialogReply();
        string DM();
        string GameEngine();
        string SavingThrow();
        string Script();
        string Server();
        string Shout();
        string SkillCheck();
        string Talk();
        string Tell();
        string Whisper();
        string GetNamePCColor(NWObject oPC);
        string GetNameNPCColor(NWObject oNPC);
    }
}