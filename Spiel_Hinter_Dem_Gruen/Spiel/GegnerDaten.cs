using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spiel_Hinter_Dem_Gruen.Items;

namespace Spiel_Hinter_Dem_Gruen.Spiel
{
    class GegnerDaten
    {
        public Dictionary<string, List<Gegner>> GegnerListe = new Dictionary<string, List<Gegner>>
        {
            {
                "ork_1", new List<Gegner>
                {
                     new Gegner("Grubnag der Gierige", 20, 20, schaden: 5, new List<string>{ "Grubnag der Gierige\n", "\n", "Du stinkst nicht besser als die Ratte. Mal sehen, wie du schmeckst!\n", "Grubnag will dein Herz... zum Frühstück!\n" }),
                     new Gegner("Brakzahn der Brutale", 25, 25, schaden: 7, new List<string>{ "Brakzahn der Brutale\n", "\n", "Ich hab mit einem Finger mehr Gegner zerschmettert, als du Haare aufm Kopf hast!\n", "Komm näher, Kleiner. Ich will sehen, wie schnell du blutest.\n" }),
                     new Gegner("Xargash Flammenatem", 30, 30,schaden: 9, new List<string>{ "Xargash Flammenatem\n", "\n", "Feuer reinigt. Bist du bereit für die Flammen?\n", "Ich werde dich grillen – schön knusprig!\n" } ),
                     new Gegner("Mok der Verstummte", 35,35, schaden: 11, new List<string>{ "Mok der Verstummte\n", "\n", "(Er sagt kein Wort. Nur ein knurrender Laut. Dann ein tiefer Atemzug.)\n", "(Er zeigt stumm auf deine Kehle – und macht eine schneidende Geste.)\n" }),
                     new Gegner("Kror Eisenfaust", 40, 40, schaden: 13, new List<string>{ "Kror Eisenfaust\n", "\n", "Eisen redet nicht. Es zerschmettert.\n", "Deine Knochen? Nur neue Trophäen für meine Wand.\n" }),
                     new Gegner("Drog’Marr der Wächter", 45, 45, schaden: 15, new List<string>{ "Drog’Marr der Wächter\n", "\n", "Ich habe hunderte kommen sehen... keiner ging.\n", "Beweise, dass du mehr bist als nur ein weiterer Verstoßener.\n" }, waffe: ItemDatenbank.knorpelknacker )
                }
            },
            {
                "ork_2", new List<Gegner>
                {
                    new Gegner("Thrag der Stählerne", 50,50, schaden: 6, new List<string>{"Thrag der Stählerne\n","\n","Mit einer Rüstung aus rostigem Stahl erwartet er dich.\n","„Nur wer Stahl im Herzen trägt, verdient meinen Respekt.“\n"}),
                    new Gegner("Zugra die Schattenklaue", 55,55, schaden: 8, new List<string>{"Zugra die Schattenklaue\n","\n","Leise wie ein Schatten schleicht sie durch die Arena.\n","„Fühl die Kälte meiner Krallen!“\n"}),
                    new Gegner("Gorath der Berserker", 60,60, schaden: 11, new List<string>{"Gorath der Berserker\n","\n","Mit wildem Blick und zerrissener Kleidung stürmt er vor.\n","„Keiner verlässt meine Arena lebend!“\n"}),
                    new Gegner("Selira die Giftmischerin", 65,65, schaden: 12, new List<string>{"Selira die Giftmischerin\n","\n","Ihre Pfeile sind mit tödlichem Gift getränkt.\n","„Ein einziger Stich, und du bist verloren.“\n"}),
                    new Gegner("Durn der Unbezwingbare", 70,70, schaden: 14, new List<string>{"Durn der Unbezwingbare\n","\n","Er trägt eine massive Axt und ein unerschütterliches Selbstvertrauen.\n","„Ich bin das Ende für jeden Herausforderer.“\n"}, waffe: ItemDatenbank.rostklaue),
                }
            },
            {
                "ork_3", new List<Gegner>
                {
                    new Gegner("Rok der Berserker", 75,75, schaden: 12, new List<string>{"Rok der Berserker\n","\n","Ein wilder Kämpfer, dessen Zorn jeden Feind zerreißt.\n","„Ich werde dich in Stücke reißen!“\n"}),
                    new Gegner("Shara die Scharfschützin", 80,80, schaden: 14, new List<string>{"Shara die Scharfschützin\n","\n","Ihre Pfeile finden immer ihr Ziel, tödlich und schnell.\n","„Ein einziger Schuss, und du bist erledigt.“\n"}),
                    new Gegner("Krag der Fäuste", 85,85, schaden: 15, new List<string>{"Krag der Fäuste\n","\n","Seine bloßen Hände sind härter als Stahl.\n","„Ich zerquetsche alles, was sich bewegt.“\n"}),
                    new Gegner("Gor’Thak der Warlord", 90,90, schaden: 20, new List<string>{"Gor’Thak der Warlord\n","\n","Der mächtige Anführer der Orks – und dein Vater.\n","„So bist du also zurückgekehrt, mein Sohn... Ich hatte gehofft, du würdest deinen Platz finden, ohne den Clan zu verraten.\n","Jetzt musst du beweisen, ob du wirklich würdig bist, mein Erbe anzutreten – oder für immer gefallen bist!“\n"})
                }
            }
        };
    }
}
