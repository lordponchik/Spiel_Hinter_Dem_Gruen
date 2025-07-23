using Spiel_Hinter_Dem_Gruen.Items;
using Spiel_Hinter_Dem_Gruen.Ressourcen;
using Spiel_Hinter_Dem_Gruen.Statistik;
using Spiel_Hinter_Dem_Gruen.UI;

namespace Spiel_Hinter_Dem_Gruen.Spiel
{
    class Kampf
    {
        private static List<string> _beschreibungZeilen = new List<string>();
        private static Seitenbereich _seitenbereich = new Seitenbereich();
        private static ZentrierterBereich _zentrierterBereich = new ZentrierterBereich();
        private static List<string> _kampfanleitung = LadeJson.LadenDatei<KampfanleitungDaten>("Kampfanleitung.json").KampfanleitungNachricht;
        private static Dictionary<string, List<string>> _kampfLog = new Dictionary<string, List<string>>();

        public static bool Rundenkampf(Kaempfer spieler, Kaempfer gegner)
        {
            _kampfLog = KampfLog.ErstelleLog(spieler, gegner);

            while (!spieler.IstBesiegt() && !gegner.IstBesiegt())
            {
                _seitenbereich.Reset();

                AktualisiereKampfLog(spieler, gegner);
                spieler.WaehleAngriff();
                spieler.WaehleVerteidigung();

                gegner.WaehleAngriff();
                gegner.WaehleVerteidigung();

                BerechnungSchaden(spieler, gegner, _kampfLog);
                BerechnungSchaden(gegner, spieler, _kampfLog);
            }

            if (gegner.LebensPunkte == 0)
            {
                SpielerStatistik.ErhoeheSiege();

                _seitenbereich.Reset();
                AktualisiereKampfLog(spieler, gegner);

                if (gegner is Gegner g) spieler.NimmBelohnungAuf(spieler.Name, g.Auszeichnung);
            }

            return gegner.LebensPunkte == 0;     
        }

        public static void AktualisiereKampfLog(Kaempfer spieler, Kaempfer gegner)
        {
            _beschreibungZeilen.Clear();

            foreach (KeyValuePair<string, List<string>> eintrag in _kampfLog)
            {
                if (eintrag.Key == "Beschreibung")
                {
                    if (eintrag.Value.Count == 0)
                    {
                        continue;
                    }
                    else
                    {
                        _beschreibungZeilen.Add(eintrag.Value[eintrag.Value.Count - 2]);
                        _beschreibungZeilen.Add(eintrag.Value[eintrag.Value.Count - 1]);
                    }
                }
                else
                {
                    _beschreibungZeilen.AddRange(eintrag.Value);
                }
            }
            if (gegner.LebensPunkte <= 0)
            {
                List<string> texte = new List<string>();

                texte.Add("");
                texte.Add("------ Auszeichnungen -----");

                if (gegner is Gegner geg)
                {
                    foreach (Item item in geg.Auszeichnung)
                    {
                        if (item is Heilmittel heilmittel)
                        {
                            texte.Add($"{heilmittel.Name} - Anzahl: {heilmittel.Anzahl}");
                            if (spieler is Spieler s) s.FuegeItemHinzu(heilmittel);

                        }
                        if (item is Waffe waffe) texte.Add($"{waffe.Name} - +{waffe.Schadenswert} Max-Schaden");
                    }
                }

                _beschreibungZeilen.AddRange(texte);
            }

            _seitenbereich.EinstellenAusgabeInformation(_beschreibungZeilen);
        }

        private static void BerechnungSchaden(Kaempfer angreifer, Kaempfer verteidiger, Dictionary<string, List<string>> kampflog)
        {
            if (angreifer.KoerperTeilAngriff == verteidiger.KoerperTeilVerteidigung)
            {
                kampflog["Beschreibung"].Add($"{angreifer.Name} greift an, aber {verteidiger.Name} blockt!");
            }
            else
            {
                int schaden = angreifer.VerursachterSchaden();

                kampflog["Beschreibung"].Add($"{angreifer.Name} trifft {verteidiger.Name} für {schaden} Schaden!");

                verteidiger.ErhalteSchaden(schaden);

                kampflog[verteidiger.Name][1] = $"Lebenspunkte: {verteidiger.LebensPunkte} / {verteidiger.MaxLebensPunkte}";
            }
        }

        public static void Kampfanweisung()
        {
            Console.Clear();

            _kampfanleitung.Add("\n");
            _kampfanleitung.Add("Hau auf <Enter>, sonst hau ich dich!");

            _zentrierterBereich.EinstellenAusgabeInformation(_kampfanleitung, true);

            ConsoleKey key;

            do
            {
                key = Console.ReadKey(true).Key;
            }
            while (key != ConsoleKey.Enter);
        }
    }
}
