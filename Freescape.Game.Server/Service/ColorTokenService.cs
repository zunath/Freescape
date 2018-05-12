using Freescape.Game.Server.GameObject;
using Freescape.Game.Server.Service.Contracts;
using NWN;

namespace Freescape.Game.Server.Service
{
    /// <summary>
    ///      *
    ///      * Access to the color tokens provided by The Krit.
    ///      ************************************************************
    ///      * Please use these judiciously to enhance the gaming
    ///      * experience. (Overuse of colors detracts from it.)
    ///      ************************************************************
    ///      * Color tokens in a String will change the color from that
    ///      * point on when the String is displayed on the screen.
    ///      * Every color change should be ended by an end token,
    ///      * supplied by ColorTokenEnd().
    ///      ************************************************************/
    /// </summary>
    public class ColorTokenService : IColorTokenService
    {
        private readonly INWScript _;

        public ColorTokenService(INWScript script)
        {
            _ = script;
        }

        private const string ColorArray = "     !##$%&'()*+,-./0123456789:;<=>?@ABCDEFGHIJKLMNOPQRSTUVWXYZ[]]^_`abcdefghijklmnopqrstuvwxyz{|}~€‚ƒ„…†‡ˆ‰Š‹ŒŽ‘’“”•–—˜™š›œžŸ ¡¢£¤¥¦§¨©ª«¬­®¯°±²³´µ¶·¸¹º»¼½¾¿ÀÁÂÃÄÅÆÇÈÉÊËÌÍÎÏÐÑÒÓÔÕÖ×ØÙÚÛÜÝÞßàáâãäåæçèéêëìíîïðñòóôõö÷øùúûüýþþ";

        public string TokenStart(int red, int green, int blue)
        {
            return "<c" + _.GetSubString(ColorArray, red, 1) +
                   _.GetSubString(ColorArray, green, 1) +
                   _.GetSubString(ColorArray, blue, 1) + ">";
        }

        public string Custom(string text, int red, int green, int blue)
        {
            return TokenStart(red, green, blue) + text + TokenEnd();
        }

        public string TokenEnd()
        {
            return "</c>";
        }

        public string Black(string text)
        {
            return "<c" + _.GetSubString(ColorArray, 0, 1) +
                    _.GetSubString(ColorArray, 0, 1) +
                    _.GetSubString(ColorArray, 0, 1) + ">" + text + TokenEnd();
        }
        public string Blue(string text)
        {
            return "<c" + _.GetSubString(ColorArray, 0, 1) +
                    _.GetSubString(ColorArray, 0, 1) +
                    _.GetSubString(ColorArray, 255, 1) + ">" + text + TokenEnd();
        }

        public string Gray(string text)
        {
            return "<c" + _.GetSubString(ColorArray, 127, 1) +
                    _.GetSubString(ColorArray, 127, 1) +
                    _.GetSubString(ColorArray, 127, 1) + ">" + text + TokenEnd();
        }

        public string Green(string text)
        {
            return "<c" + _.GetSubString(ColorArray, 0, 1) +
                    _.GetSubString(ColorArray, 255, 1) +
                    _.GetSubString(ColorArray, 0, 1) + ">" + text + TokenEnd();
        }

        public string LightPurple(string text)
        {
            return "<c" + _.GetSubString(ColorArray, 175, 1) +
                    _.GetSubString(ColorArray, 48, 1) +
                    _.GetSubString(ColorArray, 255, 1) + ">" + text + TokenEnd();
        }

        public string Orange(string text)
        {
            return "<c" + _.GetSubString(ColorArray, 255, 1) +
                    _.GetSubString(ColorArray, 127, 1) +
                    _.GetSubString(ColorArray, 0, 1) + ">" + text + TokenEnd();
        }

        public string Pink(string text)
        {
            return "<c" + _.GetSubString(ColorArray, 255, 1) +
                    _.GetSubString(ColorArray, 0, 1) +
                    _.GetSubString(ColorArray, 255, 1) + ">" + text + TokenEnd();
        }

        public string Purple(string text)
        {
            return "<c" + _.GetSubString(ColorArray, 127, 1) +
                    _.GetSubString(ColorArray, 0, 1) +
                    _.GetSubString(ColorArray, 255, 1) + ">" + text + TokenEnd();
        }

        public string Red(string text)
        {
            return "<c" + _.GetSubString(ColorArray, 255, 1) +
                    _.GetSubString(ColorArray, 0, 1) +
                    _.GetSubString(ColorArray, 0, 1) + ">" + text + TokenEnd();
        }

        public string White(string text)
        {
            return "<c" + _.GetSubString(ColorArray, 255, 1) +
                    _.GetSubString(ColorArray, 255, 1) +
                    _.GetSubString(ColorArray, 255, 1) + ">" + text + TokenEnd();
        }

        public string Yellow(string text)
        {
            return "<c" + _.GetSubString(ColorArray, 255, 1) +
                    _.GetSubString(ColorArray, 255, 1) +
                    _.GetSubString(ColorArray, 0, 1) + ">" + text + TokenEnd();
        }

        public string Cyan(string text)
        {
            return "<c" + _.GetSubString(ColorArray, 0, 1) +
                    _.GetSubString(ColorArray, 255, 1) +
                    _.GetSubString(ColorArray, 255, 1) + ">" + text + TokenEnd();
        }

