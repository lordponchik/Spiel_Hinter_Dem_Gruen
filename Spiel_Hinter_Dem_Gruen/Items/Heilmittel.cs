using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spiel_Hinter_Dem_Gruen.Statistik;

namespace Spiel_Hinter_Dem_Gruen.Items
{
    class Heilmittel : Item
    {
        public int Heilungswert { get; set; }
        private static readonly Random _zufall = new Random();

        public Heilmittel(string name, int heilungswert) : base(name, "Heilmittel")
        {
            Heilungswert = heilungswert;
        }

        public int Verwenden()
        {
            SpielerStatistik.VerwendeHeilMittel();

            Anzahl -= 1;



            int geheilt = _zufall.Next(Heilungswert / 2, Heilungswert + 1);

            return geheilt;
        }

        public override Item Klonen()
        {
            return new Heilmittel(Name, Heilungswert);
        }
    }
}