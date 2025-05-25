using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spiel_Hinter_Dem_Gruen.UI
{
    abstract class ZeichenbereichBase : IZeichenbereich
    {
        public abstract int StartX { get; }
        public abstract int StartY { get; }

        public abstract int EndeX { get; }
        public abstract int EndeY { get; }

        public abstract int AktuellX { get; set; }
        public abstract int AktuellY { get; set; }

        public int Breite { get { return EndeX - StartX; } }
        public int Hoehe { get { return EndeY - StartY; } }


        public void Reset()
        {
            AktuellX = StartX;
            AktuellY = StartY;

            for (; AktuellY < EndeY; AktuellY += 1)
            {
                Console.SetCursorPosition(StartX, AktuellY);
                Console.Write(new string(' ', Breite));
            }

            AktuellX = StartX;
            AktuellY = StartY;
        }

        public void EinstellenInteraktivesMenue(string[] menuePunkte, int auswahl, string titel = "", bool istZentriert = false)
        {
            AktuellX = StartX;
            AktuellY = StartY;

            if (istZentriert) AktuellY = (EndeY - menuePunkte.Length) / 2;

            if (titel.Length != 0)
            {
                Console.SetCursorPosition(AktuellX, AktuellY);
                Console.WriteLine(titel);
                AktuellY += 1;
            }

            AktuellX = StartX;

            for (int i = 0; i < menuePunkte.Length; i += 1)
            {
                if (istZentriert) AktuellX = (EndeX - menuePunkte[i].Length) / 2;

                Console.SetCursorPosition(AktuellX, AktuellY + i);

                if (i == auswahl) Console.ForegroundColor = ConsoleColor.Green;

                Console.Write(menuePunkte[i]);

                Console.ForegroundColor = ConsoleColor.White;
            }

            AktuellX = StartX;
            AktuellY = StartY;

        }

        public void EinstellenAusgabeInformation(List<string> textZeilen, bool istZentriert = false)
        {
            AktuellX = StartX;
            AktuellY = StartY;

            if (istZentriert) AktuellY = (EndeY - textZeilen.Count) / 2;

            for (int i = 0; i < textZeilen.Count; i += 1)
            {
                if (istZentriert) AktuellX = (EndeX - textZeilen[i].Length) / 2;

                Console.SetCursorPosition(AktuellX, AktuellY+i);

                Console.Write(textZeilen[i]);
            }

            AktuellX = StartX;
            AktuellY = StartY;
        }

    }
}

