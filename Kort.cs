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

        private int värde;
        public int getVärde()
        {
        return värde;
        }

        public ConsoleColor getColor()
        {
            return valör.getColor();
        }
        public bool facingUp()
        {
            return valör.facingUp;
        }
        public void flipDown()
        {
            valör.facingUp = false;
        }
        public void flipUp()
        {
            valör.facingUp = true;
        }
        public void getDrawn()
        {
            valör.GetDrawn();
        }
        public string getValör()
        {
            return valör.Display;
        }
        private IValör valör { get;set; }
     

        public Kort (int värde, IValör valör)
        {
            this.värde = värde;
            this.valör = valör;
         
        }
     
    }
}
