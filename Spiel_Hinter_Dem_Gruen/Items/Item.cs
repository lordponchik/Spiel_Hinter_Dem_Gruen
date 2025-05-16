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

        public int Wert { get; set; }

        public Item(string name, string typ, int wert)
        {
            Name = name;
            Typ = typ;
            Wert = wert;
        }

        public abstract Item Klonen();
    }
}
