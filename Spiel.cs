using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BFT32_Escape_Game
{
    static class Spiel
    {
        public static void Spielstart()
        {
            Console.WriteLine("\nWillkommen im U-Bahn Escape Game!");
            Console.WriteLine("Du befindest dich in einer U-Bahn mit 4 Bahnen.");
            Console.WriteLine("In jedem Bahn sind zwei Buchstaben versteckt. Finde alle Buchstaben und löse das Rätsel!");
            Console.WriteLine("Viel Glück!\n");

            while (!Globals.gameover)
            {
                int naechsterBahn = Navigation.Next();
                if (naechsterBahn > 0 && naechsterBahn <= 4)
                {
                    Globals.aktuellerRaum = Raum.alleRaeume[naechsterBahn - 1];
                    Raum.alleRaeume[naechsterBahn - 1].RaumBetreten();
                    Raum.alleRaeume[naechsterBahn - 1].RaetselAnzeigen();
                }
            }
        }
    }
}
