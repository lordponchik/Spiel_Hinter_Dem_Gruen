using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spiel_Hinter_Dem_Gruen
{
    class ZentrierterBereich : IZeichenbereich
    {
        private static int _aktuellX;
        private static int _aktuellY = EndeY / 2;
        public static int StartX { get { return 0; } }
        public static int StartY { get { return 0; } }

        public static int EndeX { get { return  Console.WindowWidth; } }
        public static int EndeY { get { return Console.WindowHeight; } }

        public static int AktuellX { get { return _aktuellX; } set { _aktuellX = value; } }

        public static int AktuellY { get { return _aktuellY; } set { _aktuellY = value; } }

        public static void EinstellenInteraktivesMenue(string[] punkte, int auswahl)
        {
            for (int i = 0; i < punkte.Length; i++)
            {
                int xPos = (EndeX - punkte[i].Length) / 2;
                int yPos = EndeY / 2 + i;

                Console.SetCursorPosition(xPos, yPos);

                if (i == auswahl)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                }
                Console.WriteLine(punkte[i]);

                Console.ForegroundColor = ConsoleColor.White;
            }

        }
        public static void EinstellenAusgabeInformation(string text)
        {
            int xPos = (EndeX - text.Length) / 2;

            Console.SetCursorPosition(xPos, AktuellY);

            Console.Write(text);

            AktuellY += 1;
        }
        public static void WerteZurücksetzen()
        {
            AktuellY = EndeY / 2;
        }
    }
}
