using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spiel_Hinter_Dem_Gruen.Items;
using Spiel_Hinter_Dem_Gruen.Ressourcen;
using Spiel_Hinter_Dem_Gruen.UI;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Spiel_Hinter_Dem_Gruen.Spiel
{
    class Weltkarte
    {
        private static ZentrierterBereich _zentrierterBereich = new ZentrierterBereich();

        public readonly string[] _ortListe = ["ork_1", "ork_2", "ork_3"];
        private Dictionary<string, Szene> _weltkarte = WeltkarteLoader.LadeWeltkarteAusJson("Szenen.json");
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

            _zentrierterBereich.EinstellenAusgabeInformation(gesamtText, true);

            ConsoleKey key;

            do
            {
                key = Console.ReadKey(true).Key;
            }
            while (key != ConsoleKey.Enter);

        }
       
        public List<List<string>> ZeigeGebietBeschreibung(string aktuellerOrtId)
        {
            Szene aktuelleSzene = _weltkarte[aktuellerOrtId];

            return aktuelleSzene.gebietBeschreibungen;
        }
        
        public List<Gegner> ZeigeGebietGegner(string aktuellerOrtId)
        {
            GegnerDaten gegnerDaten = new GegnerDaten();

            return gegnerDaten.GegnerListe[aktuellerOrtId];
        }
    }
}