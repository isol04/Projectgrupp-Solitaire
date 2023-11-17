using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_Solitaire
{
    internal class Hjärter : IValör
    {
        public void GetDrawn(Kort k)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.Write($"♥{k.värde}");
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.Write("  ");
        }
    }
}
