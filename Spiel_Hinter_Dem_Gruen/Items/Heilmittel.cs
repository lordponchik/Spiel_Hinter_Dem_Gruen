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

        public Heilmittel(string name, int verkaufspreis, int kaufpreis, int heilungswert) : base(name, "Heilmittel", verkaufspreis, kaufpreis)
        {
            Heilungswert = heilungswert;
        }

        public int Verwenden()
        {
            SpielerStatistik.VerwendeHeilMittel();

            Anzahl -= 1;

            int geheilt = Heilungswert;

            return geheilt;
        }

        public override Item Klonen()
        {
            return new Heilmittel(Name, Verkaufspreis, Kaufpreis, Heilungswert);
        }
    }
}