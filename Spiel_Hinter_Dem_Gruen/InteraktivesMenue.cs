using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spiel_Hinter_Dem_Gruen
{
    class InteraktivesMenue
    {
        private string[] _punkte;
        private int _auswahl = 0;
        private Action<string[], int> _rendering;

        public InteraktivesMenue(string[] punkte, Action<string[], int> rendering)
        {
            _punkte = punkte;
            _rendering = rendering;
        }

        public int ZeigeUndWähle()
        {
            ConsoleKey eingabe;

            do
            {
                _rendering(_punkte, _auswahl);

                eingabe = Console.ReadKey(true).Key;

                switch (eingabe)
                {
                    case ConsoleKey.DownArrow:
                        _auswahl = _auswahl == _punkte.Length - 1 ? 0 : _auswahl + 1;
                        break;
                    case ConsoleKey.UpArrow:
                        _auswahl = _auswahl == 0 ? _punkte.Length - 1 : _auswahl - 1;
                        break;
                }

            } while (eingabe != ConsoleKey.Enter);

            return _auswahl;
        }

    }

}

