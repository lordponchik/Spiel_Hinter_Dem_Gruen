using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spiel_Hinter_Dem_Gruen.Items
{
    class Schatz : Item
    {
        public Schatz(string name, int verkaufspreis, int kaufpreis) : base(name, "Schatz", verkaufspreis, kaufpreis){}
        public override Item Klonen()
        {
            return new Schatz(Name, Verkaufspreis, Kaufpreis);
        }
    }
}
