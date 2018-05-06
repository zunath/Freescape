using Freescape.Game.Server.GameObject;
using NWN;

namespace Freescape.Game.Server.Helper
{
    public class ColorTokenService : IColorTokenService
    {
        private readonly INWScript _script;

        public ColorTokenService(INWScript script)
        {
            _script = script;
        }


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
        public string Custom(int nRed, int nGreen, int nBlue)
        {
            return "<c" + _script.GetSubString(ColorArray, nRed, 1) +
                    _script.GetSubString(ColorArray, nGreen, 1) +
                    _script.GetSubString(ColorArray, nBlue, 1) + ">";
        }

        ///////////////////////////////////////////////////////////////////////////////
        // ColorTokenEnd()
        //
        // Supplies a String that ends an earlier color change.
        //
        public  string End()
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
        public  string Black()
        {
            return "<c" + _script.GetSubString(ColorArray, 0, 1) +
                    _script.GetSubString(ColorArray, 0, 1) +
                    _script.GetSubString(ColorArray, 0, 1) + ">";
        }

        ///////////////////////////////////////////////////////////////////////////////
        // ColorTokenBlue()
        //
        // Supplies a String that changes the text to blue.
        //
        public  string Blue()
        {
            return "<c" + _script.GetSubString(ColorArray, 0, 1) +
                    _script.GetSubString(ColorArray, 0, 1) +
                    _script.GetSubString(ColorArray, 255, 1) + ">";
        }

        ///////////////////////////////////////////////////////////////////////////////
        // ColorTokenGray()
        //
        // Supplies a String that changes the text to gray.
        //
        public  string Gray()
        {
            return "<c" + _script.GetSubString(ColorArray, 127, 1) +
                    _script.GetSubString(ColorArray, 127, 1) +
                    _script.GetSubString(ColorArray, 127, 1) + ">";
        }

        ///////////////////////////////////////////////////////////////////////////////
        // ColorTokenGreen()
        //
        // Supplies a String that changes the text to green.
        //
        public  string Green()
        {
            return "<c" + _script.GetSubString(ColorArray, 0, 1) +
                    _script.GetSubString(ColorArray, 255, 1) +
                    _script.GetSubString(ColorArray, 0, 1) + ">";
        }

        ///////////////////////////////////////////////////////////////////////////////
        // ColorTokenLightPurple()
        //
        // Supplies a String that changes the text to light purple.
        //
        public  string LightPurple()
        {
            return "<c" + _script.GetSubString(ColorArray, 175, 1) +
                    _script.GetSubString(ColorArray, 48, 1) +
                    _script.GetSubString(ColorArray, 255, 1) + ">";
        }

        ///////////////////////////////////////////////////////////////////////////////
        // ColorTokenOrange()
        //
        // Supplies a String that changes the text to orange.
        //
        public  string Orange()
        {
            return "<c" + _script.GetSubString(ColorArray, 255, 1) +
                    _script.GetSubString(ColorArray, 127, 1) +
                    _script.GetSubString(ColorArray, 0, 1) + ">";
        }

        ///////////////////////////////////////////////////////////////////////////////
        // ColorTokenPink()
        //
        // Supplies a String that changes the text to pink.
        //
        public  string Pink()
        {
            return "<c" + _script.GetSubString(ColorArray, 255, 1) +
                    _script.GetSubString(ColorArray, 0, 1) +
                    _script.GetSubString(ColorArray, 255, 1) + ">";
        }

        ///////////////////////////////////////////////////////////////////////////////
        // ColorTokenPurple()
        //
        // Supplies a String that changes the text to purple.
        //
        public  string Purple()
        {
            return "<c" + _script.GetSubString(ColorArray, 127, 1) +
                    _script.GetSubString(ColorArray, 0, 1) +
                    _script.GetSubString(ColorArray, 255, 1) + ">";
        }

        ///////////////////////////////////////////////////////////////////////////////
        // ColorTokenRed()
        //
        // Supplies a String that changes the text to red.
        //
        public  string Red()
        {
            return "<c" + _script.GetSubString(ColorArray, 255, 1) +
                    _script.GetSubString(ColorArray, 0, 1) +
                    _script.GetSubString(ColorArray, 0, 1) + ">";
        }

        ///////////////////////////////////////////////////////////////////////////////
        // ColorTokenWhite()
        //
        // Supplies a String that changes the text to white.
        //
        public  string White()
        {
            return "<c" + _script.GetSubString(ColorArray, 255, 1) +
                    _script.GetSubString(ColorArray, 255, 1) +
                    _script.GetSubString(ColorArray, 255, 1) + ">";
        }

