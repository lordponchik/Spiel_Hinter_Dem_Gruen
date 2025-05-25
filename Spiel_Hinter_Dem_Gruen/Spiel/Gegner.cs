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
        private static Kopfbereich _kopfbereich = new Kopfbereich();

        private static readonly string[] Koerperteile = { "Kopf", "Rumpf", "Beine" };
        private static Random _zufall = new Random();

        private List<Item> _auszeichnung = new List<Item>();
        public List<Item> Auszeichnung { get { return _auszeichnung; } }
        public List<string> Sprechzeilen { get; }

        public Gegner(string name, int leben, int schaden, List<string> sprechzeilen, Waffe? waffe = null) : base(name, leben, schaden, waffe)
        {
            Sprechzeilen = sprechzeilen;
            AuszeichnungenHinzufuegen();
        }
        public override void WaehleAngriff()
        {
            KoerperTeilAngriff = _zufall.Next(0, Koerperteile.Length);
        }
        public override void WaehleVerteidigung()
        {
            KoerperTeilVerteidigung = _zufall.Next(0, Koerperteile.Length);
        }

        public void AuszeichnungenHinzufuegen()
        {
            _auszeichnung.Clear();

            if (AktiveWaffe != null) _auszeichnung.Add(AktiveWaffe);

            int heilmittelAnzahl = _zufall.Next(3, 6);

            for (int i = 0; i < heilmittelAnzahl; i += 1)
            {
                _auszeichnung.Add(ItemDatenbank.zitterpilz);
            }
        }

        public override void Rede()
        {
            _kopfbereich.Reset();
            _kopfbereich.EinstellenAusgabeInformation(Sprechzeilen);
        }


    }
}
