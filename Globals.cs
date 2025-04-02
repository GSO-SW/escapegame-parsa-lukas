using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BFT32_Escape_Game
{
    public static class Globals
    {
        public static int punkte = 0;
        public static bool gameover = false;
        public static Random random = new Random();
        public static Raum aktuellerRaum;
        public static List<string> gefundeneBuchstaben = new List<string>();

        public static void ClearAndShowStatus()
        {
            Console.Clear();
            Console.WriteLine("=== U-Bahn Escape Game - Aktueller Stand ===");
            Console.WriteLine($"Gefundene Buchstaben: {gefundeneBuchstaben.Count}/4");
            if (gefundeneBuchstaben.Count > 0)
            {
                Console.WriteLine($"Gefundene Buchstaben: {string.Join("", gefundeneBuchstaben)}");
            }
            Console.WriteLine("==========================================\n");
        }
    }
}
