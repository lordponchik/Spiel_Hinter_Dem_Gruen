﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spiel_Hinter_Dem_Gruen.Items;

namespace Spiel_Hinter_Dem_Gruen.Spiel
{
    abstract class Kaempfer
    {
        private static Random _zufall = new Random();
        public string Name { get; protected set; }
        public int LebensPunkte { get; protected set; }
        public int MaxLebensPunkte { get; protected set; }
        public Waffe? AktiveWaffe { get; protected set; }
        public int Schaden { get; protected set; }
        public int KoerperTeilAngriff { get; protected set; }
        public int KoerperTeilVerteidigung { get; protected set; }
        public Kaempfer(string name, int lebensPunkte, int maxLebensPunkte, int schaden, Waffe? aktiveWaffe = null)
        {
            Name = name;
            LebensPunkte = lebensPunkte;
            MaxLebensPunkte = maxLebensPunkte;
            Schaden = schaden;
            AktiveWaffe = aktiveWaffe;
        }

        public abstract void WaehleAngriff();
        public abstract void WaehleVerteidigung();

        public bool IstBesiegt() => LebensPunkte <= 0;

        public int VerursachterSchaden()
        {
            int extraSchaden = 0;

            if (AktiveWaffe != null) extraSchaden += AktiveWaffe.Schadenswert;

            return _zufall.Next(Schaden / 2, Schaden + extraSchaden + 1);
        }
        public virtual void ErhalteSchaden(int schaden)
        {
            LebensPunkte -= schaden;
            if (LebensPunkte < 0) LebensPunkte = 0;
        }
        public virtual void Rede() { }
        public virtual void NimmBelohnungAuf(string name, List<Item> belohnungen) { }
    }
}
