using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spiel_Hinter_Dem_Gruen.Items
{
    static class ItemDatenbank
    {
        public static readonly Heilmittel zitterpilz = new Heilmittel("Zitterpilz", verkaufspreis: 5, kaufpreis: 10, heilungswert: 15);

        public static readonly Waffe knorpelknacker = new Waffe("Knorpelknacker", verkaufspreis: 5, kaufpreis: 10, schadenswert: 5);

        public static readonly Waffe rostklaue = new Waffe("Rostklaue", verkaufspreis: 5, kaufpreis: 10, schadenswert: 10);
    }
}