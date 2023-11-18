using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_Solitaire
{
    internal class Kort
    {
        //public static List<IValör> valörs = new List<IValör> { new Ruter(), new Klöver(), new Spader(), new Hjärter() } ;
        public int värde;
        private string display;
        public string Display { get => display; set {  if (value == "11") display = "N"; else if (value == "12") display = "Q"; else if (value == "13") display = "K"; else if (value == "1") display = "A"; else if (value == "10") display = "X"; else display = value; }  }
        //public  string värde { get  => Värde;  set {  }
        public IValör valör {  get; set; }

        public bool facingUp;
        public Kort (int värde, IValör valör)
        {
            this.värde = värde;
            this.valör = valör;
            this.facingUp = false;
            this.Display = värde.ToString();
        }
    }
}
