
using System.Collections.Generic;
using Spiel_Hinter_Dem_Gruen.Items;
using Spiel_Hinter_Dem_Gruen.Ressourcen;
using Spiel_Hinter_Dem_Gruen.Statistik;
using Spiel_Hinter_Dem_Gruen.UI;

namespace Spiel_Hinter_Dem_Gruen.Spiel
{
    class Spieler : Kaempfer
    {
        private static Mittelbereich _mittelbereich = new Mittelbereich();
        private static Fussbereich _fussbereich = new Fussbereich();
        private static Seitenbereich _seitenbereich = new Seitenbereich();
        private static ZentrierterBereich _zentrierterBereich = new ZentrierterBereich();
        private readonly Action<List<string>, bool> _rendering;
        private static readonly string[] _koerperteile = { "Kopf", "Rumpf", "Beine" };
        private static string[] _gewinnsaetze = LadeJson.LadenDatei<GewinnSaetzeDaten>("GewinnSaetze.json").Saetze;
        private static List<string> _benennungNachricht = LadeJson.LadenDatei<BenennungDaten>("SpielerBenennung.json").BenennungNachricht;
        private static VerstorbenNachrichtDaten _verstorbenNachricht = LadeJson.LadenDatei<VerstorbenNachrichtDaten>("AngabenZumVerstorbenen.json");
        private static readonly Random _zufall = new Random();

        public Dictionary<string, List<Item>> Inventar { get; private set; } = new Dictionary<string, List<Item>>();
        public bool IstErsterSpiel { get; set; }
        public int WeltLevel { get; set; }
        public Spieler(Action<List<string>, bool> rendering, bool istErsterSpiel = false, int weltlevel = 1, string name = "", int lebensPunkte = 100, int maxLebensPunkte = 100, int Max = 100, int schaden = 10) : base(name, lebensPunkte, maxLebensPunkte, schaden)
        {
            Inventar["Heilmittel"] = new List<Item>();
            Inventar["Waffe"] = new List<Item>();
            _rendering = rendering;
            Name = Benennung();
            IstErsterSpiel = istErsterSpiel;
            WeltLevel = weltlevel;
        }

        private string Benennung()
        {
            string name = "";

            while (true)
            {
                Console.Clear();

                _rendering(_benennungNachricht, true);

                name = (Console.ReadLine() ?? "").Trim();

                if (name.Length > 0 && name.Length < 11) break;
            }

            Thread.Sleep(250);
            Console.Clear();

            _rendering(new List<string> { $"Willkommen {name}" }, true);

            Thread.Sleep(1000);

            return name;
        }

        public override void WaehleAngriff() => KoerperTeilAngriff = WaehleKoerperteil("Wohin willst du schlagen?");

        public override void WaehleVerteidigung() => KoerperTeilVerteidigung = WaehleKoerperteil("Was willst du verteidigen?");

        private int WaehleKoerperteil(string frage)
        {
            InteraktivesMenue menue = new InteraktivesMenue(_koerperteile, _fussbereich.EinstellenInteraktivesMenue);

            return menue.AnzeigenUndAuswaehlen(frage);
        } 

        public void ZeigeSpielerInformation()
        {
            _seitenbereich.Reset();

            string waffeInfo = "Keine";
            if (AktiveWaffe != null) waffeInfo = $"{AktiveWaffe.Name} +{AktiveWaffe.Schadenswert} Schaden";

            List<string> spielerInfo = new List<string>
            {
                $"Name: {Name}",
                "",
                $"Welt-Stufe: {WeltLevel}",
                "",
                $"Lebenspunkte: {LebensPunkte} / {MaxLebensPunkte}",
                "",
                $"Schaden: {Schaden / 2} - {Schaden}",
                "",
                $"Waffe: {waffeInfo}",
            };

            _seitenbereich.EinstellenAusgabeInformation(spielerInfo);
        }


        public override void NimmBelohnungAuf(string name, List<Item> auszeichnungen)
        {

            string gewinnSatz = _gewinnsaetze[_zufall.Next(0, _gewinnsaetze.Length)];

            _fussbereich.Reset();
            _mittelbereich.Reset();

            _mittelbereich.EinstellenAusgabeInformation(new List<string>
            {
                "Sieg!\n",
                "\n",
                $"{name}: {gewinnSatz}\n",

            });

            InteraktivesMenue menue = new InteraktivesMenue(new string[1] { "Zurück" }, _fussbereich.EinstellenInteraktivesMenue);

            if (menue.AnzeigenUndAuswaehlen() == 0) return;

        }

