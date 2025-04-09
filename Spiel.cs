using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExitGame;

namespace BFT32_Escape_Game
{
    static class Spiel
    {
        private static List<string> foundLetters = new List<string>();
        private static List<Lager.Raum> rooms;

        public static void Spielstart()
        {
            rooms = Lager.InitializeRooms();
            foundLetters = new List<string>();

            while (true)
            {
                Console.Clear();
                Console.WriteLine("\nDu bist in der U-Bahn gefangen!");
                Console.WriteLine("Gefundene Buchstaben: " + string.Join("", foundLetters));
                Console.WriteLine("\nVerfügbare Bahnen:");
                
                for (int i = 0; i < rooms.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. U-Bahn {rooms[i].BahnNummer}" + 
                        (rooms[i].IstGefunden ? " (Buchstaben bereits gefunden)" : ""));
                }
                
                if (foundLetters.Count == 4)
                {
                    Console.WriteLine("\n5. Rätsel lösen");
                }
                else
                {
                    Console.WriteLine("\n5. Rätsel lösen (noch nicht verfügbar)");
                }
                Console.WriteLine("6. Zurück zum Hauptmenü");
                
                Console.Write("\nWähle eine Option: ");
                var choice = Console.ReadLine();
                
                if (choice == "6") break;
                
                if (choice == "5")
                {
                    if (foundLetters.Count < 4)
                    {
                        Console.WriteLine("\nDu musst erst alle Buchstaben finden, bevor du das Rätsel lösen kannst!");
                        Console.WriteLine("Drücke Enter zum Fortfahren...");
                        Console.ReadLine();
                        continue;
                    }

                    Console.Clear();
                    Console.WriteLine("\nEr revolutionierte Elektroautos, eroberte den Weltraum und kaufte ein soziales Netzwerk.");
                    Console.WriteLine("Die gefundenen Buchstaben sind: " + string.Join("", foundLetters));
                    
                    while (true)
                    {
                        Console.Write("\nLösungswort: ");
                        var name = Console.ReadLine();
                        
                        if (name.ToLower() == "Elon Musk".ToLower())
                        {
                            Console.WriteLine("\nGratulation! Du hast den richtigen Namen gefunden!");
                            Console.WriteLine("Du bist entkommen!");
                            Console.ReadKey();
                            return;
                        }
                        else
                        {
                            Console.WriteLine("\nFalscher Name! Versuche es noch einmal!");
                            Console.WriteLine("Drücke Enter zum Fortfahren...");
                            Console.ReadLine();
                            Console.Clear();
                            Console.WriteLine("\nEr revolutionierte Elektroautos, eroberte den Weltraum und kaufte ein soziales Netzwerk.");
                            Console.WriteLine("Die gefundenen Buchstaben sind: " + string.Join("", foundLetters));
                        }
                    }
                }
                
                if (int.TryParse(choice, out int roomChoice) && roomChoice >= 1 && roomChoice <= 4)
                {
                    var selectedRoom = rooms[roomChoice - 1];
                    if (!selectedRoom.IstGefunden)
                    {
                        Console.WriteLine($"\nDu bist in U-Bahn {selectedRoom.BahnNummer}");
                        Console.WriteLine(selectedRoom.Hinweis);
                        Console.WriteLine("\nMöchtest du nach den Buchstaben suchen? (j/n)");
                        
                        if (Console.ReadLine().ToLower() == "j")
                        {
                            selectedRoom.IstGefunden = true;
                            foundLetters.Add(selectedRoom.VersteckteBuchstaben);
                            Console.WriteLine($"\nDu hast die Buchstaben {selectedRoom.VersteckteBuchstaben} gefunden!");
                        }
                    }
                    else
                    {
                        Console.WriteLine("\nDu hast die Buchstaben in dieser Bahn bereits gefunden!");
                    }
                    
                    Console.WriteLine("\nDrücke Enter zum Fortfahren...");
                    Console.ReadLine();
                }
            }
        }
    }
}
