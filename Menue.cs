using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BFT32_Escape_Game
{
    static class Menue
    {
        public static void MenueAnzeigen()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Herzlich Willkommen zum Geisterspiel. Bitte wählen Sie eine Option:");
                Console.WriteLine("1. Spiel beginnen");
                Console.WriteLine("2. Beenden");
                Console.Write("Bitte geben Sie eine Zahl ein: ");
                
                string auswahl = Console.ReadLine();

                switch (auswahl)
                {
                    case "1":
                        Spiel.Spielstart();
                        
                        break;
                    case "2":
                        return;
                    default:
                        Console.WriteLine("Ungültige Auswahl. Bitte versuchen Sie es erneut.");
                        break;
                }
            }
        }
    }
}
