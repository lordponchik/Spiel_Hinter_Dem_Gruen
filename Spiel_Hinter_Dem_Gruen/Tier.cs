using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spiel_Hinter_Dem_Gruen
{
    class Tier :Kaempfer
    {
        private static readonly string[] Koerperteile = { "Kopf", "Rumpf", "Beine" };
        private static Random rand = new Random();

        public Tier(string name, int leben):base(name, leben) {

        }
        public override void WaehleAngriff()
        {
            KoerperTeilAngriff = rand.Next(0, Koerperteile.Length);
        }
    }
}
