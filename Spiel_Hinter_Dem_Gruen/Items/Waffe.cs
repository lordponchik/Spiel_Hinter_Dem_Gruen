using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spiel_Hinter_Dem_Gruen.Items
{
    class Waffe : Item
    {
        public int Schadenswert { get; set; }
        public Waffe(string name, int schadenswert) : base(name, "Waffe")
        {
            Schadenswert = schadenswert;
        }
        public override Item Klonen()
        {
            return new Waffe(Name, Schadenswert);
        }
    }
}
