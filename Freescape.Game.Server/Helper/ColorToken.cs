using Freescape.Game.Server.GameObject;
using static NWN.NWScript;

namespace Freescape.Game.Server.Helper
{
    public static class ColorToken
    {

        /*
     * colors_inc.nss
     *
     * Access to the color tokens provided by The Krit.
     ************************************************************
     * Please use these judiciously to enhance the gaming
     * experience. (Overuse of colors detracts from it.)
     ************************************************************
     * Color tokens in a String will change the color from that
     * point on when the String is displayed on the screen.
     * Every color change should be ended by an end token,
     * supplied by ColorTokenEnd().
     ************************************************************/


        ///////////////////////////////////////////////////////////////////////////////
        // Common.Constants
        ///////////////////////////////////////////////////////////////////////////////

        private const string ColorArray = "     !##$%&'()*+,-./0123456789:;<=>?@ABCDEFGHIJKLMNOPQRSTUVWXYZ[]]^_`abcdefghijklmnopqrstuvwxyz{|}~€‚ƒ„…†‡ˆ‰Š‹ŒŽ‘’“”•–—˜™š›œžŸ ¡¢£¤¥¦§¨©ª«¬­®¯°±²³´µ¶·¸¹º»¼½¾¿ÀÁÂÃÄÅÆÇÈÉÊËÌÍÎÏÐÑÒÓÔÕÖ×ØÙÚÛÜÝÞßàáâãäåæçèéêëìíîïðñòóôõö÷øùúûüýþþ";

        ///////////////////////////////////////////////////////////////////////////////
        // Basic Functions
        ///////////////////////////////////////////////////////////////////////////////


        ///////////////////////////////////////////////////////////////////////////////
        // ColorToken()
        //
        // Supplies a String that changes the text to the given RGB values.
        // Valid parameter values are 0-255.
        //
        public static string Custom(int nRed, int nGreen, int nBlue)
        {
            return "<c" + GetSubString(ColorArray, nRed, 1) +
                    GetSubString(ColorArray, nGreen, 1) +
                    GetSubString(ColorArray, nBlue, 1) + ">";
        }

        ///////////////////////////////////////////////////////////////////////////////
        // ColorTokenEnd()
        //
        // Supplies a String that ends an earlier color change.
        //
        public static string End()
        {
            return "</c>";
        }



        ///////////////////////////////////////////////////////////////////////////////
        // Functions by Color
        ///////////////////////////////////////////////////////////////////////////////


        ///////////////////////////////////////////////////////////////////////////////
        // ColorTokenBlack()
        //
        // Supplies a String that changes the text to black.
        //
        public static string Black()
        {
            return "<c" + GetSubString(ColorArray, 0, 1) +
                    GetSubString(ColorArray, 0, 1) +
                    GetSubString(ColorArray, 0, 1) + ">";
        }

        ///////////////////////////////////////////////////////////////////////////////
        // ColorTokenBlue()
        //
        // Supplies a String that changes the text to blue.
        //
        public static string Blue()
        {
            return "<c" + GetSubString(ColorArray, 0, 1) +
                    GetSubString(ColorArray, 0, 1) +
                    GetSubString(ColorArray, 255, 1) + ">";
        }

        ///////////////////////////////////////////////////////////////////////////////
        // ColorTokenGray()
        //
        // Supplies a String that changes the text to gray.
        //
        public static string Gray()
        {
            return "<c" + GetSubString(ColorArray, 127, 1) +
                    GetSubString(ColorArray, 127, 1) +
                    GetSubString(ColorArray, 127, 1) + ">";
        }

        ///////////////////////////////////////////////////////////////////////////////
        // ColorTokenGreen()
        //
        // Supplies a String that changes the text to green.
        //
        public static string Green()
        {
            return "<c" + GetSubString(ColorArray, 0, 1) +
                    GetSubString(ColorArray, 255, 1) +
                    GetSubString(ColorArray, 0, 1) + ">";
        }

        ///////////////////////////////////////////////////////////////////////////////
        // ColorTokenLightPurple()
        //
        // Supplies a String that changes the text to light purple.
        //
        public static string LightPurple()
        {
            return "<c" + GetSubString(ColorArray, 175, 1) +
                    GetSubString(ColorArray, 48, 1) +
                    GetSubString(ColorArray, 255, 1) + ">";
        }

        ///////////////////////////////////////////////////////////////////////////////
        // ColorTokenOrange()
        //
        // Supplies a String that changes the text to orange.
        //
        public static string Orange()
        {
            return "<c" + GetSubString(ColorArray, 255, 1) +
                    GetSubString(ColorArray, 127, 1) +
                    GetSubString(ColorArray, 0, 1) + ">";
        }

        ///////////////////////////////////////////////////////////////////////////////
        // ColorTokenPink()
        //
        // Supplies a String that changes the text to pink.
        //
        public static string Pink()
        {
            return "<c" + GetSubString(ColorArray, 255, 1) +
                    GetSubString(ColorArray, 0, 1) +
                    GetSubString(ColorArray, 255, 1) + ">";
        }

