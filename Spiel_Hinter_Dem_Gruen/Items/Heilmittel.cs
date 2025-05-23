﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spiel_Hinter_Dem_Gruen.Statistik;

namespace Spiel_Hinter_Dem_Gruen.Items
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

            SpielerStatistik.VerwendeHeilMittel();
            Anzahl -= 1;

            int geheilt = _zufall.Next(MinHeilung, Wert + 1);

            return geheilt;
        }

        public override Item Klonen()
        {
            return new Heilmittel(Name, MinHeilung, Wert, Anzahl);
        }
    }


}
