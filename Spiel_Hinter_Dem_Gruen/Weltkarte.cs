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

        public readonly string[] _ortListe = ["ork_1", "ork_2", "ork_3"];

        private Dictionary<string, Szene> _weltkarte = new Dictionary<string, Szene>
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
                    gebietBeschreibungen = new List<string>[]
                    {
                       new List<string> {"Die Pilzschlucht\n", "\n","Ein feuchter, modriger Pfad, der von riesigen leuchtenden Pilzen gesäumt ist.\n",
                            "Der Gestank von Schimmel liegt in der Luft.\n",
                            "Ein Ork steht mitten auf dem Pfad, seine Keule dampft von frischem Blut.\n" },
                        new List<string> {"Der Knochenplatz\n", "\n","Knochen türmen sich zu kleinen Haufen, als hättest du ein Schlachtfeld längst vergangener Kämpfe betreten.\n",
                             "Ein breitschultriger Ork thront auf einem umgestürzten Thron aus Rippen.\n" },
                        new List<string> {"Die Feuerspalte\n","\n","Ein schmaler Gang führt an einer glühenden Felsspalte vorbei, aus der Hitze und Asche aufsteigen.\n",
                             "Ein tätowierter Ork wirbelt mit flammenden Sicheln durch die Luft.\n" },
                        new List<string>   {"Der Tränensee\n","\n","Stilles Wasser sammelt sich in einer Senke.\n",
                             "Kristalle wachsen an den Wänden.\n",
                           "Die Luft ist still – zu still.",
                           "Ein Ork mit bemaltem Gesicht erhebt sich langsam aus dem Wasser."},
                          new List<string> {"Die Eisenkluft\n", "\n","Rostige Waffen, zerbrochene Rüstungen – hier wurden viele besiegt.\n",
                             "Ein schwer gerüsteter Ork mit einem gigantischen Hammer wartet schweigend.\n"  },
                          new List<string> {"Der Ausstiegsschacht\n", "\n","Endlich – das Licht!\n",
                             "Ein natürlicher Schacht öffnet sich nach oben. \n",
                           "Doch zwischen dir und dem Aufstieg steht der größte Ork, den du je gesehen hast.\n",
                            },

                    },
                     Gegner = new List<Kaempfer>
                          {
                            new Gegner("Grubnag der Gierige", 20, schaden: 5, new List<string>{ "Grubnag der Gierige\n", "\n", "Du stinkst nicht besser als die Ratte. Mal sehen, wie du schmeckst!\n", "Grubnag will dein Herz... zum Frühstück!\n" }),
                            new Gegner("Brakzahn der Brutale", 25, schaden: 7, new List<string>{ "Brakzahn der Brutale\n", "\n", "Ich hab mit einem Finger mehr Gegner zerschmettert, als du Haare aufm Kopf hast!\n", "Komm näher, Kleiner. Ich will sehen, wie schnell du blutest.\n" }),
                            new Gegner("Xargash Flammenatem", 30,schaden: 10, new List<string>{ "Xargash Flammenatem\n", "\n", "Feuer reinigt. Bist du bereit für die Flammen?\n", "Ich werde dich grillen – schön knusprig!\n" }, waffe: ItemDatenbank.knorpelknacker ),
                            new Gegner("Mok der Verstummte", 35,schaden: 12, new List<string>{ "Mok der Verstummte\n", "\n", "(Er sagt kein Wort. Nur ein knurrender Laut. Dann ein tiefer Atemzug.)\n", "(Er zeigt stumm auf deine Kehle – und macht eine schneidende Geste.)\n" }),
                            new Gegner("Kror Eisenfaust", 40,schaden: 13, new List<string>{ "Kror Eisenfaust\n", "\n", "Eisen redet nicht. Es zerschmettert.\n", "Deine Knochen? Nur neue Trophäen für meine Wand.\n" }),
                            new Gegner("Drog’Marr der Wächter", 45,schaden: 15, new List<string>{ "Drog’Marr der Wächter\n", "\n", "Ich habe hunderte kommen sehen... keiner ging.\n", "Beweise, dass du mehr bist als nur ein weiterer Verstoßener.\n" }, waffe: ItemDatenbank.rostklaue ),
                          }
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

        public void ZeigeKapitel(string aktuellerOrtId)
        {
            Console.Clear();

            Szene aktuelleSzene = _weltkarte[aktuellerOrtId];

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
        public List<string>[] ZeigeGebietBeschreibung(string aktuellerOrtId)
        {
            Szene aktuelleSzene = _weltkarte[aktuellerOrtId];

            return aktuelleSzene.gebietBeschreibungen;

        }
        public List<Kaempfer> ZeigeGebietGegner(string aktuellerOrtId)
        {
            Szene aktuelleSzene = _weltkarte[aktuellerOrtId];

            return aktuelleSzene.Gegner;

        }
    }
}

