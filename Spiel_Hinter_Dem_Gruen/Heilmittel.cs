using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spiel_Hinter_Dem_Gruen
{
    class Heilmittel : Item
    {
        public int Anzahl { get; set; }
        public int MinHeilung { get; set; }
        private static Random _zufall = new Random();

        public Heilmittel(string name, int minHeilung, int maxHeilung, int anzahl = 1 ) : base(name, "Heilmittel", maxHeilung)
        {
            Anzahl = anzahl;
            MinHeilung = minHeilung;
        }

        public int Verwenden()
        {
            int geheilt = _zufall.Next(MinHeilung, Wert + 1);

            return geheilt;
        }

        public override Item Klonen()
        {
            return new Heilmittel(Name, MinHeilung, Wert, Anzahl);
        }
    }


}
