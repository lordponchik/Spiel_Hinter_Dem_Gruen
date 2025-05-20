using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spiel_Hinter_Dem_Gruen.UI
{
    class Ladebildschirm
    {
        private static string _ladenText = "L A D E N . . .";
        public static void ZeigeLadebildschirm(int wiederholungen = 1)
        {
            Console.Clear();

            int x = Console.WindowWidth / 2 - _ladenText.Length / 2;
            int y = Console.WindowHeight / 2;

            while (wiederholungen > 0)
            {

                ZeigeTextAnimiert(x, y, true);

                Thread.Sleep(1000);

                ZeigeTextAnimiert(x,y);

                wiederholungen--;
            }

            Console.Clear();
        }

        private static void ZeigeTextAnimiert(int x, int y, bool sichtbar = false)
        {
            Console.SetCursorPosition(x, y);

            foreach (char zeichnen in _ladenText)
            {
                Console.Write(sichtbar ? zeichnen : " ");
                Thread.Sleep(50);
            }
        }
    }
}
