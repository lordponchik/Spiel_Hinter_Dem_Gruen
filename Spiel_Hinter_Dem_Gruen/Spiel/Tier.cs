using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spiel_Hinter_Dem_Gruen.Items;

namespace Spiel_Hinter_Dem_Gruen.Spiel
{
    class Tier : Kaempfer
    {
        private static readonly string[] _koerperteile = { "Kopf", "Rumpf", "Beine" };
        private static Random _zufall = new Random();
        private List<Item> _auszeichnung = new List<Item>();
        public List<Item> Auszeichnung { get { return _auszeichnung; } }
        public Tier(string name, int leben, int schaden) : base(name, leben, schaden)
        {
            AuszeichnungenHinzufuegen();
        }
        public override void WaehleAngriff()
        {
            KoerperTeilAngriff = _zufall.Next(0, _koerperteile.Length);
        }


        public void AuszeichnungenHinzufuegen()
        {
            _auszeichnung.Clear();

            if (AktiveWaffe != null) _auszeichnung.Add(AktiveWaffe);

            int heilmittelAnzahl = _zufall.Next(1, 5);

            for (int i = 0; i < heilmittelAnzahl; i += 1)
            {
                _auszeichnung.Add(ItemDatenbank.zitterpilz);
            }
        }
    }
}
