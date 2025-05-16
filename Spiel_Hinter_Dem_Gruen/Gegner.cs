using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Spiel_Hinter_Dem_Gruen
{
    class Gegner : Kaempfer
    {
        private static readonly string[] Koerperteile = { "Kopf", "Rumpf", "Beine" };
        private static Random _zufall = new Random();
        public List<string> Sprechzeilen { get; }

        public Gegner(string name, int leben, int schaden, List<string> sprechzeilen, Waffe? waffe = null) : base(name,leben, schaden, waffe)
        {
            Sprechzeilen = sprechzeilen;
        }
        public override void WaehleAngriff()
        {
            KoerperTeilAngriff = _zufall.Next(0, Koerperteile.Length);
        }
        public override void WaehleVerteidigung()
        {
            KoerperTeilVerteidigung = _zufall.Next(0, Koerperteile.Length);
        }

        public override void Rede()
        {
            Kopfbereich.Reset();
            Kopfbereich.EinstellenAusgabeInformation(Sprechzeilen);
        }


    }
}
