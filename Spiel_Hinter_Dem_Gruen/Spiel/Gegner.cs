using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Spiel_Hinter_Dem_Gruen.Items;
using Spiel_Hinter_Dem_Gruen.UI;

namespace Spiel_Hinter_Dem_Gruen.Spiel
{
    class Gegner : Kaempfer
    {
        private static Mittelbereich _mittelbereich = new Mittelbereich();
        private static readonly string[] Koerperteile = { "Kopf", "Rumpf", "Beine" };
        private static readonly Random _zufall = new Random();
        private List<Item> _auszeichnung = new List<Item>();

        public List<Item> Auszeichnung { get { return _auszeichnung; } }
        public List<string> Sprechzeilen { get; }

        public Gegner(string name, int leben, int schaden, List<string> sprechzeilen, Waffe? waffe = null) : base(name, leben, schaden, waffe)
        {
            Sprechzeilen = sprechzeilen;
            ErzeugeAuszeichnungen();
        }

        public override void WaehleAngriff() => KoerperTeilAngriff = _zufall.Next(0, Koerperteile.Length);

        public override void WaehleVerteidigung() => KoerperTeilVerteidigung = _zufall.Next(0, Koerperteile.Length);

        public void ErzeugeAuszeichnungen()
        {
            _auszeichnung.Clear();

            if (AktiveWaffe != null) _auszeichnung.Add(AktiveWaffe);

            Heilmittel heilmittel = (Heilmittel)ItemDatenbank.zitterpilz.Klonen();

            heilmittel.Anzahl = _zufall.Next(3, 9);

            _auszeichnung.Add(heilmittel);
        }
        public override void Rede()
        {
            _mittelbereich.Reset();
            _mittelbereich.EinstellenAusgabeInformation(Sprechzeilen);
        }
    }
}
