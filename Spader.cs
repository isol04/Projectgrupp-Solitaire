using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_Solitaire
{
    internal class Spader : IValör
    {
        public string getValör()
        {
            return "s";
        }
        public bool ärRöd()
        {
            return false;
        }
        public void GetDrawn(Kort k)
        {
            try
            {
                if (k.facingUp)
                {


                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.BackgroundColor = ConsoleColor.Gray;
                    Console.Write($"♠{k.Display}");
                    Console.BackgroundColor = ConsoleColor.DarkGreen;
                    Console.Write(" ");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.BackgroundColor = ConsoleColor.Gray;
                    Console.Write("}{");
                    Console.BackgroundColor = ConsoleColor.DarkGreen;
                    Console.Write(" ");
                }
            }
            catch
            {
                Console.Write("   ");
            }
        }
    }
}
