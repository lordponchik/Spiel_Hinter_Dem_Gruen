using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spiel_Hinter_Dem_Gruen.Statistik;
using Spiel_Hinter_Dem_Gruen.UI;

namespace Spiel_Hinter_Dem_Gruen.Spiel
{
    class Spiel
    {

        public static bool IstSpielVorbei = false;

        public static void StarteSpiel()
        {
            IstSpielVorbei = false;

                switch (AuswahlPunkteMenue())
                {
                    case 0:
                        NeuesSpiel();
                        break;
                    case 1:
                        Console.Clear();
                        ZentrierterBereich.EinstellenAusgabeInformation(new List<string> { "Für Schwache ist hier kein Platz – verschwinde!" });
                        Console.WriteLine();
                        return;
                }


        }
        private static int AuswahlPunkteMenue()
        {
            Ladebildschirm.ZeigeLadebildschirm();

            Startbildschirm startbildschirm = new Startbildschirm();

            startbildschirm.ZeigeSpielName();

            Ladebildschirm.ZeigeLadebildschirm();
            StatistikVerwaltung.LadeStatistic();
              Thread.Sleep(4000);

            Hauptmenue hauptmenue = new(new string[] { "Neues Spiel", "Ausgang" });

            hauptmenue.ZeigeSpielName();
           
            InteraktivesMenue menue = new(hauptmenue.PunkteMenue, ZentrierterBereich.EinstellenInteraktivesMenue);

            return menue.ZeigeUndWähle();
        }

        private static void NeuesSpiel()
        {

           
           Ladebildschirm.ZeigeLadebildschirm();
            Seitenbereich.Reset();

           Spieler spieler =  new Spieler(ZentrierterBereich.EinstellenAusgabeInformation, istErsterSpiel: true, leben: 30);

            Reise(spieler);


        }
        private static void ErsterKampf(Kaempfer spieler)
        {
            Kampf.Kampfanweisung();

            Tier gegner = new Tier("Ratte", 10, 5);

            KonsolenTrenner.ZeichneTrenner();

            Kampf.Rundenkampf(spieler, gegner);
            if (IstSpielVorbei) return;
            KonsolenTrenner.ZeichneTrenner();
        }

        private static void Reise(Spieler spieler)
        {

            Weltkarte weltkarte = new Weltkarte();

            foreach (string szene in weltkarte._ortListe)
            {

                Ladebildschirm.ZeigeLadebildschirm();
                weltkarte.ZeigeKapitel(szene);

                if (spieler.IstErsterSpiel)
                {
                    ErsterKampf(spieler);
                    if (IstSpielVorbei)
                    {
                        Console.Clear();
                        StarteSpiel();
                        return;
                    }
                    spieler.IstErsterSpiel = false;

                }

                KonsolenTrenner.ZeichneTrenner();

                List<string>[] gebiete = weltkarte.ZeigeGebietBeschreibung(szene);

                List<Kaempfer> gegner = weltkarte.ZeigeGebietGegner(szene);

                for (int i = 0; i < gebiete.Length; i++)
                {
                    bool gegnerBesiegt = false;


                    while (!gegnerBesiegt)
                    {
                        Kopfbereich.EinstellenAusgabeInformation(gebiete[i]);

                        int auswahl = spieler.ZeigeMenue(gegner[i].Name);

                        switch (auswahl)
                        {
                            case 0:
                                Fussbereich.Reset();
                                gegner[i].Rede();
                                gegnerBesiegt = Kampf.Rundenkampf(spieler, gegner[i]);
                                
                                if (IstSpielVorbei)
                                {
                                    Console.Clear();
                                    StarteSpiel();
                                    return;
                                }
                                
                                Kopfbereich.Reset();

                                break;
                            case 1:
                                Fussbereich.Reset();
                                spieler.ZeigeInventar();
                                break;
                            case 2:
                                IstSpielVorbei = true;
                                Console.Clear();
                                StatistikVerwaltung.SpeicherStatistic();
                                ZentrierterBereich.EinstellenAusgabeInformation(new List<string> { "Für Schwache ist hier kein Platz – verschwinde!" });
                                Console.WriteLine();
                                return;
                        }




                    }
                    Kopfbereich.Reset();
                }

            }

            Console.Clear();

            ZentrierterBereich.EinstellenAusgabeInformation(new List<string> { "Gewinn!"});
            Thread.Sleep(2000);
            StarteSpiel();
        }
    }
}
