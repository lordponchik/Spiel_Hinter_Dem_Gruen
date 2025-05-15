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
        public int Leben { get; protected set; } = 100;

        public int KoerperTeilAngriff { get; protected set; }
        public int? KoerperTeilVerteidigung { get; protected set; }

        public Kaempfer(string name, int leben)
        {
            Name = name;
            Leben = leben;
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

        public virtual void Rede() { }
    }
}
