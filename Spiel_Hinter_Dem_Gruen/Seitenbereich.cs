using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spiel_Hinter_Dem_Gruen
{
    class Seitenbereich : IZeichenbereich
    {
        private static int _aktuellX = Console.WindowWidth / 3 * 2 + 1;
        private static int _aktuellY = 0;

        public static int StartX { get { return Console.WindowWidth / 3 * 2 + 1; } }
        public static int StartY { get { return 0; } }

        public static int EndeX { get { return Console.WindowWidth; } }
        public static int EndeY { get { return Console.WindowHeight; } }

        public static int AktuellX { get { return _aktuellX; } set { _aktuellX = value; } }

        public static int AktuellY { get { return _aktuellY; } set { _aktuellY = value; } }

        public Seitenbereich()
        {
            _aktuellX = StartX;
            _aktuellY = StartY;
        }

        public void Ausgeben(string[] text)
        {
            for (int i = 0; i < text.Length; i++)
            {
                Console.SetCursorPosition(AktuellX, AktuellY);
                Console.WriteLine(text[i]);
                AktuellX = StartX;
                AktuellY++;
            }
        }
    }
}
