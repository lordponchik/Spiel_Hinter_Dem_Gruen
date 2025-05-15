using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spiel_Hinter_Dem_Gruen
{
    class Kopfbereich : IZeichenbereich
    {
        private static int _aktuellX = 0;
        private static int _aktuellY = EndeY - 1;
        public static int StartX { get { return 0; } }
        public static int StartY { get { return 0; } }

        public static int EndeX { get { return Console.WindowWidth / 3 * 2 - 1; } }
        public static int EndeY { get { return Console.WindowHeight / 2 - 1; } }

        public static int AktuellX { get { return _aktuellX; } set { _aktuellX = value; } }

        public static int AktuellY { get { return _aktuellY; } set { _aktuellY = value; } }


        public static void EinstellenAusgabeInformation(List<string> texte)
        {
            AktuellY -= texte.Count;

            foreach (string text in texte)
            {
                Console.SetCursorPosition(AktuellX, AktuellY);
                Console.Write(text);
                AktuellY += 1;
            }
        }
        public static void Reset()
        {
            AktuellX = StartX;
            AktuellY = StartY;
            Console.SetCursorPosition(AktuellX, AktuellY);

            for (int i = 0; i < EndeY; i++)
            {
                Console.WriteLine("                                                                                                             ");
            }
            AktuellX = StartX;
            AktuellY = EndeY-1;

        }
    }


}
