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
                Console.SetCursorPosition(x, y);

                for (int i = 0; i < _ladenText.Length; i++)
                {
                    Console.Write(_ladenText[i]);
                    Thread.Sleep(50);
                }

                Thread.Sleep(1000);

                Console.SetCursorPosition(x, y);

                for (int i = 0; i < _ladenText.Length; i++)
                {
                    Console.Write(" ");
                    Thread.Sleep(50);
                }

                wiederholungen--;
            }

            Console.Clear();
        }
    }
}
