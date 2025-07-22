using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Spiel_Hinter_Dem_Gruen.Ressourcen
{
    public static class LadeJson
    {
        public static T LadenDatei<T>(string dateiName)
        {
            string pfad = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "TextAssets", dateiName);

            string json = File.ReadAllText(pfad);

            return JsonSerializer.Deserialize<T>(json)!;
        }
    }
}

