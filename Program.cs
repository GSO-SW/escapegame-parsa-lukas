// See https://aka.ms/new-console-template for more information
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

Console.WriteLine("Das ist ein kleines Beispiel für ein (langweiliges) Exit Game. \nIhr könnt es besser, viel Spaß! ");
Console.WriteLine("-----------------------------------------------------------------------");


Console.WriteLine("Geisterspiel");
int punkte = 0;
bool gameover = false;
Random random = new Random();
while (gameover == false)
{
    Console.WriteLine("Hinter einer Tür verbirgt sich ein Geist.\nWelche Tür wählst du? 1, 2 oder 3?");
    int tuer = Convert.ToInt32(Console.ReadLine());
    int geisterTuer = random.Next(1, 4);
    if (tuer == geisterTuer)
    {
        Console.WriteLine("Game over! Hier ist ein Geist!");
        Console.WriteLine("Deine Punkte: {0}", punkte);
        gameover = true;
    }
    else
    {
        Console.WriteLine("Kein Geist gefunden!");
        punkte = punkte + 1;
    }
}
