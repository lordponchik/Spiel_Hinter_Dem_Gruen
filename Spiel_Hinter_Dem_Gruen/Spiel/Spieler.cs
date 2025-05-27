using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;
using Spiel_Hinter_Dem_Gruen.Items;
using Spiel_Hinter_Dem_Gruen.Statistik;
using Spiel_Hinter_Dem_Gruen.UI;

namespace Spiel_Hinter_Dem_Gruen.Spiel
{
    class Spieler : Kaempfer
    {
        private static Mittelbereich _mittelbereich = new Mittelbereich();
        private static Fussbereich _fussbereich = new Fussbereich();
        private static Seitenbereich _seitenbereich = new Seitenbereich();
        private static Kopfbereich _kopfbereich = new Kopfbereich();
        private static ZentrierterBereich _zentrierterBereich = new ZentrierterBereich();

        private static readonly string[] _koerperteile = { "Kopf", "Rumpf", "Beine" };

        private static readonly string[] _gewinnsaetze = {

"Das war’s! Du hast den Kampf nicht überlebt.",

"Noch ein Gegner weniger auf meinem Weg!",

"Dein Ende war vorhersehbar.",

"Schwach wie ein kleines Licht. Das nächste Mal besser!",
"So besiegt man einen Gegner – sauber und schnell.",

"Ich habe deine Stärke zerschlagen wie Glas.",

"Dein Mut hat dich in den Abgrund geführt.",
"Kein Platz für Verlierer hier.",

"Ich habe dich besiegt, und das ist erst der Anfang.",

"Du hättest besser umgedreht, bevor es zu spät war."};

        private static Random _zufall = new Random();

        public Dictionary<string, List<Item>> Inventar { get; private set; } = new Dictionary<string, List<Item>>();
        public bool IstErsterSpiel { get; set; }

        private readonly Action<List<string>, bool> _rendering;
        public Spieler(Action<List<string>, bool> rendering, bool istErsterSpiel = false, string name = "", int leben = 100, int schaden = 10) : base(name, leben, schaden)
        {
            Inventar["Heilmittel"] = new List<Item>();
            Inventar["Waffe"] = new List<Item>();
            _rendering = rendering;
            Name = Benennung();
            IstErsterSpiel = istErsterSpiel;
        }

        public string Benennung()
        {
            string name = "";

            while (true)
            {
                Console.Clear();

                _rendering(new List<string> { "Die anderen Orks lachen über dich – du bist der Letzte in der Rangordnung.\n",
                    "Deine Muskeln zittern, dein Magen knurrt – du bist nicht gerade furchteinflößend.\n",
                    "Ein Ork, ja. Aber ein besonders mickriger.\n",
                    "",
                    "Ein Ork hat keine Zeit für Zungenbrecher. Maximal zehn Zeichen!\n",
                    "Sag mir, wie du heißt: ",
                }, true);

                name = (Console.ReadLine() ?? "").Trim();

                if (name.Length > 0 && name.Length < 11) break;
            }

            Thread.Sleep(250);
            Console.Clear();

            _rendering(new List<string> { $"Willkommen {name}" }, true);

            Thread.Sleep(1500);

            return name;
        }




        public override void WaehleAngriff()
        {
            InteraktivesMenue interaktivesMenue = new InteraktivesMenue(_koerperteile, _fussbereich.EinstellenInteraktivesMenue);

            KoerperTeilAngriff = interaktivesMenue.AnzeigenUndAuswaehlen("Wohin willst du schlagen?");
        }
        public override void WaehleVerteidigung()
        {

            InteraktivesMenue interaktivesMenue = new InteraktivesMenue(_koerperteile, _fussbereich.EinstellenInteraktivesMenue);

            KoerperTeilVerteidigung = interaktivesMenue.AnzeigenUndAuswaehlen("Was willst du verteidigen?");
        }

        public void ZeigeInformation()
        {
            _seitenbereich.Reset();

            string waffe = "";
            if (AktiveWaffe != null) waffe = $"{AktiveWaffe.Name} - in der Hand +{AktiveWaffe.Schadenswert} Max-Schaden";

            List<string> information = new List<string>
            {
                $"Name: {Name}",
                "-------------------------",
                $"HP: {Leben} | Max HP: 100",
                "-------------------------",
                $"Max-Schaden: {Schaden}",
               $"{waffe}",
            };

            _seitenbereich.EinstellenAusgabeInformation(information);
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

            string[] punkteMenue = new string[1] { "Zurück" };

            InteraktivesMenue menue = new InteraktivesMenue(punkteMenue, _fussbereich.EinstellenInteraktivesMenue);


            List<string> texte = new List<string>();

            texte.Add("");
            texte.Add("------ Auszeichnungen -----");

            
            foreach (Item item in auszeichnungen)
            {
                FuegeItemHinzu(item);

                if (item is Heilmittel heilmittel) texte.Add($"{heilmittel.Name} - Anzahl: {heilmittel.Anzahl}");
                if (item is Waffe waffe) texte.Add($"{waffe.Name} - +{waffe.Schadenswert} Max-Schaden");
            }

            _seitenbereich.EinstellenAusgabeInformation(texte);

            int auswahl = menue.AnzeigenUndAuswaehlen();


            
            if (auswahl == 0) return;
        
            }

