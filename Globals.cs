using System.Collections.Generic;

namespace BFT32_Escape_Game
{
    public static class Globals
    {
        public static Raum aktuellerRaum;
        public static List<int> gefundeneZahlen = new List<int>();
        public static bool gameover = false;

        public static void ClearAndShowStatus()
        {
            // Example implementation for clearing the console and showing status
            Console.Clear();
            Console.WriteLine("Status updated.");
        }
    }
}