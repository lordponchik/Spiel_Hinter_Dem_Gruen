using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spiel_Hinter_Dem_Gruen.UI;

namespace Spiel_Hinter_Dem_Gruen.Spiel
{
    class KampfLog
    {
        private static Seitenbereich _seitenbereich = new Seitenbereich();

        public static Dictionary<string, List<string>> ErstelleLog(Kaempfer spieler, Kaempfer gegner)
        {
            _seitenbereich.Reset();

            string spielerWaffe = "";
            string gegnerWaffe = "";

            if (spieler.AktiveWaffe != null) spielerWaffe = $"{spieler.AktiveWaffe.Name}: +{spieler.AktiveWaffe.Schadenswert} Max-Schaden";
            if (gegner.AktiveWaffe != null) gegnerWaffe = $"{gegner.AktiveWaffe.Name}: +{gegner.AktiveWaffe.Schadenswert} Max-Schaden";

            Dictionary<string, List<string>> logs = new Dictionary<string, List<string>>
            {
                {
                    "titel", new List<string>{$"Kampf gegen {gegner.Name}"}
                },
                 {
                    "trenner1", new List<string>{"---------------------------------"}

                },
                {
                    $"{spieler.Name}", new List<string>{$"Name: {spieler.Name}", $"HP: {spieler.Leben}", $"Max-Schaden: {spieler.Schaden}"}
                },
                                 {
                    "trenner2", new List<string>{"---------------------------------"}

                },
                {
                    $"{gegner.Name}", new List<string>{$"Name: {gegner.Name}", $"HP: {gegner.Leben}", $"Max-Schaden: {gegner.Schaden}"}
                },
                 {
                    "trenner3", new List<string>{"---------------------------------"}

                },
                {
                    "beschreibung", new List<string>()
                },


            };

            if (spielerWaffe.Length != 0) logs[spieler.Name].Add($"{spielerWaffe}");
            if (gegnerWaffe.Length != 0) logs[gegner.Name].Add($"{gegnerWaffe}");

            return logs;
        }
    }
}
