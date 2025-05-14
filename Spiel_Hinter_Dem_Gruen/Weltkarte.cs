using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Spiel_Hinter_Dem_Gruen
{
    class Weltkarte
    {
        public string AktuellerOrtId { get; set; }

        Dictionary<string, Szene> weltkarte = new Dictionary<string, Szene>
        {
            {
                "ork_1",

                new Szene
                {
                    Titel = "Kapitel 1.1",
                    Name = "Höhlen der Verstoßenen",
                    Beschreibung= new List<string>{"Die Luft ist feucht und schwer, durchdrungen vom beißenden Gestank von Schweiß, altem Fleisch und nassem Stein.\n", 
                        "Seit unzähligen Nächten schläfst du hier, eingerollt auf einem zerfetzten Fell zwischen Knochen, Fackelruß und Grunzlauten deiner Artgenossen.\n",
                        "In der Dunkelheit verlieren selbst Orks ihr Zeitgefühl – doch heute reißt dich etwas anderes aus dem Halbschlaf.\n", 
                        "\n",
                        "Ein schabendes, feuchtes Geräusch. Erst undeutlich, dann scharf. Du öffnest die Augen.\n",
                "Kleine, scharfe Zähne graben sich genüsslich in deinen Zeh.\n",
                "Eine fette Ratte sitzt dort, starrt dich mit leeren Augen an und kaut ungerührt weiter.\n",
                "\n",
                "Knusper, knabber... chrum-chrum.\n"},
                }
            },
            {   "ork_2",

                new Szene
                {
                    Titel = "Kapitel 1.2",
                    Name = "Verlassene Arenen",
                    Beschreibung = new List<string>{"Verlassene Arenen"},
                }
            },
                        {   "ork_3",

                new Szene
                {
                    Titel = "Kapitel 1.3",
                    Name = "Orklager",
                    Beschreibung = new List<string>{"Orklager"},
                }
            }
        };

        public Weltkarte(string aktuellerOrtId)
        {
            AktuellerOrtId = aktuellerOrtId;
        }

        public void ZeigeKapitel()
        {
            Console.Clear();

            
            Szene aktuelleSzene = weltkarte[AktuellerOrtId];

            List<string> gesamtText = new List<string>();
            gesamtText.AddRange(new List<string> { $"{aktuelleSzene.Titel}\n", "\n", $"Ort: {aktuelleSzene.Name}\n", "\n" });
            gesamtText.AddRange(aktuelleSzene.Beschreibung);
            gesamtText.Add("\n");
            gesamtText.Add("Hau auf <Enter>, sonst hau ich dich!");

            ZentrierterBereich.EinstellenAusgabeInformation(gesamtText);

            ConsoleKey key;

            do
            {
                key = Console.ReadKey(true).Key;
            }
            while (key != ConsoleKey.Enter);

        }
    }
}

