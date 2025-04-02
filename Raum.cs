using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BFT32_Escape_Game
{
    public class Raum { 

        //Liste, um alle Räume zu speichern
        public static List<Raum> alleRaeume = new List<Raum>();
        private static bool alleBuchstabenGefunden = false;

        //Attribute
        public int Nr;
        public string Name;
        public bool Begehbar;
        private string versteckteBuchstaben;
        private bool buchstabenGefunden;
        
        //Berechnete Eigenschaft (Charakter anwesend oder nicht?)
        public bool CharakterAnw { 
            get { if (Globals.aktuellerRaum == this)
                return true;
                return false;
            } 
        }

        //Konstruktor
        public Raum(int raumNr, string raumName, bool raumBegehbar, string buchstaben)
        {
            Nr = raumNr;
            Name = raumName;
            Begehbar = raumBegehbar;
            versteckteBuchstaben = buchstaben;
            buchstabenGefunden = false;
        }

        //Statische Methode, um alle Räume zu erstellen
        public static void ErstelleRaeume()
        {
            //Liste leeren, falls sie bereits Räume enthält
            alleRaeume.Clear();
            
            //Erstelle die Bahnen der U-Bahn mit versteckten Buchstaben
            alleRaeume.Add(new Raum(1, "Bahn 1", true, "El"));
            alleRaeume.Add(new Raum(2, "Bahn 2", true, "on"));
            alleRaeume.Add(new Raum(3, "Bahn 3", true, "Mu"));
            alleRaeume.Add(new Raum(4, "Bahn 4", true, "sk"));
        }

        //Methoden
        public void RaumBetreten()
        {
            Globals.aktuellerRaum = this;
            Globals.ClearAndShowStatus();
        }

        public void RaetselAnzeigen()
        {
            if (!buchstabenGefunden)
            {
                Console.WriteLine($"\nDu befindest dich im {Name}.");
                Console.WriteLine("Du siehst eine verschlossene Schachtel. Möchtest du sie öffnen? (j/n)");
                string antwort = Console.ReadLine().ToLower();
                
                if (antwort == "j")
                {
                    Console.WriteLine($"Du findest die Buchstaben: {versteckteBuchstaben}");
                    buchstabenGefunden = true;
                    Globals.gefundeneBuchstaben.Add(versteckteBuchstaben);
                    
                    if (Globals.gefundeneBuchstaben.Count == 4)
                    {
                        alleBuchstabenGefunden = true;
                        Console.WriteLine("\nDu hast alle Buchstaben gefunden! Jetzt musst du die richtige Reihenfolge herausfinden.");
                        Console.WriteLine("Die gefundenen Buchstaben sind: " + string.Join("", Globals.gefundeneBuchstaben));
                        Console.WriteLine("\nEr revolutionierte Elektroautos, eroberte den Weltraum und kaufte ein soziales Netzwerk – wer ist gemeint?");

                        while (!Globals.gameover)
                        {
                            Console.Write("\nLösungswort: ");
                            string eingabe = Console.ReadLine();
                            
                            if (eingabe == "Elon Musk")
                            {
                                Console.WriteLine("\nGlückwunsch! Du hast den richtigen Namen gefunden!");
                                Console.WriteLine("Du kannst jetzt die U-Bahn verlassen!");
                                Console.ReadKey();
                                Globals.gameover = true;
                            }
                            else
                            {
                                Console.WriteLine("Das ist leider nicht die richtige Antwort. Versuche es noch einmal!");
                                Console.WriteLine("\nDrücke Enter zum Fortfahren...");
                                Console.ReadLine();
                                Console.Clear();
                                Console.WriteLine("\nEr revolutionierte Elektroautos, eroberte den Weltraum und kaufte ein soziales Netzwerk – wer ist gemeint?");
                                Console.WriteLine("Die gefundenen Buchstaben sind: " + string.Join("", Globals.gefundeneBuchstaben));
                            }
                        }
                    }
                }
            }
            else if (!alleBuchstabenGefunden)
            {
                Console.WriteLine($"\nDu hast in diesem Bahn bereits die Buchstaben {versteckteBuchstaben} gefunden.");
                Console.WriteLine("Suche in den anderen Bahnen nach weiteren Buchstaben!");
            }
            else
            {
                Console.WriteLine("\nDu hast bereits alle Buchstaben gefunden!");
                Console.WriteLine("Versuche die richtige Reihenfolge für den Namen herauszufinden!");
            }
        }
    }
}