        ///////////////////////////////////////////////////////////////////////////////
        // ColorTokenPurple()
        //
        // Supplies a String that changes the text to purple.
        //
        public static string Purple()
        {
            return "<c" + GetSubString(ColorArray, 127, 1) +
                    GetSubString(ColorArray, 0, 1) +
                    GetSubString(ColorArray, 255, 1) + ">";
        }

        ///////////////////////////////////////////////////////////////////////////////
        // ColorTokenRed()
        //
        // Supplies a String that changes the text to red.
        //
        public static string Red()
        {
            return "<c" + GetSubString(ColorArray, 255, 1) +
                    GetSubString(ColorArray, 0, 1) +
                    GetSubString(ColorArray, 0, 1) + ">";
        }

        ///////////////////////////////////////////////////////////////////////////////
        // ColorTokenWhite()
        //
        // Supplies a String that changes the text to white.
        //
        public static string White()
        {
            return "<c" + GetSubString(ColorArray, 255, 1) +
                    GetSubString(ColorArray, 255, 1) +
                    GetSubString(ColorArray, 255, 1) + ">";
        }

        ///////////////////////////////////////////////////////////////////////////////
        // ColorTokenYellow()
        //
        // Supplies a String that changes the text to yellow.
        //
        public static string Yellow()
        {
            return "<c" + GetSubString(ColorArray, 255, 1) +
                    GetSubString(ColorArray, 255, 1) +
                    GetSubString(ColorArray, 0, 1) + ">";
        }



        ///////////////////////////////////////////////////////////////////////////////
        // ColorTokenCyan()
        //
        // Supplies a String that changes the text to yellow.
        //
        public static string Cyan()
        {
            return "<c" + GetSubString(ColorArray, 0, 1) +
                    GetSubString(ColorArray, 255, 1) +
                    GetSubString(ColorArray, 255, 1) + ">";
        }



        ///////////////////////////////////////////////////////////////////////////////
        // Functions by Purpose
        ///////////////////////////////////////////////////////////////////////////////


        ///////////////////////////////////////////////////////////////////////////////
        // ColorTokenCombat()
        //
        // Supplies a String that changes the text to the color of
        // combat messages.
        //
        public static string Combat()
        {
            return "<c" + GetSubString(ColorArray, 255, 1) +
                    GetSubString(ColorArray, 102, 1) +
                    GetSubString(ColorArray, 0, 1) + ">";
        }

        ///////////////////////////////////////////////////////////////////////////////
        // ColorTokenDialog()
        //
        // Supplies a String that changes the text to the color of
        // dialog.
        //
        public static string Dialog()
        {
            return "<c" + GetSubString(ColorArray, 255, 1) +
                    GetSubString(ColorArray, 255, 1) +
                    GetSubString(ColorArray, 255, 1) + ">";
        }

        ///////////////////////////////////////////////////////////////////////////////
        // ColorTokenDialogAction()
        //
        // Supplies a String that changes the text to the color of
        // dialog actions.
        //
        public static string DialogAction()
        {
            return "<c" + GetSubString(ColorArray, 1, 1) +
                    GetSubString(ColorArray, 254, 1) +
                    GetSubString(ColorArray, 1, 1) + ">";
        }

        ///////////////////////////////////////////////////////////////////////////////
        // ColorTokenDialogCheck()
        //
        // Supplies a String that changes the text to the color of
        // dialog checks.
        //
        public static string DialogCheck()
        {
            return "<c" + GetSubString(ColorArray, 254, 1) +
                    GetSubString(ColorArray, 1, 1) +
                    GetSubString(ColorArray, 1, 1) + ">";
        }

        ///////////////////////////////////////////////////////////////////////////////
        // ColorTokenDialogHighlight()
        //
        // Supplies a String that changes the text to the color of
        // dialog highlighting.
        //
        public static string DialogHighlight()
        {
            return "<c" + GetSubString(ColorArray, 1, 1) +
                    GetSubString(ColorArray, 1, 1) +
                    GetSubString(ColorArray, 254, 1) + ">";
        }

        ///////////////////////////////////////////////////////////////////////////////
        // ColorTokenDialogReply()
        //
        // Supplies a String that changes the text to the color of
        // replies in the dialog window.
        //
        public static string DialogReply()
        {
            return "<c" + GetSubString(ColorArray, 102, 1) +
                    GetSubString(ColorArray, 178, 1) +
                    GetSubString(ColorArray, 255, 1) + ">";
        }

        ///////////////////////////////////////////////////////////////////////////////
        // ColorTokenDM()
        //
        // Supplies a String that changes the text to the color of
        // the DM channel.
        //
        public static string DM()
        {
            return "<c" + GetSubString(ColorArray, 16, 1) +
                    GetSubString(ColorArray, 223, 1) +
                    GetSubString(ColorArray, 255, 1) + ">";
        }

