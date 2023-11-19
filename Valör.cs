using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_Solitaire
{
     class Valör 
    {
      
        public virtual ConsoleColor getColor()
        {
            return ConsoleColor.Black;
        }
        public virtual string getValör()
        {
            return null;
        }
        public virtual void GetDrawn(Kort k)
        {
            {
                try
                {
                    if (k.facingUp)
                    {


                        Console.ForegroundColor = getColor();
                        Console.BackgroundColor = ConsoleColor.Gray;
                        Console.Write($"{getValör()}{k.Display}");
                        Console.BackgroundColor = ConsoleColor.DarkGreen;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.Write(" ");
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.BackgroundColor = ConsoleColor.Gray;
                        Console.Write("}{");
                        Console.BackgroundColor = ConsoleColor.DarkGreen;
                        Console.ForegroundColor = ConsoleColor.Black;
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
}
