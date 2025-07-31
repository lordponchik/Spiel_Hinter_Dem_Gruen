using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Spiel_Hinter_Dem_Gruen.Spiel;

namespace Spiel_Hinter_Dem_Gruen.Ressourcen
{
    class WeltkarteLoader
    {
        public static Dictionary<string, Szene> LadeWeltkarteAusJson(string dateipfad)
        {
            string pfad = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "TextAssets", dateipfad);

            string json = File.ReadAllText(pfad);

            var optionen = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            var weltkarte = JsonSerializer.Deserialize<Dictionary<string, Szene>>(json, optionen);

            return weltkarte ?? new Dictionary<string, Szene>();
        }
    }
}
