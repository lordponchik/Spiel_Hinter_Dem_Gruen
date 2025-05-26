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
        public int Verkaufspreis { get; set; }
        public int Kaufpreis { get; set; }

        public Item(string name, string typ, int verkaufspreis, int kaufpreis, int anzahl = 1)
        {
            Name = name;
            Typ = typ;
            Verkaufspreis = verkaufspreis;
            Kaufpreis = kaufpreis;
            Anzahl = anzahl;
        }

        public abstract Item Klonen();
    }
}
