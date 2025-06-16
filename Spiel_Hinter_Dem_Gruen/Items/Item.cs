using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spiel_Hinter_Dem_Gruen.Items
{
    abstract class Item
    {
        public string Name { get; set; }
        public string Typ { get; set; }
        public int Anzahl { get; set; }

        public Item(string name, string typ, int anzahl = 1)
        {
            Name = name;
            Typ = typ;
            Anzahl = anzahl;
        }

        public abstract Item Klonen();
    }
}
