using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Spiel_Hinter_Dem_Gruen
{
   public static class StatistikVerwaltung
    {
        public static void SpeicherStatistic() {

            string json = JsonSerializer.Serialize(new
            {
                SpielerStatistik.Siege,
                SpielerStatistik.VerwendeteHeilmittel 
            });

            File.WriteAllText("statistic.json", json);
        }

        public static void LadeStatistic()
        {
            string datei = "statistic.json";

            if (!File.Exists(datei)) return;

            string json = File.ReadAllText(datei);

            var daten = JsonSerializer.Deserialize<Dictionary<string, int>>(json);

            if(daten != null)
            {
                int siege = daten.GetValueOrDefault("Siege", 0);
                int heilmittel = daten.GetValueOrDefault("VerwendeteHeilmittel", 0);

                    List<string> statistics = new List<string> { "----- Letzte Statistic -----\n","\n", $"Siege: {siege}\n", $"Verwendete Heilmittel: {heilmittel}\n", "Die Vergangenheit spricht – doch die Zukunft gehört dir...\n" };

                    ZentrierterBereich.EinstellenAusgabeInformation(statistics);
                
            }
        }
    }
}
