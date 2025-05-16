using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spiel_Hinter_Dem_Gruen.Items;
using Spiel_Hinter_Dem_Gruen.UI;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Spiel_Hinter_Dem_Gruen.Spiel
{
    class Weltkarte
    {

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
                            new Gegner("Xargash Flammenatem", 30,schaden: 9, new List<string>{ "Xargash Flammenatem\n", "\n", "Feuer reinigt. Bist du bereit für die Flammen?\n", "Ich werde dich grillen – schön knusprig!\n" } ),
                            new Gegner("Mok der Verstummte", 35,schaden: 11, new List<string>{ "Mok der Verstummte\n", "\n", "(Er sagt kein Wort. Nur ein knurrender Laut. Dann ein tiefer Atemzug.)\n", "(Er zeigt stumm auf deine Kehle – und macht eine schneidende Geste.)\n" }),
                            new Gegner("Kror Eisenfaust", 40,schaden: 13, new List<string>{ "Kror Eisenfaust\n", "\n", "Eisen redet nicht. Es zerschmettert.\n", "Deine Knochen? Nur neue Trophäen für meine Wand.\n" }),
                            new Gegner("Drog’Marr der Wächter", 45,schaden: 15, new List<string>{ "Drog’Marr der Wächter\n", "\n", "Ich habe hunderte kommen sehen... keiner ging.\n", "Beweise, dass du mehr bist als nur ein weiterer Verstoßener.\n" },  waffe: ItemDatenbank.knorpelknacker ),
                          }
                }
            },
          {
    "ork_2",

    new Szene
    {
        Titel = "Kapitel 1.2",
        Name = "Verlassene Arenen",
        Beschreibung = new List<string>
        {
            "Du hast die düsteren Höhlen hinter dir gelassen und stehst nun vor den Ruinen der verlassenen Arenen.\n",
            "Die Luft ist trocken und staubig, das Echo deiner Schritte hallt von zerfallenen Mauern wider.\n",
            "An manchen Stellen liegen zerbrochene Waffen und Rüstungen verstreut, Überbleibsel blutiger Kämpfe.\n",
            "In der Ferne hörst du das Heulen des Windes, der durch die leeren Tribünen pfeift.\n",
            "Doch Vorsicht – hier lauern neue Gefahren.\n"
        },
        gebietBeschreibungen = new List<string>[]
        {
            new List<string>
            {
                "Die Verfallene Hauptarena\n",
                "\n",
                "Ein riesiger, offener Platz mit rissigem Boden und eingestürzten Tribünen.\n",
                "An manchen Stellen sind alte Bannerschleifen noch sichtbar, verblasst und zerfetzt.\n",
                "Im Zentrum steht ein verrostetes Tor, das den Eingang zu tieferen Ebenen versperrt.\n"
            },
            new List<string>
            {
                "Die Schattenboxen\n",
                "\n",
                "Enge Gänge und kleine Arenen, in denen einst Kämpfe hinter verschlossenen Türen stattfanden.\n",
                "Das Licht fällt nur spärlich durch Ritzen in den zerbrochenen Dächern.\n",
                "Geräusche hallen unheimlich nach – vielleicht sind nicht alle Kämpfer gegangen.\n"
            },
            new List<string>
            {
                "Der zerbrochene Thron\n",
                "\n",
                "Ein hoher, zerfallener Sitz, der früher dem Champion der Arenen gehörte.\n",
                "Schilde und Banner liegen zerstreut auf dem Boden, verrostet und verstaubt.\n",
                "Eine düstere Präsenz scheint diesen Ort zu bewachen.\n"
            },
            new List<string>
            {
                "Die Ruinen der Trainingshalle\n",
                "\n",
                "Einst ein Ort der Ausbildung, jetzt nur noch ein Haufen Trümmer.\n",
                "Verrostete Waffen hängen schief an zerfetzten Gestellen.\n",
                "Der Boden ist übersät mit zerbrochenen Holzlatten und Splittern.\n"
            },
            new List<string>
            {
                "Der Blutgraben\n",
                "\n",
                "Ein tiefer Graben, der als Kampfgrube diente.\n",
                "Flecken von altem, getrocknetem Blut sind auf dem Boden zu sehen.\n",
                "Der Geruch von Eisen liegt schwer in der Luft.\n"
            }
        },
        Gegner = new List<Kaempfer>
        {
            new Gegner("Thrag der Stählerne", 50, schaden: 6, new List<string>
            {
                "Thrag der Stählerne\n",
                "\n",
                "Mit einer Rüstung aus rostigem Stahl erwartet er dich.\n",
                "„Nur wer Stahl im Herzen trägt, verdient meinen Respekt.“\n"
            }),
            new Gegner("Zugra die Schattenklaue", 55, schaden: 8, new List<string>
            {
                "Zugra die Schattenklaue\n",
                "\n",
                "Leise wie ein Schatten schleicht sie durch die Arena.\n",
                "„Fühl die Kälte meiner Krallen!“\n"
            }),
            new Gegner("Gorath der Berserker", 60, schaden: 11, new List<string>
            {
                "Gorath der Berserker\n",
                "\n",
                "Mit wildem Blick und zerrissener Kleidung stürmt er vor.\n",
                "„Keiner verlässt meine Arena lebend!“\n"
            }),
            new Gegner("Selira die Giftmischerin", 65, schaden: 12, new List<string>
            {
                "Selira die Giftmischerin\n",
                "\n",
                "Ihre Pfeile sind mit tödlichem Gift getränkt.\n",
                "„Ein einziger Stich, und du bist verloren.“\n"
            }),
            new Gegner("Durn der Unbezwingbare", 70, schaden: 14, new List<string>
            {
                "Durn der Unbezwingbare\n",
                "\n",
                "Er trägt eine massive Axt und ein unerschütterliches Selbstvertrauen.\n",
                "„Ich bin das Ende für jeden Herausforderer.“\n"
            }, waffe: ItemDatenbank.rostklaue),
        }
    }
},
                    {
    "ork_3",

    new Szene
    {
        Titel = "Kapitel 1.3",
        Name = "Orklager",
        Beschreibung = new List<string>
        {
            "Du hast die verlassenen Arenen hinter dir gelassen und stehst nun vor dem Herzen des Orklagers.\n",
            "Hier, zwischen hohen Palisaden aus Holz und Stein, pulsiert die rohe Kraft der Orks.\n",
            "Das Knurren und Trommeln der Krieger hallt durch die Luft, während der Geruch von Rauch und Blut deine Sinne betäubt.\n",
            "Vor dir liegt der Platz des großen Warlords – deinem Vater.\n",
            "Ein Kampf, der mehr als nur dein Leben entscheidet, steht bevor.\n"
        },
       gebietBeschreibungen = new List<string>[]
{
    new List<string>
    {
        "Das Hauptlager\n",
        "\n",
        "Ein riesiges Lager mit Zelten, Waffenstangen und Feuerstellen.\n",
        "Orks bereiten sich auf den Kampf vor, während Kriegsbanner im Wind wehen.\n"
    },
    new List<string>
    {
        "Die Warlord-Arena\n",
        "\n",
        "Eine offene Kampfarena, umgeben von Steinen und Knochen der Gefallenen.\n",
        "Hier wird die ultimative Herausforderung auf dich warten.\n"
    },
    new List<string>
    {
        "Der Geheime Pfad\n",
        "\n",
        "Ein schmaler, versteckter Weg, der zu den Lagerhallen führt.\n",
        "Hier kannst du dich auf den letzten Kampf vorbereiten.\n"
    },
    new List<string>
    {
        "Die Halle des Warlords\n",
        "\n",
        "Ein massives Gebäude aus Holz und Stein, das den Respekt und die Macht des Warlords symbolisiert.\n",
        "Im Inneren lodern große Feuerstellen, und die Wände sind mit Trophäen früherer Schlachten geschmückt.\n",
        "Dies ist die letzte Bastion deines Vaters – ein Ort voller Erinnerungen und Prüfungen.\n"
    }
},
        Gegner = new List<Kaempfer>
        {
            new Gegner("Rok der Berserker", 75, schaden: 12, new List<string>
            {
                "Rok der Berserker\n",
                "\n",
                "Ein wilder Kämpfer, dessen Zorn jeden Feind zerreißt.\n",
                "„Ich werde dich in Stücke reißen!“\n"
            }),
            new Gegner("Shara die Scharfschützin", 80, schaden: 14, new List<string>
            {
                "Shara die Scharfschützin\n",
                "\n",
                "Ihre Pfeile finden immer ihr Ziel, tödlich und schnell.\n",
                "„Ein einziger Schuss, und du bist erledigt.“\n"
            }),
            new Gegner("Krag der Fäuste", 85, schaden: 15, new List<string>
            {
                "Krag der Fäuste\n",
                "\n",
                "Seine bloßen Hände sind härter als Stahl.\n",
                "„Ich zerquetsche alles, was sich bewegt.“\n"
            }),

            new Gegner("Gor’Thak der Warlord", 90, schaden: 20, new List<string>
            {
                "Gor’Thak der Warlord\n",
                "\n",
                "Der mächtige Anführer der Orks – und dein Vater.\n",
                "„So bist du also zurückgekehrt, mein Sohn... Ich hatte gehofft, du würdest deinen Platz finden, ohne den Clan zu verraten.\n",
                "Jetzt musst du beweisen, ob du wirklich würdig bist, mein Erbe anzutreten – oder für immer gefallen bist!“\n"
            })
        }
    }
}

        };

        public Weltkarte()
        {
           
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

