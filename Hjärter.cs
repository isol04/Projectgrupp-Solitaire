using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_Solitaire
{
    internal class Hjärter : IValör
    {
        public string getValör()
        {
            return "h";
        }
        public bool ärRöd()
        {
            return true;
        }
        public void GetDrawn(Kort k)
        {
            try
            {
                if (k.facingUp)
                {


                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.BackgroundColor = ConsoleColor.Gray;
                    Console.Write($"♥{k.Display}");
                    Console.BackgroundColor = ConsoleColor.DarkGreen;
                    Console.Write(" ");
                    Console.ForegroundColor = ConsoleColor.Black;
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
