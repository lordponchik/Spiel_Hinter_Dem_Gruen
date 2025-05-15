using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Spiel_Hinter_Dem_Gruen
{
    class Spieler : Kaempfer
    {
        private static readonly string[] Koerperteile = { "Kopf", "Rumpf", "Beine" };
        public string AktuellerOrtId { get; set; }

        public bool IstErsterSpiel { get; set; }

        private readonly Action<List<string>> _rendering;
        public Spieler(Action<List<string>> rendering, string aktuellerOrtId = "ork_1", bool istErsterSpiel = false, string name = "", int leben = 100) : base(name, leben)
        {
            _rendering = rendering;
            Name = Benennung();
            AktuellerOrtId = aktuellerOrtId;
            IstErsterSpiel = istErsterSpiel;

        }

        public string Benennung()
        {
            string name = "";

            while (true)
            {
                Console.Clear();

                _rendering(new List<string>() { "Die anderen Orks lachen über dich – du bist der Letzte in der Rangordnung.\n",
                    "Deine Muskeln zittern, dein Magen knurrt – du bist nicht gerade furchteinflößend.\n",
                    "Ein Ork, ja. Aber ein besonders mickriger.\n",
                    "",
                    "Ein Ork hat keine Zeit für Zungenbrecher. Maximal zehn Zeichen!\n",
                    "Sag mir, wie du heißt: ",
                });

                name = (Console.ReadLine() ?? "").Trim();

                if (name.Length > 0 && name.Length < 11) break;
            }

            Thread.Sleep(250);
            Console.Clear();

            _rendering(new List<string> { $"Willkommen {name}" });

            Thread.Sleep(1500);

            return name;
        }

        public override void WaehleAngriff()
        {
            InteraktivesMenue interaktivesMenue = new InteraktivesMenue(Koerperteile, Fussbereich.EinstellenInteraktivesMenue);

            KoerperTeilAngriff = interaktivesMenue.ZeigeUndWähle("Wohin willst du schlagen?");
        }
        public override void WaehleVerteidigung()
        {

            InteraktivesMenue interaktivesMenue = new InteraktivesMenue(Koerperteile, Fussbereich.EinstellenInteraktivesMenue);

            KoerperTeilVerteidigung = interaktivesMenue.ZeigeUndWähle("Was willst du verteidigen?");
        }


        public int ZeigeMenue(string name)
        {
            string[] menue = { $"Gegner: {name} herausfordern", "Inventar öffnen", "Spiel speichern", "Spiel beenden" };


            InteraktivesMenue menue1 = new(menue, Fussbereich.EinstellenInteraktivesMenue);
            return menue1.ZeigeUndWähle();
        }

        public override void ErhalteSchaden(int schaden)
        {
            base.ErhalteSchaden(schaden);



            if(Leben == 0)
            {
                Console.Clear();

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

                ZentrierterBereich.EinstellenAusgabeInformation(gesamtBlock);

                Thread.Sleep(4000);

                Spiel.IstSpielVorbei = true;

                
            }
        }

    }
}
