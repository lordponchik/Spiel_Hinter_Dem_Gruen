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
        public static Dictionary<string, List<string>> ErstelleLog(Kaempfer spieler, Kaempfer gegner)
        {
            string spielerWaffe = "";
            string gegnerWaffe = "";

            if (spieler.AktiveWaffe != null) spielerWaffe = $"{spieler.AktiveWaffe.Name}: +{spieler.AktiveWaffe.Schadenswert} Max-Schaden";
            if (gegner.AktiveWaffe != null) gegnerWaffe = $"{gegner.AktiveWaffe.Name}: +{gegner.AktiveWaffe.Schadenswert} Max-Schaden";

            Dictionary<string, List<string>> logs = new Dictionary<string, List<string>>
            {
                {
                    "Titel", new List<string>{$"Kampf gegen {gegner.Name}"}
                },
                 {
                    "TrennerOben", new List<string>{"---------------------------------"}
                },
                {
                    $"{spieler.Name}", new List<string>{$"Name: {spieler.Name}", $"Lebenspunkte: {spieler.LebensPunkte} / {spieler.MaxLebensPunkte}", $"Schaden: {spieler.Schaden / 2} bis {spieler.Schaden}"}
                },
                                 {
                    "TrennerMitte", new List<string>{"---------------------------------"}
                },
                {
                    $"{gegner.Name}", new List<string>{$"Name: {gegner.Name}", $"Lebenspunkte: {gegner.LebensPunkte} / {gegner.MaxLebensPunkte}", $"Schaden: {gegner.Schaden / 2} bis {gegner.Schaden}"}
                },
                 {
                    "TrennerUnten", new List<string>{"---------------------------------"}
                },
                {
                    "Beschreibung", new List<string>()
                },
            };

            if (!string.IsNullOrEmpty(spielerWaffe)) logs[spieler.Name].Add($"{spielerWaffe}");
            if (!string.IsNullOrEmpty(gegnerWaffe)) logs[gegner.Name].Add($"{gegnerWaffe}");

            return logs;
        }
    }
}
