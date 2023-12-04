using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_Solitaire
{
    internal class Valör : IValör
    {
        public Valör(int display)
        {
            facingUp = false;
            this.Display = display.ToString();
          
        }
        public Valör(int display, int värde)
        {
            facingUp = false;
            this.Display = display.ToString();
            this.Värde = värde.ToString(); 
        }
        public bool facingUp { get; set; }
        private string värde;
        public string Värde { get => värde; set { värde = VärdeCharacter(value); } }

        private string display;

        public string Display { get => display; set { display = DisplayCharacter(value); } }
        public ConsoleColor getColor()
        {
            if (display == "♠" || display == "♣")
                return ConsoleColor.Black;
            else return ConsoleColor.DarkRed;
        }
      
        public void GetDrawn()
        {
            {
                try
                {
                    if (facingUp)
                    {


                        Console.ForegroundColor = getColor();
                        Console.BackgroundColor = ConsoleColor.Gray;
                        Console.Write($"{display}{värde}");
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
        public string VärdeCharacter(string value)
        {
            switch (value)
            {

                case "11": return "J";
                case "12": return "Q";
                case "13": return "K";
                case "1": return "A";
                case "10": return "X";
                default:
                    return value;
            }
        }
        private string DisplayCharacter(string value)
        {
            switch (value)
            {

                case "1": return "♠";
                case "2": return "♣";
                case "3": return "♥";
                case "4": return "♦";
         
                default:
                    return value;
            }
        }
    }
}
