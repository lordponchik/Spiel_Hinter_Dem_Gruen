using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spiel_Hinter_Dem_Gruen.Items
{
    class Ruestung : Item
    {
        public int Verteidigungswert { get; set; }

        public Ruestung(string name, int verkaufspreis, int kaufpreis, int verteidigungswert) : base(name, "Ruestung", verkaufspreis, kaufpreis)
        {
            Verteidigungswert = verteidigungswert;
        }

        public override Item Klonen()
        {
            return new Ruestung(Name, Verkaufspreis, Kaufpreis, Verteidigungswert);
        }

    }
}
