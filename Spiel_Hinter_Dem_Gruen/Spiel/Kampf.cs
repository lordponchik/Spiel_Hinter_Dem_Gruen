using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using Spiel_Hinter_Dem_Gruen.Statistik;
using Spiel_Hinter_Dem_Gruen.UI;

namespace Spiel_Hinter_Dem_Gruen.Spiel
{
    class Kampf
    {
        private static Seitenbereich _seitenbereich = new Seitenbereich();
        private static Kopfbereich _kopfbereich = new Kopfbereich();
        private static ZentrierterBereich _zentrierterBereich = new ZentrierterBereich();

        private static Dictionary<string, List<string>> _kampfLog = new Dictionary<string, List<string>>();

        public static bool Rundenkampf(Kaempfer spieler, Kaempfer gegner)
        {

            _kampfLog = KampfLog.ErstelleLog(spieler, gegner);

            while (!spieler.IstBesiegt() && !gegner.IstBesiegt())
            {

                _seitenbereich.Reset();

                AktualisiereKampfLog();

                spieler.WaehleAngriff();
                spieler.WaehleVerteidigung();

                gegner.WaehleAngriff();
                gegner.WaehleVerteidigung();

                BerechnungSchaden(spieler, gegner, _kampfLog);
                BerechnungSchaden(gegner, spieler, _kampfLog);

                _seitenbereich.Reset();

                AktualisiereKampfLog();

            }

            if(gegner.Leben == 0)
            {
               if(gegner is Gegner g) spieler.NimmBelohnungAuf(spieler.Name, g.Auszeichnung);
               if (gegner is Tier t) spieler.NimmBelohnungAuf(spieler.Name, t.Auszeichnung);


                SpielerStatistik.ErhoeheSiege();
            }

            return gegner.Leben == 0;


            void AktualisiereKampfLog()
            {
                foreach (KeyValuePair<string, List<string>> eintrag in _kampfLog)
                {

                    if (eintrag.Key == "beschreibung")
                    {
                        if (eintrag.Value.Count == 0)
                        {
                            continue;
                        }
                        else
                        {
                           // _seitenbereich.EinstellenAusgabeInformation(eintrag.Value[eintrag.Value.Count - 2]);
                            //_seitenbereich.EinstellenAusgabeInformation(eintrag.Value[eintrag.Value.Count - 1]);
                        }
                    }
                    else
                    {

                            _seitenbereich.EinstellenAusgabeInformation(eintrag.Value);
                          // _seitenbereich.EinstellenAusgabeInformation(eintrag.Value[i]);
                    }
                }
            }
        }

        private static void BerechnungSchaden(Kaempfer angreifer, Kaempfer verteidiger, Dictionary<string, List<string>> kampflog)
        {
            if (angreifer.KoerperTeilAngriff == verteidiger.KoerperTeilVerteidigung)
            {

                kampflog["beschreibung"].Add($"{angreifer.Name} greift an, aber {verteidiger.Name} blockt!");

            }
            else
            {
                int schaden = angreifer.VerursachterSchaden();

                kampflog["beschreibung"].Add($"{angreifer.Name} trifft {verteidiger.Name} für {schaden} Schaden!");

                verteidiger.ErhalteSchaden(schaden);

                kampflog[verteidiger.Name][1] = $"HP: {verteidiger.Leben}";
            }
        }

        public static void Kampfanweisung()
        {
            List<string> anweisungen = new List<string> {
                "Kampfanleitung\n",
                "\n",
                "Im Kampf musst du zwei Entscheidungen treffen: Wohin willst du deinen Gegner treffen – Kopf, Rumpf oder Beine?\n",
                "Danach wählst du aus, welchen Teil deines Körpers du schützen möchtest.\n",
                "Dein Gegner tut dasselbe – außer es handelt sich um ein Tier, denn Tiere greifen nur an und verteidigen sich nicht.\n",
                "Überlege gut, wo du zuschlägst und was du schützt – der richtige Treffer kann den Ausgang des Kampfes entscheiden!\n"
            };

            Console.Clear();

            anweisungen.Add("\n");
            anweisungen.Add("Hau auf <Enter>, sonst hau ich dich!");

            _zentrierterBereich.EinstellenAusgabeInformation(anweisungen, true);

            ConsoleKey key;

            do
            {
                key = Console.ReadKey(true).Key;
            }
            while (key != ConsoleKey.Enter);


        }
    }
}
