using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spiel_Hinter_Dem_Gruen.Spiel
{
    class Szene
    {
        public string Titel { get; set; } = String.Empty;
        public string Name { get; set; } = String.Empty;
        public List<string> Beschreibung { get; set; }  = new List<string>();

        public List<List<string>> gebietBeschreibungen { get; set; } = new List<List<string>>();
    }
}
