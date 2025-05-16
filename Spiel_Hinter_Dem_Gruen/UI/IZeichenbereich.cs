using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spiel_Hinter_Dem_Gruen.UI
{
    interface IZeichenbereich
    {
        public static int StartX { get; }
        public static int StartY { get; }

        public static int EndeX { get; }
        public static int EndeY { get; }

        public static int AktuellX { get; set; }

        public static int AktuellY { get; set; }
    }
}