        ///////////////////////////////////////////////////////////////////////////////
        // ColorTokenYellow()
        //
        // Supplies a String that changes the text to yellow.
        //
        public  string Yellow()
        {
            return "<c" + _script.GetSubString(ColorArray, 255, 1) +
                    _script.GetSubString(ColorArray, 255, 1) +
                    _script.GetSubString(ColorArray, 0, 1) + ">";
        }



        ///////////////////////////////////////////////////////////////////////////////
        // ColorTokenCyan()
        //
        // Supplies a String that changes the text to yellow.
        //
        public  string Cyan()
        {
            return "<c" + _script.GetSubString(ColorArray, 0, 1) +
                    _script.GetSubString(ColorArray, 255, 1) +
                    _script.GetSubString(ColorArray, 255, 1) + ">";
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
        public  string Combat()
        {
            return "<c" + _script.GetSubString(ColorArray, 255, 1) +
                    _script.GetSubString(ColorArray, 102, 1) +
                    _script.GetSubString(ColorArray, 0, 1) + ">";
        }

        ///////////////////////////////////////////////////////////////////////////////
        // ColorTokenDialog()
        //
        // Supplies a String that changes the text to the color of
        // dialog.
        //
        public  string Dialog()
        {
            return "<c" + _script.GetSubString(ColorArray, 255, 1) +
                    _script.GetSubString(ColorArray, 255, 1) +
                    _script.GetSubString(ColorArray, 255, 1) + ">";
        }

        ///////////////////////////////////////////////////////////////////////////////
        // ColorTokenDialogAction()
        //
        // Supplies a String that changes the text to the color of
        // dialog actions.
        //
        public  string DialogAction()
        {
            return "<c" + _script.GetSubString(ColorArray, 1, 1) +
                    _script.GetSubString(ColorArray, 254, 1) +
                    _script.GetSubString(ColorArray, 1, 1) + ">";
        }

        ///////////////////////////////////////////////////////////////////////////////
        // ColorTokenDialogCheck()
        //
        // Supplies a String that changes the text to the color of
        // dialog checks.
        //
        public  string DialogCheck()
        {
            return "<c" + _script.GetSubString(ColorArray, 254, 1) +
                    _script.GetSubString(ColorArray, 1, 1) +
                    _script.GetSubString(ColorArray, 1, 1) + ">";
        }

        ///////////////////////////////////////////////////////////////////////////////
        // ColorTokenDialogHighlight()
        //
        // Supplies a String that changes the text to the color of
        // dialog highlighting.
        //
        public  string DialogHighlight()
        {
            return "<c" + _script.GetSubString(ColorArray, 1, 1) +
                    _script.GetSubString(ColorArray, 1, 1) +
                    _script.GetSubString(ColorArray, 254, 1) + ">";
        }

        ///////////////////////////////////////////////////////////////////////////////
        // ColorTokenDialogReply()
        //
        // Supplies a String that changes the text to the color of
        // replies in the dialog window.
        //
        public  string DialogReply()
        {
            return "<c" + _script.GetSubString(ColorArray, 102, 1) +
                    _script.GetSubString(ColorArray, 178, 1) +
                    _script.GetSubString(ColorArray, 255, 1) + ">";
        }

        ///////////////////////////////////////////////////////////////////////////////
        // ColorTokenDM()
        //
        // Supplies a String that changes the text to the color of
        // the DM channel.
        //
        public  string DM()
        {
            return "<c" + _script.GetSubString(ColorArray, 16, 1) +
                    _script.GetSubString(ColorArray, 223, 1) +
                    _script.GetSubString(ColorArray, 255, 1) + ">";
        }

        ///////////////////////////////////////////////////////////////////////////////
        // ColorTokenGameEngine()
        //
        // Supplies a String that changes the text to the color of
        // many game engine messages.
        //
        public  string GameEngine()
        {
            return "<c" + _script.GetSubString(ColorArray, 204, 1) +
                    _script.GetSubString(ColorArray, 119, 1) +
                    _script.GetSubString(ColorArray, 255, 1) + ">";
        }

        ///////////////////////////////////////////////////////////////////////////////
        // ColorTokenSavingThrow()
        //
        // Supplies a String that changes the text to the color of
        // saving throw messages.
        //
        public  string SavingThrow()
        {
            return "<c" + _script.GetSubString(ColorArray, 102, 1) +
                    _script.GetSubString(ColorArray, 204, 1) +
                    _script.GetSubString(ColorArray, 255, 1) + ">";
        }

        ///////////////////////////////////////////////////////////////////////////////
        // ColorTokenScript()
        //
        // Supplies a String that changes the text to the color of
        // messages sent from scripts.
        //
        public  string Script()
        {
            return "<c" + _script.GetSubString(ColorArray, 255, 1) +
                    _script.GetSubString(ColorArray, 255, 1) +
                    _script.GetSubString(ColorArray, 0, 1) + ">";
        }

        ///////////////////////////////////////////////////////////////////////////////
        // ColorTokenServer()
        //
        // Supplies a String that changes the text to the color of
        // server messages.
        //
        public  string Server()
        {
            return "<c" + _script.GetSubString(ColorArray, 176, 1) +
                    _script.GetSubString(ColorArray, 176, 1) +
                    _script.GetSubString(ColorArray, 176, 1) + ">";
        }

        ///////////////////////////////////////////////////////////////////////////////
        // ColorTokenShout()
        //
        // Supplies a String that changes the text to the color of
        // shouts.
        //
        public  string Shout()
        {
            return "<c" + _script.GetSubString(ColorArray, 255, 1) +
                    _script.GetSubString(ColorArray, 239, 1) +
                    _script.GetSubString(ColorArray, 80, 1) + ">";
        }

        ///////////////////////////////////////////////////////////////////////////////
        // ColorTokenSkillCheck()
        //
        // Supplies a String that changes the text to the color of
        // skill check messages.
        //
        public  string SkillCheck()
        {
            return "<c" + _script.GetSubString(ColorArray, 0, 1) +
                    _script.GetSubString(ColorArray, 102, 1) +
                    _script.GetSubString(ColorArray, 255, 1) + ">";
        }

        ///////////////////////////////////////////////////////////////////////////////
        // ColorTokenTalk()
        //
        // Supplies a String that changes the text to the color of
        // the talk and party talk channels.
        //
        public  string Talk()
        {
            return "<c" + _script.GetSubString(ColorArray, 240, 1) +
                    _script.GetSubString(ColorArray, 240, 1) +
                    _script.GetSubString(ColorArray, 240, 1) + ">";
        }

        ///////////////////////////////////////////////////////////////////////////////
        // ColorTokenTell()
        //
        // Supplies a String that changes the text to the color of
        // tells.
        //
        public  string Tell()
        {
            return "<c" + _script.GetSubString(ColorArray, 32, 1) +
                    _script.GetSubString(ColorArray, 255, 1) +
                    _script.GetSubString(ColorArray, 32, 1) + ">";
        }

        ///////////////////////////////////////////////////////////////////////////////
        // ColorTokenWhisper()
        //
        // Supplies a String that changes the text to the color of
        // whispers.
        //
        public  string Whisper()
        {
            return "<c" + _script.GetSubString(ColorArray, 128, 1) +
                    _script.GetSubString(ColorArray, 128, 1) +
                    _script.GetSubString(ColorArray, 128, 1) + ">";
        }



        ///////////////////////////////////////////////////////////////////////////////
        // Colored Name Functions
        ///////////////////////////////////////////////////////////////////////////////


        ///////////////////////////////////////////////////////////////////////////////
        // _script.GetNamePCColor()
        //
        // Returns the name of oPC, surrounded by color tokens, so the color of
        // the name is the lighter blue often used in NWN game engine messages.
        //
        //
        public  string GetNamePCColor(NWObject oPC)
        {
            return "<c" + _script.GetSubString(ColorArray, 153, 1) +
                    _script.GetSubString(ColorArray, 255, 1) +
                    _script.GetSubString(ColorArray, 255, 1) + ">" +
                    _script.GetName(oPC.Object) + "</c>";
        }

        ///////////////////////////////////////////////////////////////////////////////
        // _script.GetNameNPCColor()
        //
        // Returns the name of oNPC, surrounded by color tokens, so the color of
        // the name is the shade of purple often used in NWN game engine messages.
        //
        public string GetNameNPCColor(NWObject oNPC)
        {
            return "<c" + _script.GetSubString(ColorArray, 204, 1) +
                    _script.GetSubString(ColorArray, 153, 1) +
                    _script.GetSubString(ColorArray, 204, 1) + ">" +
                    _script.GetName(oNPC.Object) + "</c>";
        }

    }
}
