using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spiel_Hinter_Dem_Gruen.Statistik
{
    public static class  SpielerStatistik
    {
        public static int Siege { get;set; }
        public static int VerwendeteHeilmittel
        {
            get;set;
        }

        public static void ErhoeheSiege()
        {
            Siege += 1;
        }
        public static void VerwendeHeilMittel()
        {
            VerwendeteHeilmittel += 1;
        }
    }
}
