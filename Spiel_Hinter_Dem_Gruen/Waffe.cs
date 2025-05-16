using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spiel_Hinter_Dem_Gruen
{
    class Waffe : Item
    {


        public Waffe(string name,int schaden) : base(name, "Waffe", schaden)
        {
        }

        public override Item Klonen()
        {
            return new Waffe(Name, Wert);
        }
    }
}
