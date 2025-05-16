using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spiel_Hinter_Dem_Gruen.UI
{
    class Fussbereich : IZeichenbereich
    {
        private static int _aktuellX = 0;
        private static int _aktuellY = Console.WindowHeight / 2 + 1;
        public static int AktuellX { get { return _aktuellX; } set { _aktuellX = value; } }
        public static int AktuellY { get { return _aktuellY; } set { _aktuellY = value; } }
        public static int StartX { get { return 0; } }
        public static int StartY { get { return Console.WindowHeight / 2 + 1; } }

        public static int EndeX { get { return Console.WindowWidth / 3 * 2 - 1; } }
        public static int EndeY { get { return Console.WindowHeight; } }
        public static void EinstellenInteraktivesMenue(string[] punkte, int auswahl, string text = "")
        {
            if (text.Length != 0)
            {
                Console.SetCursorPosition(_aktuellX, _aktuellY);
                Console.WriteLine(text);
                AktuellY += 1;
            }

            for (int i = 0; i < punkte.Length; i++)
            {

                Console.SetCursorPosition(_aktuellX, _aktuellY + i);

                if (i == auswahl)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                }
                Console.WriteLine(punkte[i]);

                Console.ForegroundColor = ConsoleColor.White;
            }

            AktuellY = Console.WindowHeight / 2 + 1;
        }


        public static void Reset()
        {
            int bereichBreite = EndeX - StartX;

            for (int y = StartY; y < EndeY; y++)
            {
                Console.SetCursorPosition(StartX, y);
                Console.Write("".PadRight(bereichBreite));
            }

            Console.SetCursorPosition(StartX, StartY);
        }

    }
}