        public int ZeigeMenue(string name)
        {
            ZeigeSpielerInformation();
            _fussbereich.Reset();

            string[] menue = { $"Gegner: {name} herausfordern", "Inventar öffnen", "Spiel beenden" };

            return new InteraktivesMenue(menue, _fussbereich.EinstellenInteraktivesMenue).AnzeigenUndAuswaehlen();
        }

        public override void ErhalteSchaden(int schaden)
        {
            base.ErhalteSchaden(schaden);


            if (LebensPunkte == 0)
            {
                Console.Clear();
                StatistikVerwaltung.SpeicherStatistic();

                List<string> gesamtBlock = new List<string>();

                gesamtBlock.AddRange(_verstorbenNachricht.bild);
                gesamtBlock.AddRange(_verstorbenNachricht.nachricht);

                _zentrierterBereich.EinstellenAusgabeInformation(gesamtBlock, true);

                Thread.Sleep(4000);

                Spiel.IstSpielVorbei = true;
            }
        }
        public void ZeigeInventar()
        {
            while (true)
            {
                _fussbereich.Reset();

                string[] menueGruppen = new string[Inventar.Count + 1];

                int index = 0;

                foreach (KeyValuePair<string, List<Item>> eintrag in Inventar)
                {
                    menueGruppen[index] = eintrag.Key;
                    index += 1;
                }

                menueGruppen[menueGruppen.Length - 1] = "Zurück";

                InteraktivesMenue menueGegenstaende = new(menueGruppen, _fussbereich.EinstellenInteraktivesMenue);

                int gewaehlteGruppe = menueGegenstaende.AnzeigenUndAuswaehlen();



                if (gewaehlteGruppe == menueGruppen.Length - 1) return;
                ZeigeGegenstaendeGruppe(menueGruppen[gewaehlteGruppe]);
            }
        }

        private void ZeigeGegenstaendeGruppe(string gewaehlteGruppe)
        {

            while (true)
            {
                _fussbereich.Reset();

                string[] namenItems = new string[Inventar[gewaehlteGruppe].Count + 1];

                int index = 0;

                foreach (Item item in Inventar[gewaehlteGruppe])
                {

                    if (item is Heilmittel heilmittel) namenItems[index] = $"{heilmittel.Name} heilt zwischen {heilmittel.Heilungswert / 2} und {heilmittel.Heilungswert} HP | (Anzahl: {heilmittel.Anzahl})";
                    if (item is Waffe waffe)
                    {
                        string ausgeruestet = "";
                        if (AktiveWaffe != null) ausgeruestet = waffe.Name == AktiveWaffe.Name ? "(Ausgerüstet)" : "";

                        namenItems[index] = $"{waffe.Name} verursacht {waffe.Schadenswert} Schaden {ausgeruestet}";
                    }

                    index += 1;
                }
                namenItems[namenItems.Length - 1] = "Zurück";

                int auswahl = new InteraktivesMenue(namenItems, _fussbereich.EinstellenInteraktivesMenue).AnzeigenUndAuswaehlen();

                if (auswahl == namenItems.Length - 1) return;

                switch (gewaehlteGruppe)
                {
                    case "Heilmittel":
                        ErhalteHeilung(((Heilmittel)Inventar[gewaehlteGruppe][auswahl]).Verwenden());
                        if (Inventar[gewaehlteGruppe][auswahl] is Heilmittel heilung && heilung.Anzahl == 0) { Inventar["Heilmittel"].Remove(heilung); }
                        ZeigeSpielerInformation();
                        break;
                    case "Waffe":
                        Waffe gewaehlteWaffe = (Waffe)Inventar[gewaehlteGruppe][auswahl];

                        if (AktiveWaffe != null && AktiveWaffe.Name == gewaehlteWaffe.Name) AktiveWaffe = null;
                        else AktiveWaffe = gewaehlteWaffe;

                        ZeigeSpielerInformation();
                        break;
                }
            }
        }

        public void FuegeItemHinzu(Item item)
        {
            if (item is Heilmittel neuesHeilmittel)
            {
                List<Item> heilmittelListe = Inventar["Heilmittel"];

                if (!heilmittelListe.Exists(el => el.Name == neuesHeilmittel.Name))
                {
                    heilmittelListe.Add(item);
                }
                else
                {
                    heilmittelListe.Find(el => el.Name == neuesHeilmittel.Name).Anzahl += neuesHeilmittel.Anzahl;
                }
            }
            if (item is Waffe neuerWaffe)
            {
                List<Item> waffenListe = Inventar["Waffe"];

                waffenListe.Add(item);
            }
        }

        public void ErhalteHeilung(int heilung)
        {
            LebensPunkte += heilung;

            if (LebensPunkte > MaxLebensPunkte) LebensPunkte = MaxLebensPunkte;

            ZeigeSpielerInformation();
        }
    }
}
