using Spiel_Hinter_Dem_Gruen.Items;
using Spiel_Hinter_Dem_Gruen.UI;

namespace Spiel_Hinter_Dem_Gruen.Spiel
{
    class Gegner : Kaempfer
    {
        private static Mittelbereich _mittelbereich = new Mittelbereich();
        private static readonly Random _zufall = new Random();
        private List<Item> _auszeichnung = new List<Item>();

        public List<Item> Auszeichnung { get { return _auszeichnung; } }
        public List<string> Sprechzeilen { get; }

        public Gegner(string name, int lebenPunkte, int maxLebensPunkte, int schaden, List<string> sprechzeilen, Waffe? waffe = null) : base(name, lebenPunkte, maxLebensPunkte , schaden, waffe)
        {
            Sprechzeilen = sprechzeilen;
            ErzeugeAuszeichnungen();
        }
        public void ErzeugeAuszeichnungen()
        {
            _auszeichnung.Clear();

            if (AktiveWaffe != null) _auszeichnung.Add(AktiveWaffe);

            Heilmittel heilmittel = (Heilmittel)ItemDatenbank.zitterpilz.Klonen();

            heilmittel.Anzahl = _zufall.Next(3, 9);

            _auszeichnung.Add(heilmittel);
        }
        public override void Rede()
        {
            _mittelbereich.Reset();
            _mittelbereich.EinstellenAusgabeInformation(Sprechzeilen);
        }
    }
}
