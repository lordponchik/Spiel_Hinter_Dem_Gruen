using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spiel_Hinter_Dem_Gruen.UI
{
    class Hauptmenue : SpielTitelBasis
    {
        

        private string[] _punkteMenue = { "Neues Spiel", "Ausgang" };
        private ZentrierterBereich _zentrierterBereich = new ZentrierterBereich();

        public string[] PunkteMenue { get { return _punkteMenue; } }

        protected override void SetzePositionSpielTitel(int anzahlTitelZeichen, int anzahlTitelZeilen, int aktuellY)
        {
            int xPos = (Console.WindowWidth - anzahlTitelZeichen) / 2;
            int yPos = anzahlTitelZeilen + aktuellY;

            Console.SetCursorPosition(xPos, yPos);
        }

        protected override void SetzePositionSubTitle(int anzahlTitelZeichen, int anzahlSubTitleZeichen)
        {
            int xPos = (Console.WindowWidth - anzahlTitelZeichen) / 2 + (anzahlTitelZeichen - anzahlSubTitleZeichen);
            int yPos = Console.GetCursorPosition().Top + 2;

            Console.SetCursorPosition(xPos, yPos);
        }

        public Hauptmenue()
        {
            ZeigeSpielName();
        }

        public int Auswahl()
        {
            InteraktivesMenue menue = new(_punkteMenue, _zentrierterBereich.EinstellenInteraktivesMenue);

            return menue.ZeigeUndWähle(istZentriert: true);
        }
    }
}
