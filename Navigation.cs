using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BFT32_Escape_Game
{
    static class Navigation
    {
        //Methode zur Navigation zwischen den Bahnen
        public static int Next()
        {
            int naechsterBahn = 0;
            bool gueltigeEingabe = false;

            //Solange die Eingabe ungültig ist, wird der Benutzer aufgefordert, eine gültige Zahl einzugeben
            while (!gueltigeEingabe)
            {
                //Aktuellen Status anzeigen
                Globals.ClearAndShowStatus();
                Console.WriteLine("In welchen Bahn möchtest du gehen?");
                Console.WriteLine("1 = Erster Bahn");
                Console.WriteLine("2 = Zweite Bahn");
                Console.WriteLine("3 = Dritte Bahn");
                Console.WriteLine("4 = Vierte Bahn");
                Console.Write("\nBitte geben Sie eine Zahl ein: ");

                string eingabe = Console.ReadLine();
                //Überprüfen, ob die Eingabe eine gültige Zahl zwischen 1 und 4 ist
                if (int.TryParse(eingabe, out int BahnNummer) && BahnNummer >= 1 && BahnNummer <= 4)
                {
                    naechsterBahn = BahnNummer;
                    gueltigeEingabe = true;
                }
                else
                {
                    Console.WriteLine("\nBitte gib eine Zahl zwischen 1 und 4 ein.");
                    Console.WriteLine("Drücke eine beliebige Taste zum Fortfahren...");
                    Console.ReadKey();
                }
            }

            return naechsterBahn;
        }
    }
}