        public string Combat(string text)
        {
            return "<c" + _.GetSubString(ColorArray, 255, 1) +
                    _.GetSubString(ColorArray, 102, 1) +
                    _.GetSubString(ColorArray, 0, 1) + ">" + text + TokenEnd();
        }

        public string Dialog(string text)
        {
            return "<c" + _.GetSubString(ColorArray, 255, 1) +
                    _.GetSubString(ColorArray, 255, 1) +
                    _.GetSubString(ColorArray, 255, 1) + ">" + text + TokenEnd();
        }

        public string DialogAction(string text)
        {
            return "<c" + _.GetSubString(ColorArray, 1, 1) +
                    _.GetSubString(ColorArray, 254, 1) +
                    _.GetSubString(ColorArray, 1, 1) + ">" + text + TokenEnd();
        }

        public string DialogCheck(string text)
        {
            return "<c" + _.GetSubString(ColorArray, 254, 1) +
                    _.GetSubString(ColorArray, 1, 1) +
                    _.GetSubString(ColorArray, 1, 1) + ">" + text + TokenEnd();
        }

        public string DialogHighlight(string text)
        {
            return "<c" + _.GetSubString(ColorArray, 1, 1) +
                    _.GetSubString(ColorArray, 1, 1) +
                    _.GetSubString(ColorArray, 254, 1) + ">" + text + TokenEnd();
        }

        public string DialogReply(string text)
        {
            return "<c" + _.GetSubString(ColorArray, 102, 1) +
                    _.GetSubString(ColorArray, 178, 1) +
                    _.GetSubString(ColorArray, 255, 1) + ">" + text + TokenEnd();
        }

        public string DM(string text)
        {
            return "<c" + _.GetSubString(ColorArray, 16, 1) +
                    _.GetSubString(ColorArray, 223, 1) +
                    _.GetSubString(ColorArray, 255, 1) + ">" + text + TokenEnd();
        }

        public string GameEngine(string text)
        {
            return "<c" + _.GetSubString(ColorArray, 204, 1) +
                    _.GetSubString(ColorArray, 119, 1) +
                    _.GetSubString(ColorArray, 255, 1) + ">" + text + TokenEnd();
        }

        public string SavingThrow(string text)
        {
            return "<c" + _.GetSubString(ColorArray, 102, 1) +
                    _.GetSubString(ColorArray, 204, 1) +
                    _.GetSubString(ColorArray, 255, 1) + ">" + text + TokenEnd();
        }

        public string Script(string text)
        {
            return "<c" + _.GetSubString(ColorArray, 255, 1) +
                    _.GetSubString(ColorArray, 255, 1) +
                    _.GetSubString(ColorArray, 0, 1) + ">" + text + TokenEnd();
        }

        public string Server(string text)
        {
            return "<c" + _.GetSubString(ColorArray, 176, 1) +
                    _.GetSubString(ColorArray, 176, 1) +
                    _.GetSubString(ColorArray, 176, 1) + ">" + text + TokenEnd();
        }

        public string Shout(string text)
        {
            return "<c" + _.GetSubString(ColorArray, 255, 1) +
                    _.GetSubString(ColorArray, 239, 1) +
                    _.GetSubString(ColorArray, 80, 1) + ">" + text + TokenEnd();
        }

        public string SkillCheck(string text)
        {
            return "<c" + _.GetSubString(ColorArray, 0, 1) +
                    _.GetSubString(ColorArray, 102, 1) +
                    _.GetSubString(ColorArray, 255, 1) + ">" + text + TokenEnd();
        }

        public string Talk(string text)
        {
            return "<c" + _.GetSubString(ColorArray, 240, 1) +
                    _.GetSubString(ColorArray, 240, 1) +
                    _.GetSubString(ColorArray, 240, 1) + ">" + text + TokenEnd();
        }

        public string Tell(string text)
        {
            return "<c" + _.GetSubString(ColorArray, 32, 1) +
                    _.GetSubString(ColorArray, 255, 1) +
                    _.GetSubString(ColorArray, 32, 1) + ">" + text + TokenEnd();
        }

        public string Whisper(string text)
        {
            return "<c" + _.GetSubString(ColorArray, 128, 1) +
                    _.GetSubString(ColorArray, 128, 1) +
                    _.GetSubString(ColorArray, 128, 1) + ">" + text + TokenEnd();
        }

        ///////////////////////////////////////////////////////////////////////////////
        // _.GetNamePCColor()
        //
        // Returns the name of oPC, surrounded by color tokens, so the color of
        // the name is the lighter blue often used in NWN game engine messages.
        //
        //
        public string GetNamePCColor(NWObject oPC)
        {
            return "<c" + _.GetSubString(ColorArray, 153, 1) +
                    _.GetSubString(ColorArray, 255, 1) +
                    _.GetSubString(ColorArray, 255, 1) + ">" +
                    _.GetName(oPC.Object) + "</c>";
        }

        ///////////////////////////////////////////////////////////////////////////////
        // _.GetNameNPCColor()
        //
        // Returns the name of oNPC, surrounded by color tokens, so the color of
        // the name is the shade of purple often used in NWN game engine messages.
        //
        public string GetNameNPCColor(NWObject oNPC)
        {
            return "<c" + _.GetSubString(ColorArray, 204, 1) +
                    _.GetSubString(ColorArray, 153, 1) +
                    _.GetSubString(ColorArray, 204, 1) + ">" +
                    _.GetName(oNPC.Object) + "</c>";
        }

    }
}
