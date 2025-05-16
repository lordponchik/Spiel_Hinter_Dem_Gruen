using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spiel_Hinter_Dem_Gruen
{
    class Hauptmenue : SpielNameBasis
    {
        private string[] _punkteMenue;

        public string[] PunkteMenue { get { return _punkteMenue; } }

        protected override void SetPositionSpielName(int anzahlIntroZeichen, int anzahlIntroZeilen, int yPosIndex)
        {
            int xPos = (Console.WindowWidth - anzahlIntroZeichen) / 2;
            int yPos = anzahlIntroZeilen + yPosIndex;

            Console.SetCursorPosition(xPos, yPos);
        }

        protected override void SetPositionExtraText(int anzahlIntroZeichen, int anzahlIntroExtraZeichen)
        {
            int xPos = (Console.WindowWidth - anzahlIntroZeichen) / 2 + (anzahlIntroZeichen - anzahlIntroExtraZeichen);
            int yPos = Console.GetCursorPosition().Top + 2;

            Console.SetCursorPosition(xPos, yPos);
        }

        public Hauptmenue(string[] punkteMenue)
        {
           
            _punkteMenue = punkteMenue;
        }
    }
}