        ///////////////////////////////////////////////////////////////////////////////
        // ColorTokenGameEngine()
        //
        // Supplies a String that changes the text to the color of
        // many game engine messages.
        //
        public static string GameEngine()
        {
            return "<c" + GetSubString(ColorArray, 204, 1) +
                    GetSubString(ColorArray, 119, 1) +
                    GetSubString(ColorArray, 255, 1) + ">";
        }

        ///////////////////////////////////////////////////////////////////////////////
        // ColorTokenSavingThrow()
        //
        // Supplies a String that changes the text to the color of
        // saving throw messages.
        //
        public static string SavingThrow()
        {
            return "<c" + GetSubString(ColorArray, 102, 1) +
                    GetSubString(ColorArray, 204, 1) +
                    GetSubString(ColorArray, 255, 1) + ">";
        }

        ///////////////////////////////////////////////////////////////////////////////
        // ColorTokenScript()
        //
        // Supplies a String that changes the text to the color of
        // messages sent from scripts.
        //
        public static string Script()
        {
            return "<c" + GetSubString(ColorArray, 255, 1) +
                    GetSubString(ColorArray, 255, 1) +
                    GetSubString(ColorArray, 0, 1) + ">";
        }

        ///////////////////////////////////////////////////////////////////////////////
        // ColorTokenServer()
        //
        // Supplies a String that changes the text to the color of
        // server messages.
        //
        public static string Server()
        {
            return "<c" + GetSubString(ColorArray, 176, 1) +
                    GetSubString(ColorArray, 176, 1) +
                    GetSubString(ColorArray, 176, 1) + ">";
        }

        ///////////////////////////////////////////////////////////////////////////////
        // ColorTokenShout()
        //
        // Supplies a String that changes the text to the color of
        // shouts.
        //
        public static string Shout()
        {
            return "<c" + GetSubString(ColorArray, 255, 1) +
                    GetSubString(ColorArray, 239, 1) +
                    GetSubString(ColorArray, 80, 1) + ">";
        }

        ///////////////////////////////////////////////////////////////////////////////
        // ColorTokenSkillCheck()
        //
        // Supplies a String that changes the text to the color of
        // skill check messages.
        //
        public static string SkillCheck()
        {
            return "<c" + GetSubString(ColorArray, 0, 1) +
                    GetSubString(ColorArray, 102, 1) +
                    GetSubString(ColorArray, 255, 1) + ">";
        }

        ///////////////////////////////////////////////////////////////////////////////
        // ColorTokenTalk()
        //
        // Supplies a String that changes the text to the color of
        // the talk and party talk channels.
        //
        public static string Talk()
        {
            return "<c" + GetSubString(ColorArray, 240, 1) +
                    GetSubString(ColorArray, 240, 1) +
                    GetSubString(ColorArray, 240, 1) + ">";
        }

        ///////////////////////////////////////////////////////////////////////////////
        // ColorTokenTell()
        //
        // Supplies a String that changes the text to the color of
        // tells.
        //
        public static string Tell()
        {
            return "<c" + GetSubString(ColorArray, 32, 1) +
                    GetSubString(ColorArray, 255, 1) +
                    GetSubString(ColorArray, 32, 1) + ">";
        }

        ///////////////////////////////////////////////////////////////////////////////
        // ColorTokenWhisper()
        //
        // Supplies a String that changes the text to the color of
        // whispers.
        //
        public static string Whisper()
        {
            return "<c" + GetSubString(ColorArray, 128, 1) +
                    GetSubString(ColorArray, 128, 1) +
                    GetSubString(ColorArray, 128, 1) + ">";
        }



        ///////////////////////////////////////////////////////////////////////////////
        // Colored Name Functions
        ///////////////////////////////////////////////////////////////////////////////


        ///////////////////////////////////////////////////////////////////////////////
        // GetNamePCColor()
        //
        // Returns the name of oPC, surrounded by color tokens, so the color of
        // the name is the lighter blue often used in NWN game engine messages.
        //
        //
        public static string GetNamePCColor(NWObject oPC)
        {
            return "<c" + GetSubString(ColorArray, 153, 1) +
                    GetSubString(ColorArray, 255, 1) +
                    GetSubString(ColorArray, 255, 1) + ">" +
                    GetName(oPC) + "</c>";
        }

        ///////////////////////////////////////////////////////////////////////////////
        // GetNameNPCColor()
        //
        // Returns the name of oNPC, surrounded by color tokens, so the color of
        // the name is the shade of purple often used in NWN game engine messages.
        //
        public static string GetNameNPCColor(NWObject oNPC)
        {
            return "<c" + GetSubString(ColorArray, 204, 1) +
                    GetSubString(ColorArray, 153, 1) +
                    GetSubString(ColorArray, 204, 1) + ">" +
                    GetName(oNPC) + "</c>";
        }

    }
}
