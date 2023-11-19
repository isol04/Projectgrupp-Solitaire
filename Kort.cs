using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_Solitaire
{
     class Kort
    {
        public static List<Kort> Korten = new();

        public int värde;
        private string display;

        public string Display { get => display; set { display = DisplayCharacter(value); } }
       
        public Valör valör  {  get; set; }

        public bool facingUp;
        public Kort (int värde, Valör valör)
        {
            this.värde = värde;
            this.valör = valör;
            this.facingUp = false;
            this.Display = värde.ToString();
        }
        public string DisplayCharacter(string value)
        {
            switch(value)
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

    }
}
