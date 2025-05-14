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
            return new Dictionary<string, List<string>>
            {
                {
                    "titel", new List<string>{$"Kampf mit {gegner.Name}"}
                },
                 {
                    "trenner1", new List<string>{"---------------------------------"}

                },
                {
                    $"{spieler.Name}", new List<string>{$"Name: {spieler.Name}", $"HP: {spieler.Leben}"}
                },
                {
                    $"{gegner.Name}", new List<string>{$"Name: {gegner.Name}", $"HP: {gegner.Leben}"}
                },
                 {
                    "trenner2", new List<string>{"---------------------------------"}

                },
                {
                    "beschreibung", new List<string>{

                    }
                },


            };
        }
    }
}
