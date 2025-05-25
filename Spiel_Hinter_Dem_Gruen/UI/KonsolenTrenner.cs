using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spiel_Hinter_Dem_Gruen.UI
{
    class KonsolenTrenner
    {
        public static void ZeichneTrennlinien()
        {
            Console.Clear();

            int fensterBreite = Console.WindowWidth;
            int  fensterHoehe = Console.WindowHeight;

            int trennLinieX = fensterBreite / 3 * 2;
            int trennLinieY = fensterHoehe / 2;

            for (int i = 0; i < fensterHoehe; i++)
            {
                Console.SetCursorPosition(trennLinieX, i);
                Console.Write("|");
            }
            for (int i = 0; i < trennLinieX; i++)
            {
                Console.SetCursorPosition(i, trennLinieY);
                Console.Write("=");
            }
        }
    }
}
