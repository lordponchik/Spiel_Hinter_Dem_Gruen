using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spiel_Hinter_Dem_Gruen.UI
{
    interface IZeichenbereich
    {
        int StartX { get; }
        int StartY { get; }

        int EndeX { get; }
        int EndeY { get; }

        int AktuellX { get; set; }
        int AktuellY { get; set; }

        int Breite { get; }
        int Hoehe { get; }
    }
}
