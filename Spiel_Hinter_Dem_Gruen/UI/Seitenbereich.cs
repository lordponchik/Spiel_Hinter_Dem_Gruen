using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Spiel_Hinter_Dem_Gruen.UI
{
    class Seitenbereich : ZeichenbereichBase
    {
        private int _aktuellX = Console.WindowWidth / 3 * 2;
        private int _aktuellY = 0;

        public override int StartX { get { return Console.WindowWidth / 3 * 2; } }
        public override int StartY { get { return 0; } }

        public override int EndeX { get { return Console.WindowWidth - 1; } }
        public override int EndeY { get { return Console.WindowHeight; } }

        public override int AktuellX { get { return _aktuellX; } set { _aktuellX = value; } }

        public override int AktuellY { get { return _aktuellY; } set { _aktuellY = value; } }

    }
}
