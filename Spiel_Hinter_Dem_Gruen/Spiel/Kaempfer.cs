using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spiel_Hinter_Dem_Gruen
{
    abstract class Kaempfer
    {
        public string Name { get; set; }
        private static Random _zufall = new Random();
        public int Leben { get; protected set; } = 100;

        public Waffe? AktiveWaffe { get; protected set; }

        public int Schaden { get; protected set; }

        public int KoerperTeilAngriff { get; protected set; }
        public int? KoerperTeilVerteidigung { get; protected set; }

        public Kaempfer(string name, int leben, int schaden, Waffe? aktiveWaffe = null)
        {
            Name = name;
            Leben = leben;
            Schaden = schaden;
            AktiveWaffe = aktiveWaffe;
        }

        public abstract void WaehleAngriff();
        public virtual void WaehleVerteidigung()
        {
            KoerperTeilVerteidigung = null;
        }
        public virtual void ErhalteSchaden(int schaden)
        {
            Leben -= schaden;
            if (Leben < 0) Leben = 0;
        }

        public bool IstBesiegt()
        {
            return Leben <= 0;
        }

        public int VerursachterSchaden()
        {

            int extraSchaden = 0;

            if (AktiveWaffe != null) extraSchaden += AktiveWaffe.Wert;


            int geschadet = _zufall.Next(Schaden-2, Schaden + extraSchaden + 1);

            return geschadet;
        }
        public virtual void Rede() { }
        public virtual void NimmBelohnungAuf(string name, List<Item> belohnungen) { }
    }
}
