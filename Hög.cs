using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_Solitaire
{
     class Hög
    {
        private int nummer;
        public List<Kort> högensKort = new List<Kort>();

        public Hög(int nummer)
        {
            this.nummer = nummer;
        }   

        public Kort getÖverst()
        {
            
                return högensKort[högensKort.Count - 1];
         
        }
        public Kort getNederst()
        {
            for(int i = 0; i < högensKort.Count; i++)
            {
                if (högensKort[i].facingUp)
                    return högensKort[i];
            }
            return högensKort[högensKort.Count - 1];
        }

        public void flyttaTillHög(Kort k)
        {

        }

    }
}
