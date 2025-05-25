using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spiel_Hinter_Dem_Gruen.UI
{
    class InteraktivesMenue
    {
        private string[] _menuePunkte;
        private int _aktuellerIndex = 0;
        private Action<string[], int, string, bool> _renderAction;

        public InteraktivesMenue(string[] menuePunkte, Action<string[], int, string, bool> renderAction)
        {
            _menuePunkte = menuePunkte;
            _renderAction = renderAction;
        }

        public int AnzeigenUndAuswaehlen(string titel = "", bool istZentriert = false)
        {
            ConsoleKey eingabe;

            do
            {
                _renderAction(_menuePunkte, _aktuellerIndex, titel, istZentriert);

                eingabe = Console.ReadKey(true).Key;

                switch (eingabe)
                {
                    case ConsoleKey.DownArrow:
                        _aktuellerIndex = _aktuellerIndex == _menuePunkte.Length - 1 ? 0 : _aktuellerIndex + 1;
                        break;
                    case ConsoleKey.UpArrow:
                        _aktuellerIndex = _aktuellerIndex == 0 ? _menuePunkte.Length - 1 : _aktuellerIndex - 1;
                        break;
                }

            } while (eingabe != ConsoleKey.Enter);

            return _aktuellerIndex;
        }
    }
}