        public int ZeigeMenue(string name)
        {
            ZeigeInformation();
            _fussbereich.Reset();

            string[] menue = { $"Gegner: {name} herausfordern", "Inventar öffnen", "Spiel beenden" };


            InteraktivesMenue menue1 = new(menue, _fussbereich.EinstellenInteraktivesMenue);
            return menue1.AnzeigenUndAuswaehlen();
        }

        public override void ErhalteSchaden(int schaden)
        {
            base.ErhalteSchaden(schaden);



            if (Leben == 0)
            {
                Console.Clear();
                StatistikVerwaltung.SpeicherStatistic();

                List<string> skelett = new List<string>{

                    "    .-.    ",
                    "   (o.o)   ",
                    "    |=|    ",
                    "   __|__   ",
                    " //.=|=.\\ ",
                    "// .=|=. \\",
                    "\\ .=|=. //",
                    " \\(_=_)// ",
                    "  (:| |:)  ",
                    "   || ||   ",
                    "   () ()   ",
                    "   || ||   ",
                    "   || ||   ",
                    "  ==' '==  ",
            };

                List<string> text = new List<string> {
                    "\n",
                   "Hah! Deine Knochen sind weich wie Elfensuppe. Komm wieder, wenn du gelernt hast zu sterben!",
                    "\n",
                    "Du bist gestorben..."
                };

                List<string> gesamtBlock = new List<string>();

                gesamtBlock.AddRange(skelett);
                gesamtBlock.AddRange(text);

                _zentrierterBereich.EinstellenAusgabeInformation(gesamtBlock);

                Thread.Sleep(4000);

                Spiel.IstSpielVorbei = true;


            }
        }


        public void ZeigeInventar()
        {


            while (true)
            {

                _fussbereich.Reset();

                string[] menue = new string[Inventar.Count + 1];

                int index = 0;

                foreach (KeyValuePair<string, List<Item>> eintrag in Inventar)
                {
                    menue[index] = eintrag.Key;
                    index += 1;
                }

                menue[menue.Length - 1] = "Zurück";

                InteraktivesMenue menue1 = new(menue, _fussbereich.EinstellenInteraktivesMenue);

                int gewaehlteGruppe = menue1.AnzeigenUndAuswaehlen();



                if (gewaehlteGruppe == menue.Length - 1) return;
                ZeigeGegenstaendeGruppe(menue[gewaehlteGruppe]);
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

                    if (item is Heilmittel heilmittel) namenItems[index] = $"{heilmittel.Name} heilt zwischen {heilmittel.Heilungswert} und {heilmittel.Heilungswert} HP | (Anzahl: {heilmittel.Anzahl})";
                    if (item is Waffe waffe)
                    {
                        string ausgeruestet = "";
                        if (AktiveWaffe != null) ausgeruestet = waffe.Name == AktiveWaffe.Name ? "(Ausgerüstet)" : "";

                        namenItems[index] = $"{waffe.Name} verursacht {waffe.Schadenswert} Schaden {ausgeruestet}";
                    }

                    index += 1;
                }
                namenItems[namenItems.Length - 1] = "Zurück";



                InteraktivesMenue menue1 = new(namenItems, _fussbereich.EinstellenInteraktivesMenue);

                int auswahl = menue1.AnzeigenUndAuswaehlen();

                if (auswahl == namenItems.Length - 1) return;

                switch (gewaehlteGruppe)
                {
                    case "Heilmittel":
                        ErhalteHeilung(((Heilmittel)Inventar[gewaehlteGruppe][auswahl]).Verwenden());
                        if (Inventar[gewaehlteGruppe][auswahl] is Heilmittel heilung && heilung.Anzahl == 0) { Inventar["Heilmittel"].Remove(heilung); }
                        ZeigeInformation();
                        break;
                    case "Waffe":
                        if (AktiveWaffe != null)
                        {
                            if (AktiveWaffe.Name == Inventar[gewaehlteGruppe][auswahl].Name)
                            {
                                AktiveWaffe = null;
                                ZeigeInformation();
                                continue;

                            }
                            else AktiveWaffe = (Waffe)Inventar[gewaehlteGruppe][auswahl];
                        }
                        else AktiveWaffe = (Waffe)Inventar[gewaehlteGruppe][auswahl];
                        ZeigeInformation();
                        break;
                }



            }
        }

        public void FuegeItemHinzu(Item item)
        {
            Item neuesItem = item.Klonen();

            if (neuesItem is Heilmittel neuesHeilmittel)
            {
                List<Item> heilmittelListe = Inventar["Heilmittel"];

                bool gefunden = false;

                foreach (Item element in heilmittelListe)
                {
                    if (element is Heilmittel vorhandenesHeilmittel && vorhandenesHeilmittel.Name == neuesHeilmittel.Name)
                    {
                        vorhandenesHeilmittel.Anzahl += neuesHeilmittel.Anzahl;
                        gefunden = true;
                        break;
                    }
                }

                if (!gefunden)
                {
                    heilmittelListe.Add(neuesItem);
                }
            }
            if (neuesItem is Waffe neuerWaffe)
            {
                List<Item> waffenListe = Inventar["Waffe"];

                waffenListe.Add(neuesItem);
            }
        }

        public void ErhalteHeilung(int heilung)
        {
            Leben += heilung;

            if (Leben > 100) Leben = 100;

            ZeigeInformation();
        }
    }
}
