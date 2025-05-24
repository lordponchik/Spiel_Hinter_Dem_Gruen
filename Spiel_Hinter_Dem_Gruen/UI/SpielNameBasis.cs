using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spiel_Hinter_Dem_Gruen.Ressourcen;

namespace Spiel_Hinter_Dem_Gruen.UI
{
    abstract class SpielTitelBasis
    {
        private static SpielNameDaten daten = LadeJson.LadenSpielName();
        protected readonly string[][] _spielTitel = daten.SpielTitel!;
        protected readonly string _subtitle = daten.SubTitle!;

        public void ZeigeSpielName()
        {
            Console.Clear();

            Thread.Sleep(1000);

            int anzahlTitelZeichen = _spielTitel.Sum(column => column[0].Length + 1) - 1;

            for (int i = 0; i < _spielTitel[0].Length; i += 1)
            {
                SetzePositionSpielTitel(anzahlTitelZeichen: anzahlTitelZeichen, anzahlTitelZeilen: _spielTitel[0].Length, aktuellY: i);

                for (int j = 0; j < _spielTitel.Length; j += 1)
                {
                    if (j == 2) Console.ForegroundColor = ConsoleColor.Green;

                    Console.Write(_spielTitel[j][i] + " ");

                    Console.ForegroundColor = ConsoleColor.White;
                }

                Console.WriteLine();

                Thread.Sleep(75);
            }

            SetzePositionSubTitle(anzahlTitelZeichen: anzahlTitelZeichen, anzahlSubTitleZeichen: _subtitle.Length);

            foreach (char zeichen in _subtitle)
            {
                Console.Write(zeichen);
                Thread.Sleep(50);
            }

            Thread.Sleep(1000);

            Console.WriteLine();
        }

        protected abstract void SetzePositionSpielTitel(int anzahlTitelZeichen, int anzahlTitelZeilen, int aktuellY);
        protected abstract void SetzePositionSubTitle(int anzahlTitelZeichen, int anzahlSubTitleZeichen);
    }
}