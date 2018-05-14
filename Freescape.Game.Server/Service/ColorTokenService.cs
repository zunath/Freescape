using System;
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
            if (red < 0 || red > 255) throw new ArgumentOutOfRangeException(nameof(red), "Red must be between 0 and 255.");
            if (green < 0 || green > 255) throw new ArgumentOutOfRangeException(nameof(green), "Green must be between 0 and 255.");
            if (blue < 0 || blue > 255) throw new ArgumentOutOfRangeException(nameof(blue), "Blue must be between 0 and 255.");

            return "<c" + _.GetSubString(ColorArray, red, 1) +
                   _.GetSubString(ColorArray, green, 1) +
                   _.GetSubString(ColorArray, blue, 1) + ">";
        }

        public string Custom(string text, int red, int green, int blue)
        {
            if (red < 0 || red > 255) throw new ArgumentOutOfRangeException(nameof(red), "Red must be between 0 and 255.");
            if (green < 0 || green > 255) throw new ArgumentOutOfRangeException(nameof(green), "Green must be between 0 and 255.");
            if (blue < 0 || blue > 255) throw new ArgumentOutOfRangeException(nameof(blue), "Blue must be between 0 and 255.");
            if(string.IsNullOrWhiteSpace(text)) throw new ArgumentException("Text must not be null, empty, or white space.", nameof(text));

            return TokenStart(red, green, blue) + text + TokenEnd();
        }

        public string TokenEnd()
        {
            return "</c>";
        }

        public string Black(string text)
        {
            if (string.IsNullOrWhiteSpace(text)) throw new ArgumentException("Text must not be null, empty, or white space.", nameof(text));

            return "<c" + _.GetSubString(ColorArray, 0, 1) +
                    _.GetSubString(ColorArray, 0, 1) +
                    _.GetSubString(ColorArray, 0, 1) + ">" + text + TokenEnd();
        }
        public string Blue(string text)
        {
            if (string.IsNullOrWhiteSpace(text)) throw new ArgumentException("Text must not be null, empty, or white space.", nameof(text));

            return "<c" + _.GetSubString(ColorArray, 0, 1) +
                    _.GetSubString(ColorArray, 0, 1) +
                    _.GetSubString(ColorArray, 255, 1) + ">" + text + TokenEnd();
        }

        public string Gray(string text)
        {
            if (string.IsNullOrWhiteSpace(text)) throw new ArgumentException("Text must not be null, empty, or white space.", nameof(text));

            return "<c" + _.GetSubString(ColorArray, 127, 1) +
                    _.GetSubString(ColorArray, 127, 1) +
                    _.GetSubString(ColorArray, 127, 1) + ">" + text + TokenEnd();
        }

        public string Green(string text)
        {
            if (string.IsNullOrWhiteSpace(text)) throw new ArgumentException("Text must not be null, empty, or white space.", nameof(text));

            return "<c" + _.GetSubString(ColorArray, 0, 1) +
                    _.GetSubString(ColorArray, 255, 1) +
                    _.GetSubString(ColorArray, 0, 1) + ">" + text + TokenEnd();
        }

        public string LightPurple(string text)
        {
            if (string.IsNullOrWhiteSpace(text)) throw new ArgumentException("Text must not be null, empty, or white space.", nameof(text));

            return "<c" + _.GetSubString(ColorArray, 175, 1) +
                    _.GetSubString(ColorArray, 48, 1) +
                    _.GetSubString(ColorArray, 255, 1) + ">" + text + TokenEnd();
        }

        public string Orange(string text)
        {
            if (string.IsNullOrWhiteSpace(text)) throw new ArgumentException("Text must not be null, empty, or white space.", nameof(text));

            return "<c" + _.GetSubString(ColorArray, 255, 1) +
                    _.GetSubString(ColorArray, 127, 1) +
                    _.GetSubString(ColorArray, 0, 1) + ">" + text + TokenEnd();
        }

        public string Pink(string text)
        {
            if (string.IsNullOrWhiteSpace(text)) throw new ArgumentException("Text must not be null, empty, or white space.", nameof(text));

            return "<c" + _.GetSubString(ColorArray, 255, 1) +
                    _.GetSubString(ColorArray, 0, 1) +
                    _.GetSubString(ColorArray, 255, 1) + ">" + text + TokenEnd();
        }

        public string Purple(string text)
        {
            if (string.IsNullOrWhiteSpace(text)) throw new ArgumentException("Text must not be null, empty, or white space.", nameof(text));

            return "<c" + _.GetSubString(ColorArray, 127, 1) +
                    _.GetSubString(ColorArray, 0, 1) +
                    _.GetSubString(ColorArray, 255, 1) + ">" + text + TokenEnd();
        }

        public string Red(string text)
        {
            if (string.IsNullOrWhiteSpace(text)) throw new ArgumentException("Text must not be null, empty, or white space.", nameof(text));

            return "<c" + _.GetSubString(ColorArray, 255, 1) +
                    _.GetSubString(ColorArray, 0, 1) +
                    _.GetSubString(ColorArray, 0, 1) + ">" + text + TokenEnd();
        }

        public string White(string text)
        {
            if (string.IsNullOrWhiteSpace(text)) throw new ArgumentException("Text must not be null, empty, or white space.", nameof(text));

            return "<c" + _.GetSubString(ColorArray, 255, 1) +
                    _.GetSubString(ColorArray, 255, 1) +
                    _.GetSubString(ColorArray, 255, 1) + ">" + text + TokenEnd();
        }

        public string Yellow(string text)
        {
            if (string.IsNullOrWhiteSpace(text)) throw new ArgumentException("Text must not be null, empty, or white space.", nameof(text));

            return "<c" + _.GetSubString(ColorArray, 255, 1) +
                    _.GetSubString(ColorArray, 255, 1) +
                    _.GetSubString(ColorArray, 0, 1) + ">" + text + TokenEnd();
        }

        public string Cyan(string text)
        {
            if (string.IsNullOrWhiteSpace(text)) throw new ArgumentException("Text must not be null, empty, or white space.", nameof(text));

            return "<c" + _.GetSubString(ColorArray, 0, 1) +
                    _.GetSubString(ColorArray, 255, 1) +
                    _.GetSubString(ColorArray, 255, 1) + ">" + text + TokenEnd();
        }

        public string Combat(string text)
        {
            if (string.IsNullOrWhiteSpace(text)) throw new ArgumentException("Text must not be null, empty, or white space.", nameof(text));

            return "<c" + _.GetSubString(ColorArray, 255, 1) +
                    _.GetSubString(ColorArray, 102, 1) +
                    _.GetSubString(ColorArray, 0, 1) + ">" + text + TokenEnd();
        }

        public string Dialog(string text)
        {
            if (string.IsNullOrWhiteSpace(text)) throw new ArgumentException("Text must not be null, empty, or white space.", nameof(text));

            return "<c" + _.GetSubString(ColorArray, 255, 1) +
                    _.GetSubString(ColorArray, 255, 1) +
                    _.GetSubString(ColorArray, 255, 1) + ">" + text + TokenEnd();
        }

        public string DialogAction(string text)
        {
            if (string.IsNullOrWhiteSpace(text)) throw new ArgumentException("Text must not be null, empty, or white space.", nameof(text));

            return "<c" + _.GetSubString(ColorArray, 1, 1) +
                    _.GetSubString(ColorArray, 254, 1) +
                    _.GetSubString(ColorArray, 1, 1) + ">" + text + TokenEnd();
        }

        public string DialogCheck(string text)
        {
            if (string.IsNullOrWhiteSpace(text)) throw new ArgumentException("Text must not be null, empty, or white space.", nameof(text));

            return "<c" + _.GetSubString(ColorArray, 254, 1) +
                    _.GetSubString(ColorArray, 1, 1) +
                    _.GetSubString(ColorArray, 1, 1) + ">" + text + TokenEnd();
        }

        public string DialogHighlight(string text)
        {
            if (string.IsNullOrWhiteSpace(text)) throw new ArgumentException("Text must not be null, empty, or white space.", nameof(text));

            return "<c" + _.GetSubString(ColorArray, 1, 1) +
                    _.GetSubString(ColorArray, 1, 1) +
                    _.GetSubString(ColorArray, 254, 1) + ">" + text + TokenEnd();
        }

        public string DialogReply(string text)
        {
            if (string.IsNullOrWhiteSpace(text)) throw new ArgumentException("Text must not be null, empty, or white space.", nameof(text));

            return "<c" + _.GetSubString(ColorArray, 102, 1) +
                    _.GetSubString(ColorArray, 178, 1) +
                    _.GetSubString(ColorArray, 255, 1) + ">" + text + TokenEnd();
        }

        public string DM(string text)
        {
            if (string.IsNullOrWhiteSpace(text)) throw new ArgumentException("Text must not be null, empty, or white space.", nameof(text));

            return "<c" + _.GetSubString(ColorArray, 16, 1) +
                    _.GetSubString(ColorArray, 223, 1) +
                    _.GetSubString(ColorArray, 255, 1) + ">" + text + TokenEnd();
        }

        public string GameEngine(string text)
        {
            if (string.IsNullOrWhiteSpace(text)) throw new ArgumentException("Text must not be null, empty, or white space.", nameof(text));

            return "<c" + _.GetSubString(ColorArray, 204, 1) +
                    _.GetSubString(ColorArray, 119, 1) +
                    _.GetSubString(ColorArray, 255, 1) + ">" + text + TokenEnd();
        }

        public string SavingThrow(string text)
        {
            if (string.IsNullOrWhiteSpace(text)) throw new ArgumentException("Text must not be null, empty, or white space.", nameof(text));

            return "<c" + _.GetSubString(ColorArray, 102, 1) +
                    _.GetSubString(ColorArray, 204, 1) +
                    _.GetSubString(ColorArray, 255, 1) + ">" + text + TokenEnd();
        }

        public string Script(string text)
        {
            if (string.IsNullOrWhiteSpace(text)) throw new ArgumentException("Text must not be null, empty, or white space.", nameof(text));

            return "<c" + _.GetSubString(ColorArray, 255, 1) +
                    _.GetSubString(ColorArray, 255, 1) +
                    _.GetSubString(ColorArray, 0, 1) + ">" + text + TokenEnd();
        }

        public string Server(string text)
        {
            if (string.IsNullOrWhiteSpace(text)) throw new ArgumentException("Text must not be null, empty, or white space.", nameof(text));

            return "<c" + _.GetSubString(ColorArray, 176, 1) +
                    _.GetSubString(ColorArray, 176, 1) +
                    _.GetSubString(ColorArray, 176, 1) + ">" + text + TokenEnd();
        }

        public string Shout(string text)
        {
            if (string.IsNullOrWhiteSpace(text)) throw new ArgumentException("Text must not be null, empty, or white space.", nameof(text));

            return "<c" + _.GetSubString(ColorArray, 255, 1) +
                    _.GetSubString(ColorArray, 239, 1) +
                    _.GetSubString(ColorArray, 80, 1) + ">" + text + TokenEnd();
        }

        public string SkillCheck(string text)
        {
            if (string.IsNullOrWhiteSpace(text)) throw new ArgumentException("Text must not be null, empty, or white space.", nameof(text));

            return "<c" + _.GetSubString(ColorArray, 0, 1) +
                    _.GetSubString(ColorArray, 102, 1) +
                    _.GetSubString(ColorArray, 255, 1) + ">" + text + TokenEnd();
        }

        public string Talk(string text)
        {
            if (string.IsNullOrWhiteSpace(text)) throw new ArgumentException("Text must not be null, empty, or white space.", nameof(text));

            return "<c" + _.GetSubString(ColorArray, 240, 1) +
                    _.GetSubString(ColorArray, 240, 1) +
                    _.GetSubString(ColorArray, 240, 1) + ">" + text + TokenEnd();
        }

        public string Tell(string text)
        {
            if (string.IsNullOrWhiteSpace(text)) throw new ArgumentException("Text must not be null, empty, or white space.", nameof(text));

            return "<c" + _.GetSubString(ColorArray, 32, 1) +
                    _.GetSubString(ColorArray, 255, 1) +
                    _.GetSubString(ColorArray, 32, 1) + ">" + text + TokenEnd();
        }

        public string Whisper(string text)
        {
            if (string.IsNullOrWhiteSpace(text)) throw new ArgumentException("Text must not be null, empty, or white space.", nameof(text));

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
            if (oPC == null) throw new ArgumentNullException(nameof(oPC), nameof(oPC) + " cannot be null.");
            if (oPC.Object == null) throw new ArgumentNullException(nameof(oPC.Object), nameof(oPC.Object) + " cannot be null.");

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
            if (oNPC == null) throw new ArgumentNullException(nameof(oNPC), nameof(oNPC) + " cannot be null.");
            if (oNPC.Object == null) throw new ArgumentNullException(nameof(oNPC.Object), nameof(oNPC.Object) + " cannot be null.");

            return "<c" + _.GetSubString(ColorArray, 204, 1) +
                    _.GetSubString(ColorArray, 153, 1) +
                    _.GetSubString(ColorArray, 204, 1) + ">" +
                    _.GetName(oNPC.Object) + "</c>";
        }

    }
}
