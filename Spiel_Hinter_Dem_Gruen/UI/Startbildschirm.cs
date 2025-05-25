using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spiel_Hinter_Dem_Gruen.UI
{
    class Startbildschirm : SpielTitelBasis
    {
        protected override void SetzePositionSpielTitel(int anzahlTitelZeichen, int anzahlTitelZeilen, int aktuellY)
        {
            int xPos = (Console.WindowWidth - anzahlTitelZeichen) / 2;
            int yPos = Console.WindowHeight / 2 - anzahlTitelZeichen / 2 + aktuellY;

            Console.SetCursorPosition(xPos, yPos);
        }

        protected override void SetzePositionSubTitle(int anzahlTitelZeichen, int anzahlSubTitleZeichen)
        {
            int xPos = (Console.WindowWidth - anzahlTitelZeichen) / 2 + (anzahlTitelZeichen - anzahlSubTitleZeichen);
            int yPos = Console.GetCursorPosition().Top + 2;

            Console.SetCursorPosition(xPos, yPos);
        }
    }
}
