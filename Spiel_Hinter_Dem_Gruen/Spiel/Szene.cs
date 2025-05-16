using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spiel_Hinter_Dem_Gruen.Spiel
{
    class Szene
    {
        public string Titel { get; set; }
        public string Name { get; set; }
        public List<string> Beschreibung { get; set; }

        public List<string>[] gebietBeschreibungen { get; set; }
        public List<Kaempfer> Gegner { get; set; }
    }
}
