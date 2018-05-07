using Freescape.Game.Server.Helper;
using Freescape.Game.Server.Service.Contracts;

namespace Freescape.Game.Server.Service
{
    public class MenuService: IMenuService
    {
        private readonly IColorTokenService _color;

        public MenuService(IColorTokenService color)
        {
            _color = color;
        }

        public string BuildBar(int currentValue, int requiredValue, int numberOfBars, string colorToken = null)
        {
            if (colorToken == null)
                colorToken = _color.Orange();

            string xpBar = string.Empty;
            int highlightedBars = (int)(currentValue / (float)requiredValue * numberOfBars);

            for (int bar = 1; bar <= numberOfBars; bar++)
            {
                if (bar <= highlightedBars)
                {
                    xpBar += colorToken + "|" + _color.End();
                }
                else
                {
                    xpBar += _color.White() + "|" + _color.End();
                }
            }
            
            return xpBar;
        }
    }
}
