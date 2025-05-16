using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spiel_Hinter_Dem_Gruen.UI
{
    class KonsolenTrenner
    {
        private static int fensterBreite;
        private static int fensterHoehe;

        private static int trennlinieX;
        private static int trennlinieY;

        public static void ZeichneTrenner()
        {
            Console.Clear();

            fensterBreite = Console.WindowWidth;
            fensterHoehe = Console.WindowHeight;

            trennlinieX = fensterBreite / 3 * 2;
            trennlinieY = fensterHoehe / 2;

            for (int i = 0; i < fensterHoehe; i++)
            {
                Console.SetCursorPosition(trennlinieX, i);
                Console.Write("|");
            }
            for (int i = 0; i < trennlinieX; i++)
            {
                Console.SetCursorPosition(i, trennlinieY);
                Console.Write("=");
            }
        }
    }
}
