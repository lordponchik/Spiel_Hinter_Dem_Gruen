using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spiel_Hinter_Dem_Gruen
{
    class KampfLog
    {
        public static Dictionary<string, List<string>> ErstelleLog(Kaempfer spieler, Kaempfer gegner)
        {
            Seitenbereich.Reset();

            string spielerWaffe = "";
            string gegnerWaffe = "";

            if (spieler.AktiveWaffe != null) spielerWaffe = $"{spieler.AktiveWaffe.Name}: +{spieler.AktiveWaffe.Wert} Max-Schaden";
            if (gegner.AktiveWaffe != null) gegnerWaffe = $"{gegner.AktiveWaffe.Name}: +{gegner.AktiveWaffe.Wert} Max-Schaden";

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
