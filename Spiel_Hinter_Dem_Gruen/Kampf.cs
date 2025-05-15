using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Spiel_Hinter_Dem_Gruen
{
    class Kampf
    {

        private static Dictionary<string, List<string>>? _kampfLog = null;

        public static bool Rundenkampf(Kaempfer spieler, Kaempfer gegner)
        {

            _kampfLog = KampfLog.ErstelleLog(spieler, gegner);

            while (!spieler.IstBesiegt() && !gegner.IstBesiegt())
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
                            Seitenbereich.EinstellenAusgabeInformation(eintrag.Value[eintrag.Value.Count - 2]);
                            Seitenbereich.EinstellenAusgabeInformation(eintrag.Value[eintrag.Value.Count - 1]);
                        }
                    }
                    else
                    {
                        for (int i = 0; i < eintrag.Value.Count; i += 1)
                        {
                            Seitenbereich.EinstellenAusgabeInformation(eintrag.Value[i]);
                        }
                    }
                }

                spieler.WaehleAngriff();
                spieler.WaehleVerteidigung();

                gegner.WaehleAngriff();
                gegner.WaehleVerteidigung();

                BerechnungSchaden(spieler, gegner, _kampfLog);
                BerechnungSchaden(gegner, spieler, _kampfLog);



                Seitenbereich.Reset();
            }

            return gegner.Leben == 0;

        }

        private static void BerechnungSchaden(Kaempfer angreifer, Kaempfer verteidiger, Dictionary<string, List<string>> kampflog)
        {
            if (angreifer.KoerperTeilAngriff == verteidiger.KoerperTeilVerteidigung)
            {

                kampflog["beschreibung"].Add($"{angreifer.Name} greift an, aber {verteidiger.Name} blockt!");

            }
            else
            {
                int schaden = 10;

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

            ZentrierterBereich.EinstellenAusgabeInformation(anweisungen);

            ConsoleKey key;

            do
            {
                key = Console.ReadKey(true).Key;
            }
            while (key != ConsoleKey.Enter);

            
        }
    }
}
