using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spiel_Hinter_Dem_Gruen
{
    abstract class SpielNameBasis
    {
        protected static readonly string[][] introText = {
        new string[]{
" _   _ _       _            ",
"| | | (_)     | |           ",
"| |_| |_ _ __ | |_ ___ _ __ ",
"|  _  | | '_ \\| __/ _ \\ '__|",
"| | | | | | | | ||  __/ |   ",
"\\_| |_/_|_| |_|\\__\\___|_|   ",},
        new string[]{
"     _                ",
"    | |               ",
"  __| | ___ _ __ ___  ",
" / _` |/ _ \\ '_ ` _ \\ ",
"| (_| |  __/ | | | | |",
" \\__,_|\\___|_| |_| |_|",},
        new string[]{
" _____      _   _       ",
"|  __ \\    (_) (_)      ",
"| |  \\/_ __ _   _ _ __  ",
"| | __| '__| | | | '_ \\ ",
"| |_\\ \\ |  | |_| | | | |",
" \\____/_|   \\__,_|_| |_|",},
    };

        protected static readonly string introExtraText = "Auf der Suche nach dem Verbotenen...";

        public void ZeigeSpielName()
        {
            Console.Clear();

            Thread.Sleep(1000);

            int anzahlIntroZeichen = introText.Sum(column => column[0].Length + 1) - 1;

            for (int i = 0; i < introText[0].Length; i++)
            {

                SetPositionSpielName(anzahlIntroZeichen: anzahlIntroZeichen, anzahlIntroZeilen: introText[0].Length, yPosIndex: i);

                for (int j = 0; j < introText.Length; j++)
                {
                    if (j == 2) Console.ForegroundColor = ConsoleColor.Green;

                    Console.Write(introText[j][i] + " ");
                    Console.ForegroundColor = ConsoleColor.White;
                }

                Console.WriteLine();

                Thread.Sleep(300);
            }

            SetPositionExtraText(anzahlIntroZeichen: anzahlIntroZeichen, anzahlIntroExtraZeichen: introExtraText.Length);

            foreach (char zeichen in introExtraText)
            {
                Console.Write(zeichen);
                Thread.Sleep(50);
            }

            Thread.Sleep(1000);
            Console.WriteLine();
        }

        protected abstract void SetPositionSpielName(int anzahlIntroZeichen, int anzahlIntroZeilen, int yPosIndex);
        protected abstract void SetPositionExtraText(int anzahlIntroZeichen, int anzahlIntroExtraZeichen);
    }
}


/*
" _   _ _       _                  _                  _____      _   _       "
"| | | (_)     | |                | |                |  __ \    (_) (_)      "
"| |_| |_ _ __ | |_ ___ _ __    __| | ___ _ __ ___   | |  \/_ __ _   _ _ __  "
"|  _  | | '_ \| __/ _ \ '__|  / _` |/ _ \ '_ ` _ \  | | __| '__| | | | '_ \ "
"| | | | | | | | ||  __/ |    | (_| |  __/ | | | | | | |_\ \ |  | |_| | | | |"
"\_| |_/_|_| |_|\__\___|_|     \__,_|\___|_| |_| |_|  \____/_|   \__,_|_| |_|"


"hinter"

" _   _ _       _            "
"| | | (_)     | |           "
"| |_| |_ _ __ | |_ ___ _ __ "
"|  _  | | '_ \| __/ _ \ '__|"
"| | | | | | | | ||  __/ |   "
"\_| |_/_|_| |_|\__\___|_|   "

"dem"

"     _                "
"    | |               "
"  __| | ___ _ __ ___  "
" / _` |/ _ \ '_ ` _ \ "
"| (_| |  __/ | | | | |"
" \__,_|\___|_| |_| |_|"

"Grün"

" _____      _   _       "
"|  __ \    (_) (_)      "
"| |  \/_ __ _   _ _ __  "
"| | __| '__| | | | '_ \ "
"| |_\ \ |  | |_| | | | |"
" \____/_|   \__,_|_| |_|"
*/